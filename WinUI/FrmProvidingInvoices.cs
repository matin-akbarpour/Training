using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Gateway.HttpRequestHelper;
using Gateway.Models;

namespace WinUI
{
    public partial class FrmProvidingInvoices : Form
    {
        private readonly HttpRequest _httpRequest;
        private FluentResultVm<GetStatementByAccountNumberResponse> _result;

        public FrmProvidingInvoices()
        {
            try
            {
                InitializeComponent();

                _httpRequest = new HttpRequest();
                _httpRequest.Authorization(FrmLogin.Token);
            }
            catch
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if(FrmProvidingInvoicesControl())
                {
                    return;
                }
                var getStatementByAccountNumber = new
                {
                    AccountNumber = txtAccountNumber.Text,
                    FromDate = mskFromDate.Text,
                    ToDate = mskToDate.Text,
                    FromTime = mskFromTime.Text.Equals("  :  :  .") ? null : mskFromTime.Text,
                    ToTime = mskToTime.Text.Equals("  :  :  .") ? null : mskToTime.Text,
                    ResultCount = string.IsNullOrEmpty(txtResultCount.Text) ? 1000 : Convert.ToInt32(txtResultCount.Text),
                    //FirstResult = string.IsNullOrEmpty(txtFirstResult.Text) ? 0 : Convert.ToInt32(txtFirstResult.Text)
                };
                dgProvidingInvoices.DataSource = new List<GetStatementByAccountNumberResponse.ResultData2>();
                btnClear.Enabled = false;
                btnClose.Enabled = false;
                btnShow.Enabled = false;

                _result = await _httpRequest.PostAction<FluentResultVm<GetStatementByAccountNumberResponse>, object>("http://localhost:11248/api/EBankSepah/GetStatementByAccountNumber", getStatementByAccountNumber);

                if (_result.isSuccess)
                {
                    dgProvidingInvoices.DataSource =_result.value.ResultData;
                }
                btnClear.Enabled = true;
                btnClose.Enabled = true;
                btnShow.Enabled = true;


            }
            catch
            {
                if (_result.isSuccess)
                    MessageBox.Show(_result.value.Message);
                else
                    MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private bool FrmProvidingInvoicesControl()
        {
            bool Error = false;

            try
            {
                if (string.IsNullOrEmpty(txtAccountNumber.Text))
                {
                    errorProvider1.SetError(txtAccountNumber, "لطفا شماره حساب یا شبا را وارد کنید");
                    Error = true;
                }
                else
                    errorProvider1.SetError(txtAccountNumber, null);

                if (mskFromDate.Text.Equals("    /  /"))
                {
                    errorProvider1.SetError(mskFromDate, "لطفا تاریخ شروع را وارد کنید");
                    Error = true;
                }
                else
                    errorProvider1.SetError(mskFromDate, null);

                if (mskToDate.Text.Equals("    /  /"))
                {
                    errorProvider1.SetError(mskToDate, "لطفا تاریخ پایان را وارد کنید");
                    Error = true;
                }
                else
                    errorProvider1.SetError(mskToDate, null);
            }
            catch (Exception)
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
            return Error;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            txtAccountNumber.Clear();
            mskFromDate.Clear();
            mskToDate.Clear();
            mskToDate.ShowDate = true;
            mskFromTime.Clear();
            mskToTime.Clear();
            dgProvidingInvoices.DataSource = new List<GetStatementByAccountNumberResponse.ResultData2>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region - Loading -
        FrmLoading frm;
        private void LoadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ShowLoadingForm(false);
                //if (e.Cancelled)                
                //else 
                if (e.Error != null)
                    throw new Exception(e.Error.Message.ToString());
                else
                {
                    //long i = 1;
                    //foreach (DepositInaugurationModel model in (SBL<DepositInaugurationModel>)e.Result)
                    //{
                    //    model.NumberRow = i;
                    //    i++;
                    //}
                    //CalSumAvr();
                    //bsDepositInauguration.DataSource = e.Result;
                    if (_result.isSuccess)
                    {
                        dgProvidingInvoices.DataSource = e.Result; //_result.value.ResultData;
                    }
                }
            }
            catch (Exception ex)
            {

                //MessageOK(ex, FrmLogin.LoggedInUserInfo.UserIdentity, PUseCaseID);
            }
        }
        private void LoadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (LoadingWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                //IDepositInaugurationManager idim = CommonUtils.FacadeFactory.DepositInaugurationManager(SBS.CommonUtils.Properties.Resources.SecondServerIP, FrmLogin.LoggedInUserInfo.UserIdentity.ToString(), PUseCaseID, FrmBase.ReportTicketStr);
                //dimodel.NumberRow = GetNumberRecordInReport(AppUC.SBS_WinUI_Deposit_Forms_FrmRptDepositList);
                //dilist = idim.RptSearch(dimodel);
                //SBL<DepositInaugurationModel> list1 = new SBL<DepositInaugurationModel>(dilist);

                e.Result = new object();// list1;
            }
            catch (Exception ex)
            {
                //MessageOK(ex, FrmLogin.LoggedInUserInfo.UserIdentity, PUseCaseID);
                e.Result = null;
            }
        }
        protected void ShowLoadingForm(bool bl)
        {
            if (bl)
            {
                frm = new FrmLoading();
                frm.btnCancelLoading.Click += new EventHandler(btnCancelLoading_Click);
                this.Enabled = false;
                LoadingWorker.RunWorkerAsync();
                frm.Location = new Point(this.Location.X + this.Width / 2 - frm.Width / 2, this.Location.Y + this.Height / 2 - frm.Height / 2);
                frm.Show();
            }
            else
            {
                this.Enabled = true;
                frm.Close();
            }
        }
        private void btnCancelLoading_Click(object sender, EventArgs e)
        {
            LoadingWorker.CancelAsync();
        }
        #endregion

        private void FrmProvidingInvoices_Load(object sender, EventArgs e)
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
