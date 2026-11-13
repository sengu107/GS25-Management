using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using GS25Management.DTO;

namespace GS25Management.DAL
{
    public class HoaDonBanHangDAL
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["GS25DB"].ConnectionString;
        public static void LapHoaDon(HoaDonBanHangDTO hoaDon, List<ChiTietHoaDonDTO> chiTietList, out string loi)
        {
            loi = "";
            using(MySqlConnection conn =new MySqlConnection(connectionString))
            {
                conn.Open();

            }   
        }


    }
}
