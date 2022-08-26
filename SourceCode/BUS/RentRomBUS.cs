using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class RentRomBUS
    {
        RentRomDAO rrDAO = new RentRomDAO();

        public List<LoaiPhongDTO> LoadLoaiPhong()
        {
            DataTable data = rrDAO.LoadLoaiPhong();
            if (data.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<LoaiPhongDTO> listLoaiPhong = new List<LoaiPhongDTO>();
                foreach (DataRow item in data.Rows)
                {
                    LoaiPhongDTO LoaiPhong = new LoaiPhongDTO(item);
                    listLoaiPhong.Add(LoaiPhong);
                }

                return listLoaiPhong;
            }
        }

        public string SoKhachToiDa()
        {
            DataTable data = rrDAO.SoKhachToiDa();
            return data.Rows[0][0].ToString();
        }

        public DataTable LoadPhong(string loaiphong)
        {
            DataTable data = rrDAO.LoadPhong(loaiphong);
            return data;
        }

        public DataTable LoadLoaiKhach()
        {
            DataTable data = rrDAO.LoadLoaiKhach();
            return data;
        }

        /*public string insertPhieuThue(string maphong, string ngaybdthue)
        {
            return rrDAO.InsertPhieuThue(maphong, ngaybdthue);
        }*/
    }

}
