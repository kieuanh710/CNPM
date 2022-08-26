using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiPhongDTO
    {
        public LoaiPhongDTO()
        {

        }

        public LoaiPhongDTO(string maloaiphong, string tenloaiphong, string dongia)
        {
            this.MaLoaiPhong = maloaiphong;
            this.TenLoaiPhong = tenloaiphong;
            this.DonGia = dongia;
        }

        public LoaiPhongDTO(DataRow row)
        {
            this.MaLoaiPhong = row["MaLoaiPhong"].ToString();
            this.TenLoaiPhong = row["TenLoaiPhong"].ToString();
            this.DonGia = row["DonGia"].ToString();
        }

        private string maLoaiPhong;
        private string tenLoaiPhong;
        private string donGia;

        public string MaLoaiPhong
        {
            get
            {
                return maLoaiPhong;
            }
            set
            {
                maLoaiPhong = value;
            }
        }

        public string TenLoaiPhong
        {
            get
            {
                return tenLoaiPhong;
            }
            set
            {
                tenLoaiPhong = value;
            }
        }

        public string DonGia
        {
            get
            {
                return donGia;
            }
            set
            {
                donGia = value;
            }
        }


    }
}
