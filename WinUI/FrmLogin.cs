using Gateway.HttpRequestHelper;
using Gateway.Models;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace WinUI
{
    public partial class FrmLogin : Form
    {
        private readonly HttpRequest _httpRequest;
        public static string Token;

        public FrmLogin()
        {
            try
            {
                InitializeComponent();

                _httpRequest = new HttpRequest();
            }
            catch
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                //var user = new
                //{
                //    Username = "mtnicl_core",
                //    Password = "123456"
                //};

                errorProvider1.Clear();

                if (FrmLoginControl())
                {
                    return;
                }

                var user = new
                {
                    Username = txtUserName.Text,
                    Password = txtPassword.Text
                };

                var result = await _httpRequest.PostAction<FluentResultVm<LoginResponse>, object>("https://localhost:44332/Auth/LoginWithPassword", user);

                if (result.isSuccess)
                {
                    Token = result.value.tokens.accessToken;
                    FrmMain frmMain = new FrmMain();
                    Hide();
                    frmMain.Show();
                }
                else
                {
                    MessageBox.Show("نام کاربری یا رمز عبور اشتباه می باشد");
                }
            }
            catch
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private bool FrmLoginControl()
        {
            bool Error = false;

            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    errorProvider1.SetError(txtUserName, "لطفا نام کاربری را وارد کنید");
                    Error = true;
                }
                else
                    errorProvider1.SetError(txtUserName, null);

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, "لطفا رمز عبور را وارد کنید");
                    Error = true;
                }
                else
                    errorProvider1.SetError(txtPassword, null);
            }
            catch (System.Exception)
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
            return Error;
        }

        private void btnRefuse_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, System.EventArgs e)
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
