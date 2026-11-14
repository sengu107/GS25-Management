
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using MySql.Data.MySqlClient;
using GS25Management.DTO;

namespace GS25Management.DAL
{
    public class HoaDonBanHangDAL
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["GS25DB"].ConnectionString;

        // 1. LAP HOA DON
        public static void LapHoaDon(
            HoaDonBanHangDTO hoaDon,
            List<ChiTietHoaDonDTO> chiTietList,
            List<GiamGiaDTO> giamGiaList,
            out string loi)
        {
            loi = "";

            if (hoaDon == null)
            {
                loi = "Thông tin hóa đơn không hợp lệ.";
                return;
            }

            if (chiTietList == null || chiTietList.Count == 0)
            {
                loi = "Danh sách sản phẩm không được để trống.";
                return;
            }

            if (chiTietList.Any(ct => ct.SoLuong <= 0))
            {
                loi = "Số lượng sản phẩm phải lớn hơn 0.";
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            //kiem tra ton kho truoc khi them hoa don
                            foreach (var nhom in chiTietList.GroupBy(ct => ct.MaSanPham))
                            {
                                int tongSoLuong = nhom.Sum(ct => ct.SoLuong);

                                string sqlCheck =
                                    "SELECT SoLuongTon FROM SanPham " +
                                    "WHERE MaSanPham = @ma FOR UPDATE";

                                using (MySqlCommand cmd = new MySqlCommand(sqlCheck, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@ma", nhom.Key);

                                    object result = cmd.ExecuteScalar();

                                    if (result == null || result == DBNull.Value)
                                        throw new Exception(
                                            $"Sản phẩm mã {nhom.Key} không tồn tại.");

                                    int tonKho = Convert.ToInt32(result);

                                    if (tonKho < tongSoLuong)
                                    {
                                        string tenSP = nhom.First().TenSanPham;

                                        throw new Exception(
                                            $"Sản phẩm '{tenSP}' chỉ còn {tonKho}, " +
                                            $"không đủ bán {tongSoLuong}.");
                                    }
                                }
                            }

                            // them thong tin hoa don vao bang HoaDonBanHang
                            string sqlHoaDon = @"
                                INSERT INTO HoaDonBanHang
                                (NgayLap, MaNhanVien, SoDienThoaiKhachHang,
                                 TongTien, TienGiam, ThanhTien, TrangThai, GhiChu)
                                VALUES
                                (@ngayLap, @maNhanVien, @soDienThoai,
                                 @tongTien, @tienGiam, @thanhTien, @trangThai, @ghiChu);
                                SELECT LAST_INSERT_ID();";

                            int maHoaDon;

                            using (MySqlCommand cmd = new MySqlCommand(sqlHoaDon, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@ngayLap",
                                    hoaDon.NgayLap == default ? DateTime.Now : hoaDon.NgayLap);

                                cmd.Parameters.AddWithValue("@maNhanVien", hoaDon.MaNhanVien);

                                cmd.Parameters.AddWithValue("@soDienThoai",
                                    (object)hoaDon.SoDienThoaiKhachHang ?? DBNull.Value);

                                cmd.Parameters.AddWithValue("@tongTien", hoaDon.TongTien);
                                cmd.Parameters.AddWithValue("@tienGiam", hoaDon.TienGiam);
                                cmd.Parameters.AddWithValue("@thanhTien", hoaDon.ThanhTien);

                                cmd.Parameters.AddWithValue("@trangThai",
                                    string.IsNullOrEmpty(hoaDon.TrangThai)
                                    ? "Đã thanh toán" : hoaDon.TrangThai);

                                cmd.Parameters.AddWithValue("@ghiChu",
                                    (object)hoaDon.GhiChu ?? DBNull.Value);

                                maHoaDon = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // them chi tiet hoa don vao bang ChiTietHoaDon va cap nhat ton kho
                            string sqlChiTiet = @"
                                INSERT INTO ChiTietHoaDon
                                (MaHoaDon, MaSanPham, SoLuong, DonGia,
                                 GiamGiaSanPham, ThanhTien)
                                VALUES
                                (@maHD, @maSP, @soLuong, @donGia,
                                 @giamGia, @thanhTien)";

                            string sqlUpdateKho = @"
                                UPDATE SanPham
                                SET SoLuongTon = SoLuongTon - @soLuong
                                WHERE MaSanPham = @maSP
                                AND SoLuongTon >= @soLuong";

                            foreach (var ct in chiTietList)
                            {
                                using (MySqlCommand cmd = new MySqlCommand(sqlChiTiet, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@maHD", maHoaDon);
                                    cmd.Parameters.AddWithValue("@maSP", ct.MaSanPham);
                                    cmd.Parameters.AddWithValue("@soLuong", ct.SoLuong);
                                    cmd.Parameters.AddWithValue("@donGia", ct.DonGia);
                                    cmd.Parameters.AddWithValue("@giamGia", ct.GiamGiaSanPham);
                                    cmd.Parameters.AddWithValue("@thanhTien", ct.ThanhTien);

                                    cmd.ExecuteNonQuery();
                                }

                                using (MySqlCommand cmd = new MySqlCommand(sqlUpdateKho, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@soLuong", ct.SoLuong);
                                    cmd.Parameters.AddWithValue("@maSP", ct.MaSanPham);

                                    if (cmd.ExecuteNonQuery() == 0)
                                        throw new Exception("Không thể cập nhật tồn kho.");
                                }
                            }

                            // luu thong tin ma giam gia da ap dung vao bang ChiTietGiamGiaHoaDon
                            if (giamGiaList != null)
                            {
                                string sqlGiamGia = @"
                                    INSERT INTO ChiTietGiamGiaHoaDon
                                    (MaHoaDon, MaGiamGia, TienGiam)
                                    VALUES (@maHD, @maGG, @tienGiam)";

                                foreach (var gg in giamGiaList)
                                {
                                    using (MySqlCommand cmd = new MySqlCommand(sqlGiamGia, conn, trans))
                                    {
                                        cmd.Parameters.AddWithValue("@maHD", maHoaDon);
                                        cmd.Parameters.AddWithValue("@maGG", gg.MaGiamGia);
                                        cmd.Parameters.AddWithValue("@tienGiam", gg.TienGiam);

                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            // hoan tat
                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    loi = ex.Message;
                }
            }
        }

        // tra cuu hoa don theo ma hoa don, so dien thoai khach hang, ma nhan vien
        public static DataTable TraCuuHoaDon(string tuKhoa)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"
                    SELECT *
                    FROM HoaDonBanHang
                    WHERE CAST(MaHoaDon AS CHAR) LIKE @tuKhoa
                       OR SoDienThoaiKhachHang LIKE @tuKhoa
                       OR CAST(MaNhanVien AS CHAR) LIKE @tuKhoa
                    ORDER BY NgayLap DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@tuKhoa", "%" + (tuKhoa ?? "") + "%");

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

       // Xoa hoa don ra khoi CSDL
        public static bool XoaHoaDon(int maHoaDon, out string loi)
        {
            return XoaHoaDonChung(maHoaDon, false, out loi);
        }

        // Huy Hoa Don (hoan hang) - xoa hoa don va hoan lai ton kho
        public static bool XoaHoaDonHoanHang(int maHoaDon, out string loi)
        {
            return XoaHoaDonChung(maHoaDon, true, out loi);
        }

        // Xu ly chung cho xoa hoa don 
        private static bool XoaHoaDonChung(
            int maHoaDon, bool hoanHang, out string loi)
        {
            loi = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // kiem tra hoa don co ton tai va khoa ban ghi truoc khi xoa
                            string sqlCheck =
                                "SELECT MaHoaDon FROM HoaDonBanHang " +
                                "WHERE MaHoaDon = @maHD FOR UPDATE";

                            using (MySqlCommand cmd = new MySqlCommand(sqlCheck, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@maHD", maHoaDon);

                                if (cmd.ExecuteScalar() == null)
                                    throw new Exception("Hóa đơn không tồn tại.");
                            }

                            // hoan lai ton kho neu la hoan hang
                            if (hoanHang)
                            {
                                string sqlKho = @"
                                    UPDATE SanPham sp
                                    INNER JOIN ChiTietHoaDon ct
                                        ON sp.MaSanPham = ct.MaSanPham
                                    SET sp.SoLuongTon = sp.SoLuongTon + ct.SoLuong
                                    WHERE ct.MaHoaDon = @maHD";

                                using (MySqlCommand cmd = new MySqlCommand(sqlKho, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@maHD", maHoaDon);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // xoa cac ban ghi lien quan trong bang ChiTietGiamGiaHoaDon truoc
                            string sqlXoaGG =
                                "DELETE FROM ChiTietGiamGiaHoaDon WHERE MaHoaDon = @maHD";

                            using (MySqlCommand cmd = new MySqlCommand(sqlXoaGG, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@maHD", maHoaDon);
                                cmd.ExecuteNonQuery();
                            }

                            // xoa chi tiet hoa don truoc khi xoa hoa don
                            string sqlXoaCT =
                                "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @maHD";

                            using (MySqlCommand cmd = new MySqlCommand(sqlXoaCT, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@maHD", maHoaDon);
                                cmd.ExecuteNonQuery();
                            }

                            // xoa hoa don
                            string sqlXoaHD =
                                "DELETE FROM HoaDonBanHang WHERE MaHoaDon = @maHD";

                            using (MySqlCommand cmd = new MySqlCommand(sqlXoaHD, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@maHD", maHoaDon);
                                cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    loi = ex.Message;
                    return false;
                }
            }
        }
    }
}
