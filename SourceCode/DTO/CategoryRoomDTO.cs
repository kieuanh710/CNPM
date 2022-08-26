using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryRoomDTO
    {
        private int price;
        private string name;
        private int iD;

        public int Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }

        public CategoryRoomDTO(int id, string name, int price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;

        }
        public CategoryRoomDTO(DataRow row)
        {
            this.ID = (int)row["MaLoaiPhong"];
            this.Name = row["TenLoaiPhong"].ToString();
            this.Price = (int)row["DonGia"];
        }
    }
}
