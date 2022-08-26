using System;
using System.Windows.Forms;
using DAO;

namespace QLKS
{
    public partial class fRegister : Form
    {
        public fRegister()
        {
            InitializeComponent();

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Xác nhận đầy đủ thông tin
            if (txbEmail.Text == "" || txbFullName.Text == "" || txbPassWord.Text == "" || txbPassWordAgain.Text == "" || txbUserName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin");
            }
            //Xác nhận mật khẩu trùng
            else if (txbPassWord.Text != txbPassWordAgain.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu nhập lại chưa đúng!");
                txbPassWordAgain.Focus();
                txbPassWordAgain.SelectAll();

            }
            else if (txbEmail.Text.Contains("@"))
            {
                AddAccount();
                fLogin l = new fLogin();
                this.Hide();
                l.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Chưa đúng định dạng Email( @ ) ");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fMain l = new fMain();
            this.Hide();
            l.ShowDialog();
            this.Show();
        }

        void AddAccount()
        {
            string query = @"INSERT INTO ACCOUNT ( Email, HoTen,TenDN, MatKhau) VALUES (N'" + txbEmail.Text + @"',N'" + txbFullName.Text + @"',N'" + txbUserName.Text + @"',N'" + txbPassWord.Text + @"')";
            AddData data = new AddData();
            data.ExecuteQuery(query);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    class User
    {
        private string fullname, email, password, passwordAgain, userName;

        public User()
        {
            fullname = email = password = passwordAgain = userName = "";
        }
        public User(string name, string mail, string pWord, string pWordAgain, string loginName)
        {
            fullname = name;
            email = mail;
            password = pWord;
            passwordAgain = pWordAgain;
            userName = loginName;
        }

    }
}
