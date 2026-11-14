using System;

namespace GS25Management.DTO
{
    public class MaGiamGiaDTO
    {
        public string MaGiamGia { get; set; }
        public string TenMaGiamGia { get; set; }
        public string LoaiGiamGia { get; set; }
        public decimal GiaTriGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLuong { get; set; }
        public string TrangThai { get; set; }

        public MaGiamGiaDTO() { }

        public MaGiamGiaDTO(
            string maGiamGia,
            string tenMaGiamGia,
            string loaiGiamGia,
            decimal giaTriGiam,
            DateTime ngayBatDau,
            DateTime ngayKetThuc,
            int soLuong,
            string trangThai)
        {
            MaGiamGia = maGiamGia;
            TenMaGiamGia = tenMaGiamGia;
            LoaiGiamGia = loaiGiamGia;
            GiaTriGiam = giaTriGiam;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            SoLuong = soLuong;
            TrangThai = trangThai;
        }
    }
}