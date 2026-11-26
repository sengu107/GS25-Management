using System;
using System.Configuration;
using System.Data;
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

        // TRA CUU TAI KHOAN (khong lay MatKhauHash ra giao dien)
        public static DataTable TraCuuTaiKhoan(string tuKhoa)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = @"
                    SELECT tk.MaTK, tk.TenDangNhap, tk.VaiTro, tk.MaNV, nv.HoTen, tk.TrangThai, tk.NgayTao
                    FROM TaiKhoan tk
                    LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                    WHERE tk.MaTK LIKE @tuKhoa
                       OR tk.TenDangNhap LIKE @tuKhoa
                       OR nv.HoTen LIKE @tuKhoa
                    ORDER BY tk.MaTK";

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

        // SINH MA TAI KHOAN MOI: TK001, TK002, ...
        public static string TaoMaMoi()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IFNULL(MAX(CAST(SUBSTRING(MaTK, 3) AS UNSIGNED)), 0) + 1 FROM TaiKhoan";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    return "TK" + Convert.ToInt32(cmd.ExecuteScalar()).ToString("000");
                }
            }
        }

        // 1. THEM TAI KHOAN
        public static bool ThemTaiKhoan(TaiKhoanDTO tk, out string loi)
        {
            return ThucThi(@"
                INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhauHash, VaiTro, MaNV, TrangThai)
                VALUES (@ma, @ten, @hash, @vaiTro, @maNV, @trangThai)", tk, out loi);
        }

        // 2. CAP NHAT TAI KHOAN (doiMatKhau = false thi giu nguyen mat khau cu)
        public static bool CapNhatTaiKhoan(TaiKhoanDTO tk, bool doiMatKhau, out string loi)
        {
            string sql = @"
                UPDATE TaiKhoan
                SET TenDangNhap = @ten, VaiTro = @vaiTro, MaNV = @maNV, TrangThai = @trangThai"
                + (doiMatKhau ? ", MatKhauHash = @hash" : "") + @"
                WHERE MaTK = @ma";
            return ThucThi(sql, tk, out loi);
        }

        // 3. XOA TAI KHOAN
        public static bool XoaTaiKhoan(string maTK, out string loi)
        {
            return ThucThi("DELETE FROM TaiKhoan WHERE MaTK = @ma", new TaiKhoanDTO { MaTK = maTK }, out loi);
        }

        // 4. DOI MAT KHAU
        public static bool DoiMatKhau(string maTK, string hashMoi, out string loi)
        {
            return ThucThi("UPDATE TaiKhoan SET MatKhauHash = @hash WHERE MaTK = @ma",
                new TaiKhoanDTO { MaTK = maTK, MatKhauHash = hashMoi }, out loi);
        }

        // Chay lenh ghi voi cac tham so lay tu TaiKhoanDTO
        private static bool ThucThi(string sql, TaiKhoanDTO tk, out string loi)
        {
            loi = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", tk.MaTK);
                        cmd.Parameters.AddWithValue("@ten", tk.TenDangNhap);
                        cmd.Parameters.AddWithValue("@hash", tk.MatKhauHash);
                        cmd.Parameters.AddWithValue("@vaiTro", tk.VaiTro);
                        cmd.Parameters.AddWithValue("@maNV", (object?)tk.MaNV ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@trangThai", tk.TrangThai);

                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            loi = "Không tìm thấy tài khoản " + tk.MaTK + ".";
                            return false;
                        }
                    }

                    return true;
                }
                catch (MySqlException ex) when (ex.Number == 1062)  // trung khoa UNIQUE
                {
                    loi = "Tên đăng nhập \"" + tk.TenDangNhap + "\" đã tồn tại.";
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
