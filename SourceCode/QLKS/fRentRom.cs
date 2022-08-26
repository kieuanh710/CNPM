using BUS;
using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLKS
{
    public partial class fRentRom : Form
    {

        RentRomBUS rrBUS = new RentRomBUS();
        RentRomDAO rrDAO = new RentRomDAO();
        List<CustomerDTO> listCustomerDTO = new List<CustomerDTO>();
        public fRentRom()
        {
            InitializeComponent();
            this.btnLoaiPhong_Load();
            this.txtKhachToiDa_Load();
            this.btnLoaiKhach_Load();
            this.dgvKhachHang_Load();
        }

        public void btnLoaiPhong_Load()
        {
            List<LoaiPhongDTO> listlpDTO = rrBUS.LoadLoaiPhong();
            btnLoaiPhong.DataSource = listlpDTO;
            btnLoaiPhong.DisplayMember = "TenLoaiPhong";
            btnLoaiPhong.ValueMember = "MaLoaiPhong";
        }

        private void btnLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhongDTO lpDTO = btnLoaiPhong.SelectedItem as LoaiPhongDTO;
            DataTable LoadPhong = rrBUS.LoadPhong(lpDTO.MaLoaiPhong);
            txtDonGia.Text = lpDTO.DonGia;
            if (LoadPhong.Rows.Count != 0)
            {
                btnPhong.DataSource = LoadPhong;
                btnPhong.DisplayMember = "TenPhong";
                btnPhong.ValueMember = "MaPhong";
            }
            else
            {
                btnPhong.DataSource = null;
                btnPhong.DisplayMember = "";
                btnPhong.ValueMember = "";
                MessageBox.Show("Đã hết phòng trống!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        public void txtKhachToiDa_Load()
        {

            string KhachToiDa = rrBUS.SoKhachToiDa();
            txtKhachToiDa.Text = KhachToiDa;
        }

        public void btnLoaiKhach_Load()
        {
            DataTable data = rrBUS.LoadLoaiKhach();
            btnLoaiKhach.DataSource = data;
            btnLoaiKhach.DisplayMember = "TenLK";
            btnLoaiKhach.ValueMember = "MaLK";

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            CustomerDTO customerDTO = new CustomerDTO(btnLoaiKhach.SelectedValue.ToString(), txtTenKhachHang.Text, dtNgaySinh.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text, txtDiaChi.Text);
            txtTenKhachHang.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtCMND.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            if (listCustomerDTO.Count < Int32.Parse(txtKhachToiDa.Text))
            {
                listCustomerDTO.Add(customerDTO);
                dgvKhachHang_Load();
            }
            else
            {
                MessageBox.Show("Không thể vượt quá số khách tối đa!", "Lỗi!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }

        public void dgvKhachHang_Load()
        {
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = listCustomerDTO;
        }

        private void btnThuePhong_Click(object sender, EventArgs e)
        {
            string MaPT = rrDAO.AutoIdPT();
            bool iPT = rrDAO.InsertPhieuThue(MaPT, btnPhong.SelectedValue.ToString(), dtNgayBDThue.Text);
            if (iPT == true)
            {
                foreach (CustomerDTO ctDTO in listCustomerDTO)
                {
                    bool iKH = rrDAO.InsertKH(ctDTO);
                    if (iKH == true)
                    {
                        string maCTPT = rrDAO.AutoIdCTPT();
                        bool iCTPT = rrDAO.InserCTPT(maCTPT, MaPT, ctDTO.MaKH);
                        if (iCTPT == false)
                        {
                            MessageBox.Show("Không lưu được dữ liệu CTPT!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không lưu được dữ liệu khách hàng!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                MessageBox.Show("Thuê phòng thành công! Mã phiếu thuê " + MaPT, "Thông báo", MessageBoxButtons.OK);
                txtTenKhachHang.Text = string.Empty;
                txtSDT.Text = string.Empty;
                txtCMND.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtCMND.Text = string.Empty;
                dgvKhachHang.DataSource = null;
                listCustomerDTO.Clear();
                dgvKhachHang.DataSource = listCustomerDTO;


            }
            else
            {
                MessageBox.Show("Không lưu được phiếu thuê!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtCMND.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtCMND.Text = string.Empty;
            dgvKhachHang.DataSource = null;
            listCustomerDTO.Clear();
            dgvKhachHang.DataSource = listCustomerDTO;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
