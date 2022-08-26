using System.Windows.Forms;
using System.Drawing;
using System;
using DAO;
using DTO;


namespace QLKS
{
    public partial class fSalesReport : Form
    {
        BindingSource List = new BindingSource();
        public fSalesReport()
        {
            InitializeComponent();
            LoadCheckOut();
        }
        #region methods
        void LoadCheckOut()
        {
            dataGridView1.DataSource = List;
            LoadListRP();
            AddRPBinding();

        }
        //load danh sách hóa đơn

        void AddRPBinding()
        {
            txbLoaiPhong.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "MaLoaiPhong", true, DataSourceUpdateMode.Never));
            txbThang.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "MaThang", true, DataSourceUpdateMode.Never));
            txbDoanhThu.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "DoanhThu", true, DataSourceUpdateMode.Never));
            txbTyLe.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TyLe", true, DataSourceUpdateMode.Never));

        }


        void LoadListRP()
        {
            List.DataSource = SalesReportDAO.Instance.GetListRP();
        }
        #endregion
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, System.EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, System.EventArgs e)
        {

        }

        private void fSalesReport_Load(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
