using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CEWorld.Convert;
using DNTPersianUtils.Core;
using Gateway.HttpRequestHelper;
using Gateway.Models;
using Newtonsoft.Json;

namespace WinUI
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
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
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
                    txtFirstName.Text = txtFirstName.Text.Replace("  ", " ");
                    txtLastName.Text = txtLastName.Text.Replace("  ", " ");
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
                    MessageBox.Show("در انجام عملیات خطایی رخ داده است");
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
                    txtAmountDisp.Text = NumberToWord.PersianConvertNumberToWord(txtAmount.text.Trim()) + " ریال ";
                }
            }
            catch
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private async void btnDeposit_Click(object sender, System.EventArgs e)
        {
            try
            {
                _myConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);

                if (FrmSatnaPayaControl())
                {
                    return;
                }

                string transferType = cboTransferType.SelectedItem.ToString();
                long externalTransferID;

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
                        DetailType = string.IsNullOrEmpty(cboTransferFor.Text) ? "16" : Regex.Match(cboTransferFor.SelectedItem.ToString(), @"\d+").Value
                    };

                    try
                    {
                        _myConnection.Open();

                        SqlCommand InsertStockInformation = new SqlCommand("WF_CreateExternalTransferHeaderDetailBefore", _myConnection);
                        InsertStockInformation.CommandType = CommandType.StoredProcedure;
                        InsertStockInformation.Parameters.Add("@Amount", SqlDbType.BigInt).Value = transferPaya.Amount;
                        InsertStockInformation.Parameters.Add("@IBANNumber", SqlDbType.NVarChar).Value = transferPaya.DestinationIban;
                        InsertStockInformation.Parameters.Add("@OwnerName", SqlDbType.NVarChar).Value = txtFirstName.Text + " " + txtLastName.Text;
                        InsertStockInformation.Parameters.Add("@CashoutType", SqlDbType.TinyInt).Value = cboTransferType.SelectedIndex;
                        InsertStockInformation.Parameters.Add("@Description", SqlDbType.NVarChar).Value = transferPaya.Description;
                        InsertStockInformation.Parameters.Add("@JsonRequest", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(transferPaya).ToString();

                        InsertStockInformation.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        InsertStockInformation.ExecuteNonQuery();
                        externalTransferID = Convert.ToInt64(InsertStockInformation.Parameters["@ID"].Value);

                        _result1 = await _httpRequest.PostAction<FluentResultVm<TransferPayaResponse>, object>("http://localhost:11248/api/EBankSepah/TransferPaya", transferPaya);

                        byte transactionStatus;
                        if (_result1.isSuccess)
                            transactionStatus = 1;
                        else
                            transactionStatus = 2;

                        SqlCommand UpdateStockInformation = new SqlCommand("WF_CreateExternalTransferHeaderDetailAfter", _myConnection);
                        UpdateStockInformation.CommandType = CommandType.StoredProcedure;
                        UpdateStockInformation.Parameters.Add("@ExternalTransferID", SqlDbType.BigInt).Value = externalTransferID;
                        UpdateStockInformation.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = _result1.isSuccess ? _result1.value.TransactionId : "";
                        UpdateStockInformation.Parameters.Add("@TargetExtraID", SqlDbType.NVarChar).Value = _result1.isSuccess ? _result1.value.EndToEndId : "";
                        UpdateStockInformation.Parameters.Add("@ExtraPureData", SqlDbType.NVarChar).Value = _result1.isSuccess ? _result1.value.TransactionCode : "";
                        UpdateStockInformation.Parameters.Add("@TransactionStatus", SqlDbType.TinyInt).Value = transactionStatus;
                        UpdateStockInformation.Parameters.Add("@JsonResponce", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(_result1).ToString();
                        UpdateStockInformation.Parameters.Add("@JsonRequest", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(transferPaya).ToString();
                        
                        UpdateStockInformation.ExecuteNonQuery();

                        MessageBox.Show(_result1.reasons[0].message);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        _myConnection.Dispose();
                    }
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
                        IsAutoVerify = true
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

                        InsertStockInformation.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        InsertStockInformation.ExecuteNonQuery();
                        externalTransferID = Convert.ToInt64(InsertStockInformation.Parameters["@ID"].Value);

                        _result2 = await _httpRequest.PostAction<FluentResultVm<TransferSatnaResponse>, object>("http://localhost:11248/api/EBankSepah/TransferSatna", transferSatna);

                        byte transactionStatus;
                        if (_result2.isSuccess)
                            transactionStatus = 1;
                        else
                            transactionStatus = 2;

                        SqlCommand UpdateStockInformation = new SqlCommand("WF_CreateExternalTransferHeaderDetailAfter", _myConnection);
                        UpdateStockInformation.CommandType = CommandType.StoredProcedure;
                        UpdateStockInformation.Parameters.Add("@ExternalTransferID", SqlDbType.BigInt).Value = externalTransferID;
                        UpdateStockInformation.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = _result2.isSuccess ? _result2.value.TransactionId : "";
                        UpdateStockInformation.Parameters.Add("@TargetExtraID", SqlDbType.NVarChar).Value = _result2.isSuccess ? _result2.value.UserReferenceNumber : "";
                        UpdateStockInformation.Parameters.Add("@ExtraPureData", SqlDbType.NVarChar).Value = _result2.isSuccess ? _result2.value.TransactionCode : "";
                        UpdateStockInformation.Parameters.Add("@TransactionStatus", SqlDbType.TinyInt).Value = transactionStatus;
                        UpdateStockInformation.Parameters.Add("@JsonResponce", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(_result2).ToString();
                        UpdateStockInformation.Parameters.Add("@JsonRequest", SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(transferSatna).ToString();

                        UpdateStockInformation.ExecuteNonQuery();

                        MessageBox.Show(_result2.reasons[0].message);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        _myConnection.Dispose();
                    }
                }
            }
            catch
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
        }

        private bool FrmSatnaPayaControl()
        {
            bool Error = false;

            try
            {
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

                if (string.IsNullOrEmpty(txtAmount.Text.Trim()) || txtAmount.Text == "0")
                {
                    errorProvider1.SetError(txtAmount, "لطفا مبلغ را وارد کنید");
                    Error = true;
                }

                else
                    errorProvider1.SetError(txtAmount, null);
            }
            catch (Exception)
            {
                MessageBox.Show("در انجام عملیات خطایی رخ داده است");
            }
            return Error;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSatnaPaya_Load(object sender, EventArgs e)
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
