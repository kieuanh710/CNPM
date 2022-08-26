using System.Windows.Forms;
using DAO;

namespace QLKS
{
    public partial class fAccount : Form
    {
        BindingSource AccountList = new BindingSource();
        public fAccount()
        {
            InitializeComponent();
            LoadAC();
        }


        #region methods

        void LoadAC()
        {
            dgvAccount.DataSource = AccountList;
            LoadListAccount();
            AddAccountBinding();
        }
        void LoadListAccount()
        {
            AccountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AddAccountBinding()
        {
            txtUsername.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "TenDN", true, DataSourceUpdateMode.Never));
            txtFullname.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Email", true, DataSourceUpdateMode.Never));
            nudPower.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Quyen", true, DataSourceUpdateMode.Never));
        }

        void AddAccount(string tenDN, string hoten, string email, int quyen)
        {
            if(AccountDAO.Instance.InsertAccount(tenDN, hoten, email, quyen))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadListAccount(); 
        }


        void UpdateAccount (string tenDN, string hoten, string email, int quyen)
        {
            if (AccountDAO.Instance.UpdateAccount(tenDN, hoten, email, quyen))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            LoadListAccount();
        }

        void DeleteAccount(string tenDN)
        {
            if (AccountDAO.Instance.DeleteAccount(tenDN))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadListAccount();
        }
        #endregion

        #region events

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        
        private void btnShow_Click(object sender, System.EventArgs e)
        {

            LoadListAccount();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            string tenDN = txtUsername.Text;
            string email = txtEmail.Text;
            string hoten = txtFullname.Text;
            int quyen = (int)nudPower.Value;

            AddAccount(tenDN, hoten, email, quyen);
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            string tenDN = txtUsername.Text;

            DeleteAccount(tenDN);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            string tenDN = txtUsername.Text;
            string email = txtEmail.Text;
            string hoten = txtFullname.Text;
            int quyen = (int)nudPower.Value;

            UpdateAccount(tenDN, hoten, email, quyen);
        }


        #endregion


    }
}
