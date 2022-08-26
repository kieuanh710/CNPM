using DTO;
using System;
using System.Windows.Forms;

namespace QLKS
{
    public partial class fHome : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount.Quyen); }
        }
        public fHome(AccountDTO acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }

        #region Method
        void ChangeAccount(int quyen)
        {
            tàiKhoảnQuảnLýToolStripMenuItem.Enabled = quyen == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.TenDN + ")";

        }
        #endregion

        #region events
        private void fHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            Application.Exit();

        }

        fAccount fa;
        fChangeInfor fci;
        fCheckout fc;
        fRentRom TP;
        fmnRoom qlp;
        fCustomer fct;
        fSalesReport bcds;

        private void tàiKhoảnQuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            if (this.fa is null || this.fa.IsDisposed)
            {
                this.fa = new fAccount();
                this.fa.MdiParent = this;
                this.fa.Show();
            }
            else
            {
                this.fa.Select();
            }


        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            if (this.fci is null || this.fci.IsDisposed)
            {
                this.fci = new fChangeInfor(LoginAccount);
                this.fci.MdiParent = this;
                this.fci.Show();
            }
            else
            {
                this.fci.Select();
            }
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            if (this.fc is null || this.fc.IsDisposed)
            {
                this.fc = new fCheckout();
                this.fc.MdiParent = this;
                this.fc.Show();
            }
            else
            {
                this.fc.Select();
            }
        }

        private void thuêPhòngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            if (this.TP is null || this.TP.IsDisposed)
            {
                this.TP = new fRentRom();
                this.TP.MdiParent = this;
                this.TP.Show();
            }
            else
            {
                this.TP.Select();
            }
        }
        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            if (this.qlp is null || this.qlp.IsDisposed)
            {
                this.qlp = new fmnRoom();
                this.qlp.MdiParent = this;
                this.qlp.Show();
            }
            else
            {
                this.qlp.Select();
            }
        }
        private void quảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            if (this.fct is null || this.fct.IsDisposed)
            {
                this.fct = new fCustomer();
                this.fct.MdiParent = this;
                this.fct.Show();
            }
            else
            {
                this.fct.Select();
            }
        }
        private void fHome_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            if (this.ActiveMdiChild.Tag == null)
            {
                TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                tp.Tag = this.ActiveMdiChild;
                tp.Parent = this.tabMain;
                this.tabMain.SelectedTab = tp;
                this.ActiveMdiChild.Tag = tp;
                this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTab != null && this.tabMain.SelectedTab != null)
            {
                (this.tabMain.SelectedTab.Tag as Form).Select();
            }
        }

        private void báoCáoDoanhSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            if (this.bcds is null || this.bcds.IsDisposed)
            {
                this.bcds = new fSalesReport();
                this.bcds.MdiParent = this;
                this.bcds.Show();
            }
            else
            {
                this.bcds.Select();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có thật sự muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dlr == DialogResult.OK)
            {
                fMain l = new fMain();
                this.Hide();
                l.ShowDialog();
                this.Show();
            }

        }

        #endregion

        
    }

}
