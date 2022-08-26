using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SalesReportDTO
    {
        public SalesReportDTO(string mactbcds, string mahd, string maloaiphong, string mathang, int doanhthu, float tyle)
        {
            this.MaCTBCDS = mactbcds;
            this.MaHD = mahd;
            this.MaLoaiPhong = maloaiphong;
            this.MaThang = mathang;
            this.DoanhThu = doanhthu;
            this.TyLe = tyle;

        }

        public SalesReportDTO(DataRow row)
        {
            this.MaCTBCDS = (string)row["mactbcds"];
            this.MaHD = (string)row["mahd"];
            this.MaLoaiPhong = (string)row["maloaiphong"];
            this.MaThang = (string)row["mathang"];
            this.DoanhThu = (int)row["doanhthu"];
            this.TyLe = (float)row["tyle"];

        }
        private string mactbcds;
        private string mahd;
        private string maloaiphong;
        private string mathang;
        private int doanhthu;
        private float tyle;

        public string MaCTBCDS
        {
            get
            {
                return mactbcds;
            }
            set
            {
                mactbcds = value;
            }
        }
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
        public string MaLoaiPhong
        {
            get
            {
                return maloaiphong;
            }
            set
            {
                maloaiphong = value;
            }
        }
        public string MaThang
        {
            get
            {
                return mathang;
            }
            set
            {
                mathang = value;
            }
        }
        public int DoanhThu
        {
            get
            {
                return doanhthu;
            }
            set
            {
                doanhthu = value;
            }
        }
        public float TyLe
        {
            get
            {
                return tyle;
            }
            set
            {
                tyle = value;
            }
        }

    }
}
