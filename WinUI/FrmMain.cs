using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinUI
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
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
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
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
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
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
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
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
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
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Graphics g = CreateGraphics();
                Double startingPoint = (Width / 2) - (g.MeasureString(Text.Trim(), Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", Font).Width;
                String tmp = " ";
                Double tmpWidth = 0;

                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }

                Text = tmp + Text.Trim();
            }
            catch (Exception)
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }
    }
}
