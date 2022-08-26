using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace QLKS
{
    public partial class fChangeInfor : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fChangeInfor(AccountDTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(AccountDTO acc)
        {
            txtUsername.Text = LoginAccount.TenDN;
            txtFullname.Text = LoginAccount.HoTen;
            txtEmail.Text = LoginAccount.Email;
        }
        void UpdateAccount()
        {
            string tenDN = txtUsername.Text;
            string hoten = txtFullname.Text;
            string email = txtEmail.Text;
            string matkhau = txtPassword.Text;
            string matkhaumoi = txtNewPass.Text;
            string nhaplai = txtPasswordAgain.Text;

            if (!matkhaumoi.Equals(nhaplai))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới.");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccountID(tenDN, hoten, email, matkhau, matkhaumoi))
                {
                    MessageBox.Show("Cập nhật thành công.");
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu.");
                }

            }
        }

        private void btnRepass_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
    }
}
