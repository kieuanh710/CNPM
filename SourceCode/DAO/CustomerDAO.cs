using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CustomerDAO : DataProvider
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            private set { CustomerDAO.instance = value; }
        }


        private CustomerDAO(DataRow item) { }

        public CustomerDAO() { }
        public DataTable GetListCustomer()
        {
            string query = "select *from KHACHHANG";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateCustomer(string makh, string malk, string hoten, string ngaysinh, string sodt, string cmnd, string email, string diachi)
        {
            string query = string.Format("UPDATE KHACHHANG SET MaLK = N'{1}', HoTen = N'{2}', NgaySinh = N'{3}', SoDT = N'{4}', CMND = N'{5}', Email = N'{6}', DiaChi = N'{7}' WHERE MaKH = N'{0}'", makh, malk, hoten, sodt, cmnd, email, diachi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
