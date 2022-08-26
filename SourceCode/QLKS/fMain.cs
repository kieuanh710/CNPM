using System;
using System.Windows.Forms;

namespace QLKS
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            fLogin l = new fLogin();
            this.Hide();
            l.ShowDialog();
            this.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            fRegister r = new fRegister();
            this.Hide();
            r.ShowDialog();
        }

        private void main_chinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
