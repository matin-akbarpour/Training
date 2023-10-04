using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CEWorld.Convert;
using DNTPersianUtils.Core;
using Gateway.HttpRequestHelper;
using Gateway.Models;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class FrmSatnaPaya : Form
    {
        private readonly HttpRequest _httpRequest;
        private const string XApiKey = "pgH7QzFHJx4w46fI95Uzi4RvtTwlEXp";
        private FluentResultVm<TransferPayaResponse> _result1;
        private FluentResultVm<TransferSatnaResponse> _result2;
        SqlConnection _myConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);


        public FrmSatnaPaya()
        {
            try
            {
                InitializeComponent();

                _httpRequest = new HttpRequest();
                _httpRequest.Authorization(FrmLogin.Token);
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private async void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (!string.IsNullOrEmpty(txtShaba.Text))
                {
                    errorProvider1.SetError(txtShaba, null);

                    _httpRequest.AddHeader("XApiKey", XApiKey);

                    var result = await _httpRequest.GetAction<KookAccountInfo>("https://kook.saminray.com/Kook/ibanInfo", $"?iban={"IR" + txtShaba.Text}");

                    txtFirstName.Text = result.accountOwnersList[0].firstName.Replace("  ", " ");
                    txtLastName.Text = result.accountOwnersList[0].lastName.Replace("  ", " ");
                    txtBankName.Text = result.bank;
                    txtFirstName.Text = txtFirstName.Text.Replace("   ", " ");
                    txtLastName.Text = txtLastName.Text.Replace("   ", " ");
                }
                else
                {
                    FrmSatnaPayaControl();
                }
            }
            catch
            {
                if (!string.IsNullOrEmpty(txtShaba.Text))
                    MessageBox.Show("شماره شبا اشتباه می باشد");
                else
                    MessageBox.Show("خطا");
            }
        }

        private void txtAmount_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                FrmSatnaPayaControl();

                if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
                {
                    txtAmountDisp.Text = "";
                }
                else
                {
                    txtAmountDisp.Text = NumberToWord.PersianConvertNumberToWord(txtAmount.text.Trim()) + "ریال ";
                }
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private async void btnDeposit_Click(object sender, System.EventArgs e)
        {
            try
            {
                _myConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);

                if(FrmSatnaPayaControl())
                {
                    return;
                }

                //if (string.IsNullOrEmpty(cboTransferType.Text))
                //{
                //    FrmSatnaPayaControl();
                //}
                //else
                //{
                string transferType = cboTransferType.SelectedItem.ToString();

                if (transferType == "پایا")
                {
                    var transferPaya = new
                    {
                        Amount = Convert.ToInt64(txtAmount.text),
                        DestinationIban = "IR" + txtShaba.Text,
                        RecieverFullName = txtFirstName.Text,
                        TransactionDate = DateTime.Now.Date.ToShortPersianDateString(),
                        SourceDepNum = "1829602063053",
                        Description = txtDescription.Text,
                        IsAutoVerify = false,
                        //SrcComment = "string",
                        DetailType = string.IsNullOrEmpty(cboTransferFor.Text) ? "16" : Regex.Match(cboTransferFor.SelectedItem.ToString(), @"\d+").Value,
                        //DestComment = "string",
                        //NationalCode = "string",
                        //PhoneNumber = "string",
                        //MobileNumber = "string",
                        //Address = "string",
                        //CommissionDepositNumber = "string",
                        //TransactionBillNumber = "string",
                        //IsFromBox = true
                    };

                    try
                    {
                        _myConnection.Open();


                        SqlCommand InsertStockInformation = new SqlCommand("WF_CreateExternalTransferHeaderDetailBefore", _myConnection);
                        InsertStockInformation.CommandType = CommandType.StoredProcedure;
                        InsertStockInformation.Parameters.Add("@Amount", SqlDbType.BigInt).Value = transferPaya.Amount;// quantity;
                        InsertStockInformation.Parameters.Add("@IBANNumber", SqlDbType.NVarChar).Value = transferPaya.DestinationIban;//  sSymbol;
                        InsertStockInformation.Parameters.Add("@OwnerName", SqlDbType.NVarChar).Value = transferPaya.RecieverFullName;// sCompany;
                        InsertStockInformation.Parameters.Add("@CashoutType", SqlDbType.TinyInt).Value = cboTransferType.SelectedIndex;
                        InsertStockInformation.Parameters.Add("@Description", SqlDbType.NVarChar).Value = transferPaya.Description;// dPrice;
                        InsertStockInformation.Parameters.Add("@JsonRequest", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(transferPaya).ToString();


                        // _myConnection.Open();
                        InsertStockInformation.ExecuteNonQuery();
                        // _myConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        _myConnection.Dispose();
                    }

                    _result1 = await _httpRequest.PostAction<FluentResultVm<TransferPayaResponse>, object>("http://localhost:11248/api/EBankSepah/TransferPaya", transferPaya);

                    int x;
                    if (_result2.isSuccess)
                        x = 1;
                    else
                        x = -1;

                    _myConnection.Open();

                    SqlCommand UpdateStockInformation = new SqlCommand("WF_CreateExternalTransferHeaderDetailAfter", _myConnection);
                    UpdateStockInformation.CommandType = CommandType.StoredProcedure;
                    //UpdateStockInformation.Parameters.Add("@ExternalTransferID", SqlDbType.BigInt).Value = ;
                    UpdateStockInformation.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = _result1.value.TransactionId;
                    UpdateStockInformation.Parameters.Add("@TargetExtraID", SqlDbType.NVarChar).Value = _result1.value.EndToEndId;
                    UpdateStockInformation.Parameters.Add("@ExtraPureData", SqlDbType.NVarChar).Value = _result1.value.TransactionCode;
                    UpdateStockInformation.Parameters.Add("@TransactionStatus", SqlDbType.TinyInt).Value = x;
                    UpdateStockInformation.Parameters.Add("@JsonResponce", SqlDbType.NVarChar).Value = _result1.reasons[0].message;
                    UpdateStockInformation.Parameters.Add("@JsonRequest", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(transferPaya).ToString();

                    MessageBox.Show(_result1.reasons[0].message);
                }
                else if (transferType == "ساتنا")
                {

                    var transferSatna = new
                    {
                        Amount = Convert.ToInt64(txtAmount.text),
                        DestionationDepNum = "IR" + txtShaba.Text,
                        RecieverName = txtFirstName.Text.Length > 36 ? txtFirstName.Text.Substring(0, 36) : txtFirstName.Text,
                        RecieverlastName = txtLastName.Text.Length > 36 ? txtLastName.Text.Substring(0 ,36) : txtLastName.Text,
                        TransactionDate = DateTime.Now.Date.ToShortPersianDateString(),
                        SourceDepNum = "1829602063053",
                        Description = txtDescription.Text,
                        DetailType = string.IsNullOrEmpty(cboTransferFor.Text) ? "16" : Regex.Match(cboTransferFor.SelectedItem.ToString(), @"\d+").Value,
                        IsAutoVerify = true,
                        //TransactionBillNumber = "string",
                        //CommissionDepositNumber = "string",
                        //IsFromBox = true
                    };

                    try
                    {
                        _myConnection.Open();


                        SqlCommand InsertStockInformation = new SqlCommand("WF_CreateExternalTransferHeaderDetailBefore", _myConnection);
                        InsertStockInformation.CommandType = CommandType.StoredProcedure;
                        InsertStockInformation.Parameters.Add("@Amount", SqlDbType.BigInt).Value = transferSatna.Amount;// quantity;
                        InsertStockInformation.Parameters.Add("@IBANNumber", SqlDbType.NVarChar).Value = transferSatna.DestionationDepNum;//  sSymbol;
                        InsertStockInformation.Parameters.Add("@OwnerName", SqlDbType.NVarChar).Value = transferSatna.RecieverName + " " + transferSatna.RecieverlastName;// sCompany;
                        InsertStockInformation.Parameters.Add("@CashoutType", SqlDbType.TinyInt).Value = cboTransferType.SelectedIndex;
                        InsertStockInformation.Parameters.Add("@Description", SqlDbType.NVarChar).Value = transferSatna.Description;// dPrice;
                        InsertStockInformation.Parameters.Add("@JsonRequest", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(transferSatna).ToString();


                        // _myConnection.Open();
                        InsertStockInformation.ExecuteNonQuery();
                        // _myConnection.Close();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                    finally
                    {
                        _myConnection.Dispose();
                    }
                    _result2 = await _httpRequest.PostAction<FluentResultVm<TransferSatnaResponse>, object>("http://localhost:11248/api/EBankSepah/TransferSatna", transferSatna);

                    int x;
                    if (_result2.isSuccess)
                        x = 1;
                    else
                        x = -1;

                    _myConnection.Open();

                    SqlCommand UpdateStockInformation = new SqlCommand("WF_CreateExternalTransferHeaderDetailAfter", _myConnection);
                    UpdateStockInformation.CommandType = CommandType.StoredProcedure;
                    //UpdateStockInformation.Parameters.Add("@ExternalTransferID", SqlDbType.BigInt).Value = ;
                    UpdateStockInformation.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = _result1.value.TransactionId;
                    UpdateStockInformation.Parameters.Add("@TargetExtraID", SqlDbType.NVarChar).Value = _result1.value.EndToEndId;
                    UpdateStockInformation.Parameters.Add("@ExtraPureData", SqlDbType.NVarChar).Value = _result1.value.TransactionCode;
                    UpdateStockInformation.Parameters.Add("@TransactionStatus", SqlDbType.TinyInt).Value = x;
                    UpdateStockInformation.Parameters.Add("@JsonResponce", SqlDbType.NVarChar).Value = _result1.reasons[0].message;
                    UpdateStockInformation.Parameters.Add("@JsonRequest", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(transferSatna).ToString();

                    MessageBox.Show(_result2.reasons[0].message);
                }
                
            }
            catch
            {
                MessageBox.Show("خطا");
            }
        }

        private bool FrmSatnaPayaControl()
        {
            bool Error = false;
            //if (string.IsNullOrEmpty(txtShaba.Text) || string.IsNullOrEmpty(cboTransferType.Text) || string.IsNullOrEmpty(txtAmount.Text.Trim()))
            //{
            if (string.IsNullOrEmpty(txtShaba.Text))
            {
                errorProvider1.SetError(txtShaba, "لطفا شماره شبا را وارد کنید");
                Error = true;
            }

            else
                errorProvider1.SetError(txtShaba, null);

                if (string.IsNullOrEmpty(cboTransferType.Text))
            { 
                    errorProvider1.SetError(cboTransferType, "لطفا نوع انتقال را انتخاب کنید");
                Error = true;
            }

            else
                errorProvider1.SetError(cboTransferType, null);

            if (string.IsNullOrEmpty(txtAmount.Text.Trim())  ||  txtAmount.Text == "0" )
            {
                errorProvider1.SetError(txtAmount, "لطفا مبلغ را وارد کنید");
                Error = true;
            }

            else
                errorProvider1.SetError(txtAmount, null);

            //}
            //else
            //{
            //    errorProvider1.SetError(txtShaba, null);
            //    errorProvider1.SetError(cboTransferType, null);
            //    errorProvider1.SetError(txtAmount, null);
            //}

            return Error;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
