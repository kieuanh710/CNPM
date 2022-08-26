using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        private string makh;
        private string malk;
        private string hoten;
        private string ngaysinh;
        private string sodt;
        private string cmnd;
        private string email;
        private string diachi;


        public CustomerDTO ()
        {

        }

        public CustomerDTO(string malk, string hoten, string ngaysinh, string sotd, string cmnd, string email, string diachi)
        {
            this.MaLK = malk;
            this.HoTen = hoten;
            this.NgaySinh = ngaysinh;
            this.SoDT = sotd;
            this.CMND = cmnd;
            this.Email = email;
            this.DiaChi = diachi;
        }

        public string MaKH
        {
            get
            {
                return makh;
            }
            set
            {
                makh = value;
            }
        }
        public string MaLK
        {
            get
            {
                return malk;
            }
            set
            {
                malk = value;
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

        public string NgaySinh
        {
            get
            {
                return ngaysinh;
            }
            set
            {
                ngaysinh = value;
            }
        }

        public string SoDT
        {
            get
            {
                return sodt;
            }
            set
            {
                sodt = value;
            }
        }

        public string CMND
        {
            get
            {
                return cmnd;
            }
            set
            {
                cmnd = value;
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

        public string DiaChi
        {
            get
            {
                return diachi;
            }
            set
            {
                diachi = value;
            }
        }


    }
}
