using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class CheckOutDTO
    {
        public CheckOutDTO(string mahd, string mapt, DateTime ngaylaphd, int sokhach, int songaythue, int dongia, float heso, float thanhtien)
        {
            this.MaHD = mahd;
            this.MaPT = mapt;
            this.NgayLapHD = ngaylaphd;
            this.SoKhach = sokhach;
            this.SoNgayThue = songaythue;
            this.DonGia = dongia;
            this.HeSo = heso;
            this.ThanhTien = thanhtien;
        }

        public CheckOutDTO(DataRow row)
        {
            this.MaHD = (string)row["mahd"];
            this.MaPT = (string)row["mapt"];
            this.NgayLapHD = (DateTime)row["ngaylaphd"];
            this.SoKhach = (int)row["sokhach"];
            this.SoNgayThue = (int)row["songaythue"];
            this.DonGia = (int)row["dongia"];
            this.HeSo = (float)row["heso"];
            this.ThanhTien = (float)row["thanhtien"];


        }
        private string mahd;
        private string mapt;
        private string maphong;
        private DateTime ngaylaphd;
        private int sokhach;
        private int songaythue;
        private int dongia;
        private float heso;
        private float thanhtien;

        public string MaHD
        {
            get
            {
                return mahd;
            }
            set
            {
                mahd = value;
            }
        }
        public string MaPT
        {
            get
            {
                return mapt;
            }
            set
            {
                mapt = value;
            }
        }
        private string MaPhong
        {
            get
            {
                return maphong;
            }
            set
            {
                maphong = value;
            }
        }
        public DateTime NgayLapHD
        {
            get
            {
                return ngaylaphd;
            }
            set
            {
                ngaylaphd = value;
            }
        }
        public int SoKhach
        {
            get
            {
                return sokhach;
            }
            set
            {
                sokhach = value;
            }
        }
        public int SoNgayThue
        {
            get
            {
                return songaythue;
            }
            set
            {
                songaythue = value;
            }
        }
        public int DonGia
        {
            get
            {
                return dongia;
            }
            set
            {
                dongia = value;
            }
        }
        public float HeSo
        {
            get
            {
                return heso;
            }
            set
            {
                heso = value;
            }
        }
        public float ThanhTien
        {
            get
            {
                return thanhtien;
            }
            set
            {
                thanhtien = value;
            }
        }

    }
}
