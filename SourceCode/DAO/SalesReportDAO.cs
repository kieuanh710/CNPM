
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
namespace DAO
{
    public class SalesReportDAO : DataProvider
    {
        private static SalesReportDAO instance;

        public static SalesReportDAO Instance
        {
            get { if (instance == null) instance = new SalesReportDAO(); return SalesReportDAO.instance; }
            private set { SalesReportDAO.instance = value; }
        }


        private SalesReportDAO() { }

        public DataTable GetListRP()
        {
            string query = "select *  from CTBCDS INNER JOIN HOADON ON HOADON.MaHD = CTBCDS.MaHD";
            return DataProvider.Instance.ExecuteQuery(query);

        }
    }
}
