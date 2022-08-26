using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DAO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
    public class AddData
    {
        private string connectionSTR = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True";
        

        public void ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    
}
