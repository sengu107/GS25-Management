using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using GS25Management.DTO;

namespace GS25Management.DAL
{
    public class NhanVienDAL
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["GS25DB"].ConnectionString;

        // TRA CUU NHAN VIEN (theo ma, ho ten, so dien thoai)
        public static DataTable TraCuuNhanVien(string tuKhoa)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"
                    SELECT *
                    FROM NhanVien
                    WHERE MaNV LIKE @tuKhoa
                       OR HoTen LIKE @tuKhoa
                       OR SoDienThoai LIKE @tuKhoa
                    ORDER BY MaNV";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + (tuKhoa ?? "") + "%");

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // SINH MA NHAN VIEN MOI: NV001, NV002, ...
        public static string TaoMaMoi()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IFNULL(MAX(CAST(SUBSTRING(MaNV, 3) AS UNSIGNED)), 0) + 1 FROM NhanVien";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    return "NV" + Convert.ToInt32(cmd.ExecuteScalar()).ToString("000");
                }
            }
        }

        // 1. THEM NHAN VIEN
        public static bool ThemNhanVien(NhanVienDTO nv, out string loi)
        {
            return ThucThi(@"
                INSERT INTO NhanVien
                (MaNV, HoTen, GioiTinh, NgaySinh, SoDienThoai, DiaChi, ChucVu, CaLamViec, NgayVaoLam, TrangThai)
                VALUES
                (@ma, @hoTen, @gioiTinh, @ngaySinh, @sdt, @diaChi, @chucVu, @ca, @ngayVaoLam, @trangThai)", nv, out loi);
        }

        // 2. CAP NHAT NHAN VIEN
        public static bool CapNhatNhanVien(NhanVienDTO nv, out string loi)
        {
            return ThucThi(@"
                UPDATE NhanVien
                SET HoTen = @hoTen, GioiTinh = @gioiTinh, NgaySinh = @ngaySinh, SoDienThoai = @sdt,
                    DiaChi = @diaChi, ChucVu = @chucVu, CaLamViec = @ca, NgayVaoLam = @ngayVaoLam,
                    TrangThai = @trangThai
                WHERE MaNV = @ma", nv, out loi);
        }

        // 3. XOA NHAN VIEN
        public static bool XoaNhanVien(string maNV, out string loi)
        {
            return ThucThi("DELETE FROM NhanVien WHERE MaNV = @ma", new NhanVienDTO { MaNV = maNV }, out loi);
        }

        // Chay lenh ghi voi cac tham so lay tu NhanVienDTO
        private static bool ThucThi(string sql, NhanVienDTO nv, out string loi)
        {
            loi = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", nv.MaNV);
                        cmd.Parameters.AddWithValue("@hoTen", nv.HoTen);
                        cmd.Parameters.AddWithValue("@gioiTinh", (object?)nv.GioiTinh ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ngaySinh", (object?)nv.NgaySinh ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@sdt", (object?)nv.SoDienThoai ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@diaChi", (object?)nv.DiaChi ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@chucVu", (object?)nv.ChucVu ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ca", (object?)nv.CaLamViec ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ngayVaoLam", nv.NgayVaoLam);
                        cmd.Parameters.AddWithValue("@trangThai", nv.TrangThai);

                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            loi = "Không tìm thấy nhân viên " + nv.MaNV + ".";
                            return false;
                        }
                    }

                    return true;
                }
                catch (MySqlException ex) when (ex.Number == 1451)  // con du lieu tham chieu (tai khoan, hoa don...)
                {
                    loi = "Không thể xóa: nhân viên đã có tài khoản hoặc chứng từ. Hãy bỏ chọn \"Đang làm việc\" để cho nghỉ việc.";
                    return false;
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
