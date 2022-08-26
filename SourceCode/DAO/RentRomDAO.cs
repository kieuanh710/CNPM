using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class RentRomDAO : DBconnect
    {
        public DataTable LoadLoaiPhong()
        {
            string query = "select * from hr.loaiphong";
            SqlDataAdapter data = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            data.Fill(result);
            return result;
        }

        public DataTable SoKhachToiDa()
        {
            string query = "select * from THAMSO";
            SqlDataAdapter data = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            data.Fill(result);
            return result;
        }

        public DataTable LoadPhong(string maloaiphong)
        {
            string query = "select * from hr.phong where MaLoaiPhong = '" + maloaiphong + "' and Tinhtrang = N'Trống';";
            SqlDataAdapter data = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            data.Fill(result);
            return result;
        }

        public DataTable LoadLoaiKhach()
        {
            string query = "select * from loaikhach";
            SqlDataAdapter data = new SqlDataAdapter(query, _conn);
            DataTable result = new DataTable();
            data.Fill(result);
            return result;
        }

        public string AutoIdKH()
        {
            string sql = "SELECT MaKH FROM KHACHHANG";
            // Lấy DataTable từ câu truy vấn truyền vào (Apdapter Fill DataTable)
            SqlDataAdapter data = new SqlDataAdapter(sql, _conn);
            DataTable tb = new DataTable();
            data.Fill(tb);
            int[] arrCode = new int[tb.Rows.Count];
            int code;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                code = int.Parse(tb.Rows[i]["MaKH"].ToString().Remove(0, 2));
                arrCode[i] = code;
            }
            code = arrCode.Max() + 1;
            if (code >= 0 & code < 10)
            {
                string nextID = "KH00" + code;
                return nextID;
            }
            if (code > 9 & code < 100)
            {
                string nextID = "KH0" + code;
                return nextID;
            }
            else
            {
                string nextID = "KH" + code;
                return nextID;
            }
        }

        public string AutoIdPT()
        {
            string sql = "SELECT MaPT FROM PHIEUTHUE";
            // Lấy DataTable từ câu truy vấn truyền vào (Apdapter Fill DataTable)
            SqlDataAdapter data = new SqlDataAdapter(sql, _conn);
            DataTable tb = new DataTable();
            data.Fill(tb);
            int[] arrCode = new int[tb.Rows.Count];
            int code;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                code = int.Parse(tb.Rows[i]["MaPT"].ToString().Remove(0, 2));
                arrCode[i] = code;
            }
            code = arrCode.Max() + 1;
            if (code >= 0 & code < 10)
            {
                string nextID = "PT00" + code;
                return nextID;
            }
            if (code > 9 & code < 100)
            {
                string nextID = "PT0" + code;
                return nextID;
            }
            else
            {
                string nextID = "PT" + code;
                return nextID;
            }
        }

        public string AutoIdCTPT()
        {
            string sql = "SELECT MaCTPT from CTPT";
            // Lấy DataTable từ câu truy vấn truyền vào (Apdapter Fill DataTable)
            SqlDataAdapter data = new SqlDataAdapter(sql, _conn);
            DataTable tb = new DataTable();
            data.Fill(tb);
            int[] arrCode = new int[tb.Rows.Count];
            int code;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                code = int.Parse(tb.Rows[i]["MaCTPT"].ToString().Remove(0, 2));
                arrCode[i] = code;
            }
            code = arrCode.Max() + 1;
            if (code >= 0 & code < 10)
            {
                string nextID = "CT00" + code;
                return nextID;
            }
            if (code > 9 & code < 100)
            {
                string nextID = "CT0" + code;
                return nextID;
            }
            else
            {
                string nextID = "CT" + code;
                return nextID;
            }


        }

        public bool InsertPhieuThue(string mapt, string maphong, string ngaybdthue)
        {
            try
            {

                _conn.Open();
                string SQL = string.Format("INSERT INTO PHIEUTHUE (MaPT, MaPhong, NgayBDThue) VALUES ( '" + mapt + "','" + maphong + "', '" + ngaybdthue + "'); ");
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string qq = "update Phong set TinhTrang = N'có người' where MaPhong = '" + maphong + "';";
                    SqlCommand cmd1 = new SqlCommand(qq, _conn);
                    if (cmd1.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }
        public bool InsertKH(CustomerDTO ctmDTO)
        {
            try
            {
                _conn.Open();
                ctmDTO.MaKH = AutoIdKH();
                string SQL = string.Format("INSERT INTO KHACHHANG (MaKH, MaLK, HoTen, NgaySinh, SoDT, CMND, Email, DiaChi) VALUES ('{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', N'{7}');", ctmDTO.MaKH, ctmDTO.MaLK, ctmDTO.HoTen, ctmDTO.NgaySinh, ctmDTO.SoDT, ctmDTO.CMND, ctmDTO.Email, ctmDTO.DiaChi);
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        public bool InserCTPT(string maCTPT, string mapt, string makh)
        {
            try
            {
                _conn.Open();
                string SQL = string.Format("INSERT INTO CTPT (MaCTPT, MaPT, MaKH) VALUES ('{0}', '{1}', '{2}')", maCTPT, mapt, makh);
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }


    }
}
