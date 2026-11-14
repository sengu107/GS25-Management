using System;
using System.Collections.Generic;
using System.Text;

namespace GS25Management.DTO
{
    public class GiamGiaDTO
    {
        public int MaHoaDon { get; set; }
        public string MaGiamGia { get; set; }
        public decimal TienGiam { get; set; }

        public GiamGiaDTO() { }

        public GiamGiaDTO(int maHoaDon, string maGiamGia, decimal tienGiam)
        {
            MaHoaDon = maHoaDon;
            MaGiamGia = maGiamGia;
            TienGiam = tienGiam;
        }
    }
}
