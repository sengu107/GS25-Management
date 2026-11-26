using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

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
    }
}
