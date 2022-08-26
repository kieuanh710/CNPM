using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class LoginDAO : DBconnect
    {
        public DataTable Login(string userName, string passWord)
        {
            string query = "select * from account where TenDN = '" + userName + "' and MatKhau = '" + passWord + "';";
            SqlDataAdapter data = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            data.Fill(result);
            return result;
        }

    }
}
