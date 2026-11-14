using System;
using System.Collections.Generic;
using System.Text;

namespace GS25Management.DTO
{
    public class HoaDonBanHangDTO
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }  
        public string SoDienThoaiKhachHang { get; set; }  // de null neu la khach vang lai, khong co so dien thoai
        public decimal TongTien { get; set; }          
        public decimal TienGiam { get; set; }  // convert tu ma giam gia sang tien giam gia
        public decimal ThanhTien { get; set; }     
        public string TrangThai { get; set; }    
        public string GhiChu { get; set; }

        public HoaDonBanHangDTO() { }

        public HoaDonBanHangDTO(int maHoaDon, DateTime ngayLap, int maNhanVien,
            string soDienThoaiKhachHang, decimal tongTien, decimal tienGiam, decimal thanhTien,
            string trangThai, string ghiChu)
        {
            MaHoaDon = maHoaDon;
            NgayLap = ngayLap;
            MaNhanVien = maNhanVien;
            SoDienThoaiKhachHang = soDienThoaiKhachHang;
            TongTien = tongTien;
            TienGiam = tienGiam;
            ThanhTien = thanhTien;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
    }
}
