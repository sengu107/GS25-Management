using System;

namespace GS25Management.DTO
{
    public class TaiKhoanDTO
    {
        public string MaTK { get; set; } = "";
        public string TenDangNhap { get; set; } = "";
        public string MatKhauHash { get; set; } = "";
        public string VaiTro { get; set; } = "";       // "Admin" / "ThuNgan"
        public string? MaNV { get; set; }
        public string? HoTen { get; set; }              // ho ten nhan vien (JOIN NhanVien)
        public bool TrangThai { get; set; } = true;     // true: hoat dong, false: khoa
        public DateTime NgayTao { get; set; }

        public bool LaAdmin => VaiTro == "Admin";
    }
}
