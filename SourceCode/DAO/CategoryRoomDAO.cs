using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoryRoomDAO
    {
        private static CategoryRoomDAO instance;

        public static CategoryRoomDAO Instance
        {
            get { if (instance == null) instance = new CategoryRoomDAO(); return instance; }
            private set { instance = value; }
        }

        private CategoryRoomDAO() { }

        public List<CategoryRoomDTO> LoadCategoryRoomList()
        {
            List<CategoryRoomDTO> catroomList = new List<CategoryRoomDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetCategoryRoomList");
            foreach (DataRow item in data.Rows)
            {
                CategoryRoomDTO catroom = new CategoryRoomDTO(item);
                catroomList.Add(catroom);
            }
            return catroomList;
        }
        public List<CategoryRoomDTO> LoadCategoryRoomList1()
        {
            List<CategoryRoomDTO> catroomList = new List<CategoryRoomDTO>();
            string query = "select * from hr.LOAIPHONG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CategoryRoomDTO catroom = new CategoryRoomDTO(item);
                catroomList.Add(catroom);
            }
            return catroomList;
        }

    }
}
