using System.Data;
using GS25Management.DAL;

namespace GS25Management.BUS
{
    public class NhanVienBUS
    {
        public static DataTable TraCuu(string tuKhoa)
        {
            return NhanVienDAL.TraCuuNhanVien(tuKhoa);
        }
    }
}
