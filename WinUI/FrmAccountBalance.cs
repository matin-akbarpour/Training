using Gateway.HttpRequestHelper;
using Gateway.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinUI.BaseDataEntry;

namespace WinUI
{
    public partial class FrmAccountBalance : Form
    {
        private BaseData _baseDataEntry;
        private readonly HttpRequest _httpRequest;
        private FluentResultVm<CustomerdepositsamountResponse> _result;

        public FrmAccountBalance()
        {
            try
            {
                InitializeComponent();

                _baseDataEntry = new BaseData();
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
                var depositNumber = new
                {
                    DepositNumber = txtDepositNumber.Text
                };
                
                _result = await _httpRequest.PostAction<FluentResultVm<CustomerdepositsamountResponse>, object>("http://localhost:11248/api/EBankSepah/Customerdepositsamount", depositNumber);

                if (_result.isSuccess)
                {
                    var values = new List<CustomerdepositsamountResponse.ResultData1>
                    {
                        new CustomerdepositsamountResponse.ResultData1
                        {
                            CurrentAmount = _result.value.ResultData.CurrentAmount,
                            CurrentWithdrawableAmount = _result.value.ResultData.CurrentWithdrawableAmount
                        }
                    };

                    dgResultData.DataSource = values;
                }
                else
                {
                    FrmAccountBalanceControl();
                }
            }
            catch
            {
                if (_result.isSuccess)
                    MessageBox.Show(_result.value.Message);
                else
                    MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private void FrmAccountBalanceControl()
        {

            try
            {
                if (string.IsNullOrEmpty(txtDepositNumber.Text))
                    errorProvider1.SetError(txtDepositNumber, "لطفا شماره سپرده را وارد کنید");
                else
                    errorProvider1.SetError(txtDepositNumber, null);

                if (!string.IsNullOrEmpty(txtDepositNumber.Text))
                    MessageBox.Show("شماره سپرده نادرست است");
            }
            catch (Exception)
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDepositNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = _baseDataEntry.ValidNumber(e.KeyChar);
        }
    }
}
