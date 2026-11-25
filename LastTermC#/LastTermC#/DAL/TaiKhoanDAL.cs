using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using GS25Management.DTO;

namespace GS25Management.DAL
{
    public class TaiKhoanDAL
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["GS25DB"].ConnectionString;

        // LAY TAI KHOAN THEO TEN DANG NHAP (kem ho ten nhan vien)
        public static TaiKhoanDTO? LayTheoTenDangNhap(string tenDangNhap)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT tk.*, nv.HoTen
                    FROM TaiKhoan tk
                    LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                    WHERE tk.TenDangNhap = @ten";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", tenDangNhap);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TaiKhoanDTO
                            {
                                MaTK = reader["MaTK"].ToString()!,
                                TenDangNhap = reader["TenDangNhap"].ToString()!,
                                MatKhauHash = reader["MatKhauHash"].ToString()!,
                                VaiTro = reader["VaiTro"].ToString()!,
                                MaNV = reader["MaNV"] == DBNull.Value ? null : reader["MaNV"].ToString(),
                                HoTen = reader["HoTen"] == DBNull.Value ? null : reader["HoTen"].ToString(),
                                TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
