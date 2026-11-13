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
        public string SoDienThoaiKhachHang { get; set; }  
        public decimal TongTien { get; set; }       
        public string MaGiamGia { get; set; }     
        public decimal TienGiam { get; set; }  
        public decimal ThanhTien { get; set; }     
        public string TrangThai { get; set; }    
        public string GhiChu { get; set; }

        public HoaDonBanHangDTO() { }

        public HoaDonBanHangDTO(int maHoaDon, DateTime ngayLap, int maNhanVien,
            string soDienThoaiKhachHang, decimal tongTien, string maGiamGia, decimal tienGiam, decimal thanhTien,
            string trangThai, string ghiChu)
        {
            MaHoaDon = maHoaDon;
            NgayLap = ngayLap;
            MaNhanVien = maNhanVien;
            SoDienThoaiKhachHang = soDienThoaiKhachHang;
            TongTien = tongTien;
            MaGiamGia = maGiamGia;
            TienGiam = tienGiam;
            ThanhTien = thanhTien;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
    }
}
