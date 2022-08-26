using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LoginBUS
    {
        LoginDAO lgDAO = new LoginDAO();
        

        public AccountDTO Login(string username, string password)
        {
            
            DataTable result = lgDAO.Login(username, password);
            if (result.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow account = result.Rows[0];
                AccountDTO acDTO = new AccountDTO(account);
                return acDTO;
            }
           
        }
    }
}
