using System;
using System.Security.Cryptography;
using System.Text;
using GS25Management.DAL;
using GS25Management.DTO;

namespace GS25Management.BUS
{
    public class TaiKhoanBUS
    {
        // Tai khoan dang dang nhap (dung de phan quyen tren frmMain va ghi MaNV cho hoa don)
        public static TaiKhoanDTO? TaiKhoanHienTai { get; set; }

        // SHA-256 dang hex chu thuong, khop voi SHA2(..., 256) cua MySQL
        public static string BamMatKhau(string matKhau)
        {
            return Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(matKhau)));
        }

        // 1. DANG NHAP
        public static TaiKhoanDTO? DangNhap(string tenDangNhap, string matKhau, out string loi)
        {
            loi = "";
            tenDangNhap = (tenDangNhap ?? "").Trim();

            if (tenDangNhap == "" || string.IsNullOrEmpty(matKhau))
            {
                loi = "Vui lòng nhập tên đăng nhập và mật khẩu.";
                return null;
            }

            try
            {
                TaiKhoanDTO? tk = TaiKhoanDAL.LayTheoTenDangNhap(tenDangNhap);

                // cung 1 thong bao cho sai ten / sai mat khau de khong lo ten dang nhap
                if (tk == null || tk.MatKhauHash != BamMatKhau(matKhau))
                {
                    loi = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return null;
                }

                if (!tk.TrangThai)
                {
                    loi = "Tài khoản đã bị khóa, vui lòng liên hệ quản lý.";
                    return null;
                }

                TaiKhoanHienTai = tk;
                return tk;
            }
            catch (Exception ex)
            {
                loi = "Không kết nối được CSDL: " + ex.Message;
                return null;
            }
        }

        public static void DangXuat()
        {
            TaiKhoanHienTai = null;
        }
    }
}
