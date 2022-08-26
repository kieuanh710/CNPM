using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        public AccountDTO(string tenDN, string hoten, string email, string matkhau, int quyen)
        {
            this.TenDN = tenDN;
            this.HoTen = hoten;
            this.Email = email;
            this.MatKhau = matkhau;
            this.Quyen = quyen;
        }

        public AccountDTO(DataRow row)
        {
            this.TenDN = row["tenDN"].ToString();
            this.HoTen = row["hoten"].ToString();
            this.Email = row["email"].ToString();
            this.MatKhau = row["matkhau"].ToString();
            this.Quyen = (int)row["quyen"];

           // this.Quyen = (int)row["quyen"];
        }

        private string tenDN;
        private string hoten;
        private string email;
        private string matkhau;
        private int quyen;



        public string TenDN
        {
            get
            {
                return tenDN;
            }
            set
            {
                tenDN = value;
            }
        }

        public string HoTen
        {
            get
            {
                return hoten;
            }
            set
            {
                hoten = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matkhau;
            }
            set
            {
                matkhau = value;
            }
        }

        public int Quyen
        {
            get
            {
                return quyen;
            }
            set
            {
                quyen = value;
            }
        }
    }
}
