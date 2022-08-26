using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLKS
{

    public partial class fCheckout : Form
    {
        BindingSource BillList = new BindingSource();
        public fCheckout()
        {
            InitializeComponent();
            LoadCheckOut();
        }
        #region methods
        void LoadCheckOut()
        { 
            dataGridView1.DataSource = BillList;
            LoadListCheckOut();
            AddCheckOutBinding();

        }
        //load danh sách hóa đơn

        void AddCheckOutBinding()
        {
            txbTen.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            txbMaHD.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            txbMaPhong.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "MaPhong", true, DataSourceUpdateMode.Never));
            numSLK.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "SoKhach", true, DataSourceUpdateMode.Never));
            txbSoNgayThue.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "SoNgayThue", true, DataSourceUpdateMode.Never));
            numDonGia.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
            numHeSo.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "HeSo", true, DataSourceUpdateMode.Never));
            txbThanhTien.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ThanhTien", true, DataSourceUpdateMode.Never));
            dateThue.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "NgayBDThue", true, DataSourceUpdateMode.Never));
            numPhuThu.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "PhuThu", true, DataSourceUpdateMode.Never));
        }


        void LoadListCheckOut()
        {
            BillList.DataSource = CheckOutDAO.Instance.GetCheckOutList();

        }
        #endregion

        void DeleteCheckOut(string MaHD)
        {
            if (CheckOutDAO.Instance.DeteleCheckOut(MaHD))
            {
                MessageBox.Show("Thanh toán thành công");
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại");
            }
            LoadListCheckOut();

        }

        #region events

        private void fCheckout_Load(object sender, System.EventArgs e)
        {
            this.Size = this.MaximumSize = MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        private void btnXem_Click(object sender, System.EventArgs e)
        {
        }
        #endregion

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, System.EventArgs e)
        {
            string MaHD = txbMaHD.Text;

            DeleteCheckOut(MaHD);
        }


        private void numHeSo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
