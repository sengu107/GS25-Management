using System;
using System.Collections.Generic;
using System.Text;

namespace GS25Management.DTO
{
    public class ChiTietHoaDonDTO
    {
        public int MaChiTiet { get; set; } // ma chi tiet hoa don, tu sinh
        public int MaHoaDon { get; set; } // ma hoa don, lien ket voi HoaDonBanHangDTO
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }   
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }     // so tien truoc khi khuyen mai san pham    
        public decimal GiamGiaSanPham { get; set; } // so tien giam gia tren san pham (khuyen mai san pham)
        public decimal DonGiaSauGiam => DonGia - GiamGiaSanPham;
        public decimal ThanhTien => SoLuong * DonGiaSauGiam;

        public ChiTietHoaDonDTO() { }

        public ChiTietHoaDonDTO(int maSanPham, string tenSanPham, int soLuong, decimal donGia, decimal giamGiaSanPham = 0)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGiaSanPham = giamGiaSanPham;
        }
    }
}
