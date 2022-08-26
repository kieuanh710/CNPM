using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
namespace DAO
{
    public class CheckOutDAO : DataProvider
    {
        private static CheckOutDAO instance;

        public static CheckOutDAO Instance
        {
            get { if (instance == null) instance = new CheckOutDAO(); return CheckOutDAO.instance; }
            private set { CheckOutDAO.instance = value; }
        }


        private CheckOutDAO() { }

        public DataTable GetCheckOutList()
        {

            string query = "SELECT HOADON.MaHD, HOADON.MaPT, HOADON.SoKhach,  HOADON.HeSo, HOADON.DonGia, (DonGia * HeSo) AS PhuThu , (DonGia * HeSo + DonGia * SoNgayThue) AS ThanhTien, HOADON.SoNgayThue , PHIEUTHUE.MaPhong, PHIEUTHUE.NgayBDThue, KHACHHANG.HoTen" +
            " FROM HOADON INNER JOIN PHIEUTHUE ON HOADON.MaPT = PHIEUTHUE.MaPT  " +
            "INNER JOIN KHACHHANG ON KHACHHANG.MaKH = HOADON.MaKH";
            return DataProvider.Instance.ExecuteQuery(query);

            // List<CheckOutDTO> roomList = new List<CheckOutDTO>();
            // DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetBill");    
            // return roomList;
        }

        public bool DeteleCheckOut(string MaHD)
        {
            string query = string.Format("delete HOADON where MaHD = N'{0}'", MaHD);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}