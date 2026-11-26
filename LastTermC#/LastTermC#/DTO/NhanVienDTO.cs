using System;

namespace GS25Management.DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string? GioiTinh { get; set; }           // "Nam" / "Nữ"
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? ChucVu { get; set; }
        public string? CaLamViec { get; set; }          // "Ca sáng" / "Ca chiều" / "Ca tối" / "Hành chính"
        public DateTime NgayVaoLam { get; set; } = DateTime.Today;
        public bool TrangThai { get; set; } = true;     // true: dang lam viec, false: nghi viec
    }
}
