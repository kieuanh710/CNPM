using DAO;
using System;
using System.Windows.Forms;

namespace QLKS
{
    public partial class fCustomer : Form
    {
        BindingSource CustomerList = new BindingSource();
        public fCustomer()
        {
            InitializeComponent();
            LoadCustomer();
        }
        #region Method
        void LoadCustomer()
        {
            dgvCustomer.DataSource = CustomerList;
            LoadListCustomer();
            AddAccountBinding();
        }
        void LoadListCustomer()
        {
            CustomerList.DataSource = CustomerDAO.Instance.GetListCustomer();
        }
        void AddAccountBinding()
        {
            txbMaKhach.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txbLoaiKhach.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "MaLK", true, DataSourceUpdateMode.Never));
            txbHoTen.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txbSoDT.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "SoDT", true, DataSourceUpdateMode.Never));
            txbCMND.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "CMND", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txbDiaChi.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
        }

        void UpdateCustomer(string makh, string malk, string hoten, string ngaysinh, string sodt, string cmnd, string email, string diachi)
        {
            if (CustomerDAO.Instance.UpdateCustomer(makh, malk, hoten, ngaysinh, sodt, cmnd, email, diachi))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            LoadListCustomer();
        }

        #endregion

        #region events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string makh = txbMaKhach.Text;
            string malk = txbLoaiKhach.Text;
            string hoten = txbHoTen.Text;
            string ngaysinh = dtpNgaySinh.Text;
            string sodt = txbSoDT.Text;
            string cmnd = txbCMND.Text;
            string email = txbEmail.Text;
            string diachi = txbDiaChi.Text;

            UpdateCustomer(makh, malk, hoten, ngaysinh, sodt, cmnd, email, diachi);
        }

        #endregion

    }
}
