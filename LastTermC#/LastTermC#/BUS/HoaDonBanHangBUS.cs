
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GS25Management.DTO;
using GS25Management.DAL;

namespace GS25Management.BUS
{
    public class HoaDonBanHangBUS
    {
        public static bool LapHoaDon(
            HoaDonBanHangDTO hoaDon,
            List<ChiTietHoaDonDTO> chiTietList,
            List<string> danhSachMaGiamGia,
            out string loi)
        {
            loi = "";

            try
            {
                
                if (hoaDon == null)
                {
                    loi = "Thông tin hóa đơn không hợp lệ.";
                    return false;
                }

                if (chiTietList == null || chiTietList.Count == 0)
                {
                    loi = "Hóa đơn phải có ít nhất một sản phẩm.";
                    return false;
                }

                if (chiTietList.Any(ct => ct.SoLuong <= 0))
                {
                    loi = "Số lượng sản phẩm phải lớn hơn 0.";
                    return false;
                }

                if (chiTietList.Any(ct =>
                    ct.DonGia < 0 ||
                    ct.GiamGiaSanPham < 0 ||
                    ct.GiamGiaSanPham > ct.DonGia))
                {
                    loi = "Thông tin giá hoặc giảm giá sản phẩm không hợp lệ.";
                    return false;
                }

                // tinh tong tien hang truoc khi giam gia
                decimal tongTien = chiTietList.Sum(ct => ct.ThanhTien);

                // kiem tra va tinh tien giam gia
                decimal tongTienGiam = 0;
                List<GiamGiaDTO> giamGiaList = new List<GiamGiaDTO>();

                if (danhSachMaGiamGia != null)
                {
                    if (danhSachMaGiamGia.Distinct().Count()
                        != danhSachMaGiamGia.Count)
                    {
                        loi = "Không được sử dụng trùng mã giảm giá.";
                        return false;
                    }

                    foreach (string ma in danhSachMaGiamGia)
                    {
                        if (string.IsNullOrWhiteSpace(ma))
                        {
                            loi = "Mã giảm giá không hợp lệ.";
                            return false;
                        }

                        // lay thong tin ma giam gia tu DAL
                        MaGiamGiaDTO maGG = MaGiamGiaDAL.LayMaGiamGia(ma);

                        if (maGG == null)
                        {
                            loi = $"Mã giảm giá '{ma}' không tồn tại.";
                            return false;
                        }

                        // kiem tra trang thai ma giam gia
                        if (maGG.TrangThai != "Hoạt động")
                        {
                            loi = $"Mã giảm giá '{ma}' hiện không hoạt động.";
                            return false;
                        }

                        // kiem tra han su dung cua ma giam gia
                        DateTime hienTai = DateTime.Now;

                        if (hienTai < maGG.NgayBatDau ||
                            hienTai > maGG.NgayKetThuc)
                        {
                            loi = $"Mã giảm giá '{ma}' đã hết hạn hoặc chưa đến thời gian sử dụng.";
                            return false;
                        }

                        // kiem tra so luong su dung cua ma giam gia
                        if (maGG.SoLuong <= 0)
                        {
                            loi = $"Mã giảm giá '{ma}' đã hết lượt sử dụng.";
                            return false;
                        }

                        // tinh tien giam gia tuong ung voi ma giam gia
                        decimal tienGiam = 0;

                        if (maGG.LoaiGiamGia == "PhanTram")
                        {
                            if (maGG.GiaTriGiam <= 0 ||
                                maGG.GiaTriGiam > 100)
                            {
                                loi = $"Giá trị giảm của mã '{ma}' không hợp lệ.";
                                return false;
                            }

                            tienGiam = tongTien * maGG.GiaTriGiam / 100;
                        }
                        else if (maGG.LoaiGiamGia == "TienMat")
                        {
                            if (maGG.GiaTriGiam <= 0)
                            {
                                loi = $"Giá trị giảm của mã '{ma}' không hợp lệ.";
                                return false;
                            }

                            tienGiam = maGG.GiaTriGiam;
                        }
                        else
                        {
                            loi = $"Loại giảm giá của mã '{ma}' không hợp lệ.";
                            return false;
                        }

                        // Không để tổng tiền giảm vượt quá tiền hàng
                        decimal tienConLai = tongTien - tongTienGiam;
                        tienGiam = Math.Min(
                            tienGiam,
                            tongTien - tongTienGiam);

                        tongTienGiam += tienGiam;

                        // Thêm mã giảm giá vào danh sách
                        giamGiaList.Add(new GiamGiaDTO(
                            0, ma, tienGiam));
                    }
                }

                // Bước 3: Gán thông tin tiền vào hóa đơn
                hoaDon.TongTien = tongTien;
                hoaDon.TienGiam = tongTienGiam;
                hoaDon.ThanhTien = tongTien - tongTienGiam;

                if (hoaDon.NgayLap == default)
                    hoaDon.NgayLap = DateTime.Now;

                if (string.IsNullOrEmpty(hoaDon.TrangThai))
                    hoaDon.TrangThai = "Đã thanh toán";

                // Bước 4: Gọi DAL lập hóa đơn
                HoaDonBanHangDAL.LapHoaDon(
                    hoaDon,
                    chiTietList,
                    giamGiaList,
                    out loi);

                return string.IsNullOrEmpty(loi);
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }

        // 2. TRA CUU HOA DON
        public static DataTable TraCuuHoaDon(string tuKhoa)
        {
            return HoaDonBanHangDAL.TraCuuHoaDon(tuKhoa);
        }

        // 3. XOA HOA DON THONG THUONG
        public static bool XoaHoaDon(int maHoaDon, out string loi)
        {
            if (maHoaDon <= 0)
            {
                loi = "Mã hóa đơn không hợp lệ.";
                return false;
            }

            return HoaDonBanHangDAL.XoaHoaDon(
                maHoaDon, out loi);
        }

        // 4. XOA HOA DON VA HOAN HANG
        public static bool XoaHoaDonHoanHang(
            int maHoaDon, out string loi)
        {
            if (maHoaDon <= 0)
            {
                loi = "Mã hóa đơn không hợp lệ.";
                return false;
            }

            return HoaDonBanHangDAL.XoaHoaDonHoanHang(
                maHoaDon, out loi);
        }
    }
}
