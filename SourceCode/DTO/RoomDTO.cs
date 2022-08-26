using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class RoomDTO
    {
        public RoomDTO(int id, string name, string status, int category)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.Category = category;
        }

        public RoomDTO(DataRow row)
        {
            this.ID = (int)row["MaPhong"];
            this.Name = row["TenPhong"].ToString();
            this.Status = row["TinhTrang"].ToString();
            this.Category = (int)row["MaLoaiPhong"];
            this.Note = row["GhiChu"].ToString();
        }

        private int category;
        private string note;
        private string status;
        private string name;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public string Note { get => note; set => note = value; }
        public int Category { get => category; set => category = value; }
    }
}
