using System;
using System.Data;
using System.Text.RegularExpressions;
using GS25Management.DAL;
using GS25Management.DTO;

namespace GS25Management.BUS
{
    public class NhanVienBUS
    {
        public static readonly string[] DanhSachChucVu = { "Quản lý", "Thu ngân", "Nhân viên kho" };
        public static readonly string[] DanhSachCa = { "Ca sáng", "Ca chiều", "Ca tối", "Hành chính" };

        public static DataTable TraCuu(string tuKhoa)
        {
            return NhanVienDAL.TraCuuNhanVien(tuKhoa);
        }

        // 1. THEM NHAN VIEN (ma tu sinh)
        public static bool Them(NhanVienDTO nv, out string loi)
        {
            if (!KiemTra(nv, out loi)) return false;
            try
            {
                nv.MaNV = NhanVienDAL.TaoMaMoi();
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
            return NhanVienDAL.ThemNhanVien(nv, out loi);
        }

        // 2. SUA NHAN VIEN
        public static bool CapNhat(NhanVienDTO nv, out string loi)
        {
            if (string.IsNullOrEmpty(nv.MaNV))
            {
                loi = "Vui lòng chọn nhân viên cần sửa.";
                return false;
            }
            if (!KiemTra(nv, out loi)) return false;

            // khong cho tu cho minh nghi viec (tai khoan dang dang nhap gan voi nhan vien nay)
            if (!nv.TrangThai && nv.MaNV == TaiKhoanBUS.TaiKhoanHienTai?.MaNV)
            {
                loi = "Không thể cho nghỉ việc nhân viên đang đăng nhập.";
                return false;
            }
            return NhanVienDAL.CapNhatNhanVien(nv, out loi);
        }

        // 3. XOA NHAN VIEN
        public static bool Xoa(string maNV, out string loi)
        {
            loi = "";
            if (string.IsNullOrEmpty(maNV))
            {
                loi = "Vui lòng chọn nhân viên cần xóa.";
                return false;
            }
            return NhanVienDAL.XoaNhanVien(maNV, out loi);
        }

        private static bool KiemTra(NhanVienDTO nv, out string loi)
        {
            loi = "";
            nv.HoTen = (nv.HoTen ?? "").Trim();
            nv.SoDienThoai = string.IsNullOrWhiteSpace(nv.SoDienThoai) ? null : nv.SoDienThoai.Trim();
            nv.DiaChi = string.IsNullOrWhiteSpace(nv.DiaChi) ? null : nv.DiaChi.Trim();

            if (nv.HoTen == "")
                loi = "Họ tên không được để trống.";
            else if (nv.SoDienThoai != null && !Regex.IsMatch(nv.SoDienThoai, @"^0\d{9}$"))
                loi = "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng 0.";
            else if (nv.NgaySinh.HasValue && nv.NgaySinh.Value.AddYears(16) > DateTime.Today)
                loi = "Ngày sinh không hợp lệ: nhân viên phải đủ 16 tuổi.";
            else if (nv.NgayVaoLam.Date > DateTime.Today)
                loi = "Ngày vào làm không được sau ngày hôm nay.";
            else if (Array.IndexOf(DanhSachChucVu, nv.ChucVu) < 0)
                loi = "Vui lòng chọn chức vụ.";
            else if (Array.IndexOf(DanhSachCa, nv.CaLamViec) < 0)
                loi = "Vui lòng chọn ca làm việc.";

            return loi == "";
        }
    }
}
