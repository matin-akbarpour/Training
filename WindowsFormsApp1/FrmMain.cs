using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private void msiAccountBalance_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAccountBalance frmAccountBalance = new FrmAccountBalance();
                frmAccountBalance.ShowDialog();
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private void msiProvidingInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProvidingInvoices frmProvidingInvoices = new FrmProvidingInvoices();
                frmProvidingInvoices.ShowDialog();
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private void msiSatnaPaya_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSatnaPaya frmSatnaPaya = new FrmSatnaPaya();
                frmSatnaPaya.ShowDialog();
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private void msiExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
