using System;
using System.Data;
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

        public static readonly string[] DanhSachVaiTro = { "Admin", "ThuNgan" };

        public static DataTable TraCuu(string tuKhoa)
        {
            return TaiKhoanDAL.TraCuuTaiKhoan(tuKhoa);
        }

        public static string TaoMaMoi()
        {
            return TaiKhoanDAL.TaoMaMoi();
        }

        // 2. THEM TAI KHOAN
        public static bool Them(TaiKhoanDTO tk, string matKhau, out string loi)
        {
            if (!KiemTra(tk, out loi) || !KiemTraMatKhau(matKhau, out loi)) return false;
            try
            {
                tk.MaTK = TaiKhoanDAL.TaoMaMoi();   // luon sinh ma moi, khong dung ma dang chon tren form
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
            tk.MatKhauHash = BamMatKhau(matKhau);
            return TaiKhoanDAL.ThemTaiKhoan(tk, out loi);
        }

        // 3. SUA TAI KHOAN: matKhauMoi de trong thi giu mat khau cu (Admin dat lai mat khau cho nguoi khac)
        public static bool CapNhat(TaiKhoanDTO tk, string matKhauMoi, out string loi)
        {
            if (!KiemTra(tk, out loi)) return false;

            // khong cho tu khoa / tu ha quyen chinh minh -> luon con it nhat 1 Admin dang dang nhap duoc
            if (tk.MaTK == TaiKhoanHienTai?.MaTK && (!tk.TrangThai || tk.VaiTro != "Admin"))
            {
                loi = "Không thể khóa hoặc hạ quyền tài khoản đang đăng nhập.";
                return false;
            }

            bool doiMatKhau = !string.IsNullOrEmpty(matKhauMoi);
            if (doiMatKhau)
            {
                if (!KiemTraMatKhau(matKhauMoi, out loi)) return false;
                tk.MatKhauHash = BamMatKhau(matKhauMoi);
            }
            if (!TaiKhoanDAL.CapNhatTaiKhoan(tk, doiMatKhau, out loi)) return false;

            // Admin sua chinh minh: cap nhat lai phien dang nhap (DoiMatKhau tra theo TenDangNhap)
            if (tk.MaTK == TaiKhoanHienTai?.MaTK)
            {
                TaiKhoanHienTai.TenDangNhap = tk.TenDangNhap;
                if (doiMatKhau) TaiKhoanHienTai.MatKhauHash = tk.MatKhauHash;
            }
            return true;
        }

        // 4. XOA TAI KHOAN
        public static bool Xoa(string maTK, out string loi)
        {
            loi = "";
            if (string.IsNullOrEmpty(maTK))
            {
                loi = "Vui lòng chọn tài khoản cần xóa.";
                return false;
            }
            if (maTK == TaiKhoanHienTai?.MaTK)
            {
                loi = "Không thể xóa tài khoản đang đăng nhập.";
                return false;
            }
            return TaiKhoanDAL.XoaTaiKhoan(maTK, out loi);
        }

        // 5. DOI MAT KHAU CUA TAI KHOAN DANG DANG NHAP
        public static bool DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhan, out string loi)
        {
            loi = "";
            TaiKhoanDTO? hienTai = TaiKhoanHienTai;
            if (hienTai == null)
            {
                loi = "Chưa đăng nhập.";
                return false;
            }

            try
            {
                // doc lai tu CSDL de so dung mat khau hien tai
                TaiKhoanDTO? tk = TaiKhoanDAL.LayTheoTenDangNhap(hienTai.TenDangNhap);
                if (tk == null || tk.MatKhauHash != BamMatKhau(matKhauCu ?? ""))
                {
                    loi = "Mật khẩu cũ không đúng.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                loi = "Không kết nối được CSDL: " + ex.Message;
                return false;
            }

            if (!KiemTraMatKhau(matKhauMoi, out loi)) return false;
            if (matKhauMoi != xacNhan)
            {
                loi = "Mật khẩu xác nhận không khớp.";
                return false;
            }
            if (matKhauMoi == matKhauCu)
            {
                loi = "Mật khẩu mới phải khác mật khẩu cũ.";
                return false;
            }

            string hash = BamMatKhau(matKhauMoi);
            if (!TaiKhoanDAL.DoiMatKhau(hienTai.MaTK, hash, out loi)) return false;
            hienTai.MatKhauHash = hash;
            return true;
        }

        private static bool KiemTra(TaiKhoanDTO tk, out string loi)
        {
            loi = "";
            tk.TenDangNhap = (tk.TenDangNhap ?? "").Trim();

            if (tk.TenDangNhap.Length < 3 || tk.TenDangNhap.Length > 50 || tk.TenDangNhap.Contains(' '))
                loi = "Tên đăng nhập dài 3-50 ký tự và không chứa khoảng trắng.";
            else if (Array.IndexOf(DanhSachVaiTro, tk.VaiTro) < 0)
                loi = "Vui lòng chọn vai trò.";

            return loi == "";
        }

        private static bool KiemTraMatKhau(string matKhau, out string loi)
        {
            loi = (matKhau ?? "").Length < 6 ? "Mật khẩu phải có ít nhất 6 ký tự." : "";
            return loi == "";
        }
    }
}
