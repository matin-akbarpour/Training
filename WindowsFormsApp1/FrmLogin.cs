using Gateway.HttpRequestHelper;
using Gateway.Models;
using System.Windows.Forms;


namespace WindowsFormsApp1
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
                MessageBox.Show("خطا");
            }
        }

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                var user = new
                {
                    Username = "mtnicl_core",
                    Password = "123456"
                };
                errorProvider1.Clear();

                if (FrmLoginControl())
                {
                    return;
                }

                //var user = new
                //{
                //    Username = txtUserName.Text,
                //    Password = txtPassword.Text
                //};

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
                 //   FrmLoginControl();
                }
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private bool FrmLoginControl()
        {
            bool Error = false;
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

            //if (!(string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text)))
            //    MessageBox.Show("نام کاربری یا رمز عبور اشتباه می باشد");
            return Error;
        }

        private void btnRefuse_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
