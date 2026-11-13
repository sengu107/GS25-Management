
using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using GS25Management.DTO;

namespace GS25Management.DAL
{
    public class MaGiamGiaDAL
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["GS25DB"].ConnectionString;

        // 1. THEM MA GIAM GIA
        public static bool ThemMaGiamGia(MaGiamGiaDTO maGG, out string loi)
        {
            loi = "";

            if (maGG == null)
            {
                loi = "Thông tin mã giảm giá không hợp lệ.";
                return false;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        INSERT INTO MaGiamGia
                        (MaGiamGia, TenMaGiamGia, LoaiGiamGia, GiaTriGiam,
                         NgayBatDau, NgayKetThuc, SoLuong, TrangThai)
                        VALUES
                        (@ma, @ten, @loai, @giaTri,
                         @ngayBatDau, @ngayKetThuc, @soLuong, @trangThai)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maGG.MaGiamGia);
                        cmd.Parameters.AddWithValue("@ten", maGG.TenMaGiamGia);
                        cmd.Parameters.AddWithValue("@loai", maGG.LoaiGiamGia);
                        cmd.Parameters.AddWithValue("@giaTri", maGG.GiaTriGiam);
                        cmd.Parameters.AddWithValue("@ngayBatDau", maGG.NgayBatDau);
                        cmd.Parameters.AddWithValue("@ngayKetThuc", maGG.NgayKetThuc);
                        cmd.Parameters.AddWithValue("@soLuong", maGG.SoLuong);
                        cmd.Parameters.AddWithValue("@trangThai", maGG.TrangThai);

                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    loi = ex.Message;
                    return false;
                }
            }
        }

        // 2. CAP NHAT MA GIAM GIA
        public static bool CapNhatMaGiamGia(MaGiamGiaDTO maGG, out string loi)
        {
            loi = "";

            if (maGG == null)
            {
                loi = "Thông tin mã giảm giá không hợp lệ.";
                return false;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        UPDATE MaGiamGia
                        SET TenMaGiamGia = @ten,
                            LoaiGiamGia = @loai,
                            GiaTriGiam = @giaTri,
                            NgayBatDau = @ngayBatDau,
                            NgayKetThuc = @ngayKetThuc,
                            SoLuong = @soLuong,
                            TrangThai = @trangThai
                        WHERE MaGiamGia = @ma";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maGG.MaGiamGia);
                        cmd.Parameters.AddWithValue("@ten", maGG.TenMaGiamGia);
                        cmd.Parameters.AddWithValue("@loai", maGG.LoaiGiamGia);
                        cmd.Parameters.AddWithValue("@giaTri", maGG.GiaTriGiam);
                        cmd.Parameters.AddWithValue("@ngayBatDau", maGG.NgayBatDau);
                        cmd.Parameters.AddWithValue("@ngayKetThuc", maGG.NgayKetThuc);
                        cmd.Parameters.AddWithValue("@soLuong", maGG.SoLuong);
                        cmd.Parameters.AddWithValue("@trangThai", maGG.TrangThai);

                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            loi = "Không tìm thấy mã giảm giá cần cập nhật.";
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    loi = ex.Message;
                    return false;
                }
            }
        }

        // 3. XOA MA GIAM GIA
        public static bool XoaMaGiamGia(string maGiamGia, out string loi)
        {
            loi = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        DELETE FROM MaGiamGia
                        WHERE MaGiamGia = @ma";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maGiamGia);

                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            loi = "Không tìm thấy mã giảm giá cần xóa.";
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    loi = "Không thể xóa mã giảm giá: " + ex.Message;
                    return false;
                }
            }
        }

        // 4. TRA CUU MA GIAM GIA
        public static DataTable TraCuuMaGiamGia(string tuKhoa)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"
                    SELECT *
                    FROM MaGiamGia
                    WHERE MaGiamGia LIKE @tuKhoa
                       OR TenMaGiamGia LIKE @tuKhoa
                       OR LoaiGiamGia LIKE @tuKhoa
                    ORDER BY NgayBatDau DESC";

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

        // 5. LAY THONG TIN MOT MA GIAM GIA
        public static MaGiamGiaDTO LayMaGiamGia(string maGiamGia)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT *
                    FROM MaGiamGia
                    WHERE MaGiamGia = @ma";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maGiamGia);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MaGiamGiaDTO maGG = new MaGiamGiaDTO();

                            maGG.MaGiamGia = reader["MaGiamGia"].ToString();
                            maGG.TenMaGiamGia = reader["TenMaGiamGia"].ToString();
                            maGG.LoaiGiamGia = reader["LoaiGiamGia"].ToString();
                            maGG.GiaTriGiam = Convert.ToDecimal(reader["GiaTriGiam"]);
                            maGG.NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]);
                            maGG.NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                            maGG.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                            maGG.TrangThai = reader["TrangThai"].ToString();

                            return maGG;
                        }
                    }
                }
            }

            return null;
        }
    }
}
