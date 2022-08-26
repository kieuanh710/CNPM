using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class AccountDAO : DataProvider
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance;}
            private set { AccountDAO.instance = value; }
        }

        
        private AccountDAO() { }

        public DataTable GetListAccount()
        {
            string query = "select TenDN, HoTen, Email, Quyen from ACCOUNT";
            return DataProvider.Instance.ExecuteQuery(query);
            
        }

        public bool InsertAccount (string tenDN, string hoten, string email, int quyen)
        {
            string query = string.Format("INSERT ACCOUNT (TenDN, HoTen, Email, Quyen) VALUES (N'{0}', N'{1}', N'{2}', {3})", tenDN, hoten, email, quyen);   
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string tenDN, string hoten, string email, int quyen)
        {
            string query = string.Format("UPDATE ACCOUNT SET HoTen = N'{1}', Email = N'{2}', Quyen = {3} WHERE TenDN = N'{0}'", tenDN, hoten, email, quyen);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string tenDN)
        {
            string query = string.Format("Delete account where TenDN = N'{0}'", tenDN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public AccountDTO GetAccountByUserName(string tenDN)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where TenDN = '" + tenDN + "'");

            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }

            return null;
        }

        public bool UpdateAccountID(string tenDN, string hoten, string email, string matkhau, string matkhaumoi)
        {
            string query = string.Format("UPDATE ACCOUNT SET HoTen = N'{1}', Email = N'{2}', matkhau = N'{3}', matkhaumoi = N'{4}' WHERE TenDN = N'{0}'", tenDN, hoten, email, matkhau, matkhaumoi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }

    
}
