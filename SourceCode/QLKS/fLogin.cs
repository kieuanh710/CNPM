using System;
using System.Data;
using System.Windows.Forms;
using DAO;
using BUS;
using DTO;

namespace QLKS
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            fMain l = new fMain();
            this.Hide();
            l.ShowDialog();
            this.Show();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Bạn chưa điền tên đăng nhập!", "Lỗi!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa điền tên mật khẩu!", "Lỗi!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                string userName = textBoxUsername.Text;
                string passWord = textBoxPassword.Text;

                LoginBUS lgBUS = new LoginBUS();
                AccountDTO acDTO = lgBUS.Login(userName, passWord);


                if (acDTO != null)
                {
                    AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                    MessageBox.Show("Đăng nhập thành công! Chào mừng " + acDTO.HoTen, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fHome m = new fHome(loginAccount);
                    textBoxUsername.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
                    this.Hide();
                    m.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                }

            }
        }

       
    }
}
