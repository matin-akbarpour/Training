namespace WinUI
{
    partial class FrmProvidingInvoices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.mskToTime = new System.Windows.Forms.MaskedTextBox();
            this.mskFromTime = new System.Windows.Forms.MaskedTextBox();
            this.txtFirstResult = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResultCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgProvidingInvoices = new System.Windows.Forms.DataGridView();
            this.dgAccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTransactionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSideName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSideAccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSideNationalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOperatorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSpecialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOptionalDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSideImd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTerminalNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAcquirerImd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSideCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPursuitNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRrn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAcquireCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAcquireName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mskToDate = new WinUI.PopupCalendar();
            this.mskFromDate = new WinUI.PopupCalendar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.LoadingWorker = new System.ComponentModel.BackgroundWorker();
            this.btnClear = new SaminControl.SaminButton();
            this.btnClose = new SaminControl.SaminButton();
            this.btnShow = new SaminControl.SaminButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgProvidingInvoices)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAccountNumber.Location = new System.Drawing.Point(20, 27);
            this.txtAccountNumber.MaxLength = 30;
            this.txtAccountNumber.Multiline = true;
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccountNumber.Size = new System.Drawing.Size(619, 26);
            this.txtAccountNumber.TabIndex = 0;
            this.txtAccountNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountNumber_KeyPress);
            // 
            // mskToTime
            // 
            this.mskToTime.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mskToTime.ForeColor = System.Drawing.Color.Black;
            this.mskToTime.Location = new System.Drawing.Point(20, 78);
            this.mskToTime.Mask = "00:00:00.00000";
            this.mskToTime.Name = "mskToTime";
            this.mskToTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mskToTime.Size = new System.Drawing.Size(100, 26);
            this.mskToTime.TabIndex = 4;
            this.mskToTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskToTime.ValidatingType = typeof(System.DateTime);
            // 
            // mskFromTime
            // 
            this.mskFromTime.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mskFromTime.ForeColor = System.Drawing.Color.Black;
            this.mskFromTime.Location = new System.Drawing.Point(201, 78);
            this.mskFromTime.Mask = "00:00:00.00000";
            this.mskFromTime.Name = "mskFromTime";
            this.mskFromTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mskFromTime.Size = new System.Drawing.Size(100, 26);
            this.mskFromTime.TabIndex = 3;
            this.mskFromTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskFromTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtFirstResult
            // 
            this.txtFirstResult.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFirstResult.Location = new System.Drawing.Point(1063, 97);
            this.txtFirstResult.MaxLength = 30;
            this.txtFirstResult.Multiline = true;
            this.txtFirstResult.Name = "txtFirstResult";
            this.txtFirstResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFirstResult.Size = new System.Drawing.Size(79, 33);
            this.txtFirstResult.TabIndex = 142;
            this.txtFirstResult.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1150, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(60, 18);
            this.label7.TabIndex = 143;
            this.label7.Text = "اولین نتیجه:";
            this.label7.Visible = false;
            // 
            // txtResultCount
            // 
            this.txtResultCount.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtResultCount.Location = new System.Drawing.Point(1063, 41);
            this.txtResultCount.MaxLength = 30;
            this.txtResultCount.Multiline = true;
            this.txtResultCount.Name = "txtResultCount";
            this.txtResultCount.Size = new System.Drawing.Size(79, 33);
            this.txtResultCount.TabIndex = 140;
            this.txtResultCount.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Yekan", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1150, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 141;
            this.label6.Text = "تعداد نتیجه:";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(126, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 139;
            this.label5.Text = "زمان پایان:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(307, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 138;
            this.label4.Text = "زمان شروع:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(639, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 137;
            this.label8.Text = "شماره حساب یا شبا:";
            // 
            // dgProvidingInvoices
            // 
            this.dgProvidingInvoices.AllowUserToAddRows = false;
            this.dgProvidingInvoices.AllowUserToDeleteRows = false;
            this.dgProvidingInvoices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Yekan", 9.75F);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProvidingInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProvidingInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProvidingInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProvidingInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgAccountNumber,
            this.dgBed,
            this.dgBes,
            this.dgBalanceAmount,
            this.dgTransactionDate,
            this.dgTransactionTime,
            this.dgSideName,
            this.dgSideAccountNumber,
            this.dgSideNationalCode,
            this.dgDocNumber,
            this.dgOperatorCode,
            this.dgSpecialNumber,
            this.dgOptionalDescription,
            this.dgSideImd,
            this.dgTerminalNumber,
            this.dgAcquirerImd,
            this.dgSideCardNumber,
            this.dgPursuitNumber,
            this.dgRrn,
            this.dgAcquireCode,
            this.dgAcquireName,
            this.dgCardNumber});
            this.dgProvidingInvoices.Location = new System.Drawing.Point(14, 137);
            this.dgProvidingInvoices.MultiSelect = false;
            this.dgProvidingInvoices.Name = "dgProvidingInvoices";
            this.dgProvidingInvoices.ReadOnly = true;
            this.dgProvidingInvoices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProvidingInvoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Yekan", 9.75F);
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProvidingInvoices.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgProvidingInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProvidingInvoices.Size = new System.Drawing.Size(887, 364);
            this.dgProvidingInvoices.TabIndex = 136;
            this.dgProvidingInvoices.TabStop = false;
            // 
            // dgAccountNumber
            // 
            this.dgAccountNumber.DataPropertyName = "AccountNumber";
            dataGridViewCellStyle3.NullValue = null;
            this.dgAccountNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgAccountNumber.HeaderText = "شماره حساب";
            this.dgAccountNumber.Name = "dgAccountNumber";
            this.dgAccountNumber.ReadOnly = true;
            this.dgAccountNumber.Width = 120;
            // 
            // dgBed
            // 
            this.dgBed.DataPropertyName = "Bed";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dgBed.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgBed.HeaderText = " مبلغ  بدهکار";
            this.dgBed.Name = "dgBed";
            this.dgBed.ReadOnly = true;
            // 
            // dgBes
            // 
            this.dgBes.DataPropertyName = "Bes";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.dgBes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgBes.HeaderText = "مبلغ  بستانکار";
            this.dgBes.Name = "dgBes";
            this.dgBes.ReadOnly = true;
            // 
            // dgBalanceAmount
            // 
            this.dgBalanceAmount.DataPropertyName = "BalanceAmount";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.dgBalanceAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgBalanceAmount.HeaderText = " مبلغ مانده";
            this.dgBalanceAmount.Name = "dgBalanceAmount";
            this.dgBalanceAmount.ReadOnly = true;
            // 
            // dgTransactionDate
            // 
            this.dgTransactionDate.DataPropertyName = "TransactionDate";
            this.dgTransactionDate.HeaderText = "تاریخ تراکنش";
            this.dgTransactionDate.Name = "dgTransactionDate";
            this.dgTransactionDate.ReadOnly = true;
            // 
            // dgTransactionTime
            // 
            this.dgTransactionTime.DataPropertyName = "TransactionTime";
            this.dgTransactionTime.HeaderText = "زمان تراکنش";
            this.dgTransactionTime.Name = "dgTransactionTime";
            this.dgTransactionTime.ReadOnly = true;
            // 
            // dgSideName
            // 
            this.dgSideName.DataPropertyName = "SideName";
            this.dgSideName.HeaderText = "نام دارنده حساب طرف";
            this.dgSideName.Name = "dgSideName";
            this.dgSideName.ReadOnly = true;
            // 
            // dgSideAccountNumber
            // 
            this.dgSideAccountNumber.DataPropertyName = "SideAccountNumber";
            this.dgSideAccountNumber.HeaderText = "شماره شبا طرف";
            this.dgSideAccountNumber.Name = "dgSideAccountNumber";
            this.dgSideAccountNumber.ReadOnly = true;
            // 
            // dgSideNationalCode
            // 
            this.dgSideNationalCode.DataPropertyName = "SideNationalCode";
            this.dgSideNationalCode.HeaderText = " کدملی ";
            this.dgSideNationalCode.Name = "dgSideNationalCode";
            this.dgSideNationalCode.ReadOnly = true;
            // 
            // dgDocNumber
            // 
            this.dgDocNumber.DataPropertyName = "DocNumber";
            this.dgDocNumber.HeaderText = " شماره سند";
            this.dgDocNumber.Name = "dgDocNumber";
            this.dgDocNumber.ReadOnly = true;
            // 
            // dgOperatorCode
            // 
            this.dgOperatorCode.DataPropertyName = "OperatorCode";
            this.dgOperatorCode.HeaderText = "کد اپراتور";
            this.dgOperatorCode.Name = "dgOperatorCode";
            this.dgOperatorCode.ReadOnly = true;
            // 
            // dgSpecialNumber
            // 
            this.dgSpecialNumber.DataPropertyName = "SpecialNumber";
            this.dgSpecialNumber.HeaderText = " شماره ویژه";
            this.dgSpecialNumber.Name = "dgSpecialNumber";
            this.dgSpecialNumber.ReadOnly = true;
            // 
            // dgOptionalDescription
            // 
            this.dgOptionalDescription.DataPropertyName = "OptionalDescription";
            this.dgOptionalDescription.HeaderText = "شرح دلخواه";
            this.dgOptionalDescription.Name = "dgOptionalDescription";
            this.dgOptionalDescription.ReadOnly = true;
            // 
            // dgSideImd
            // 
            this.dgSideImd.DataPropertyName = "SideImd";
            this.dgSideImd.HeaderText = "کد بانک طرف";
            this.dgSideImd.Name = "dgSideImd";
            this.dgSideImd.ReadOnly = true;
            // 
            // dgTerminalNumber
            // 
            this.dgTerminalNumber.DataPropertyName = "TerminalNumber";
            this.dgTerminalNumber.HeaderText = "کد ترمینال";
            this.dgTerminalNumber.Name = "dgTerminalNumber";
            this.dgTerminalNumber.ReadOnly = true;
            // 
            // dgAcquirerImd
            // 
            this.dgAcquirerImd.DataPropertyName = "AcquirerImd";
            this.dgAcquirerImd.HeaderText = "کد بانک پذیرنده";
            this.dgAcquirerImd.Name = "dgAcquirerImd";
            this.dgAcquirerImd.ReadOnly = true;
            // 
            // dgSideCardNumber
            // 
            this.dgSideCardNumber.DataPropertyName = "SideCardNumber";
            this.dgSideCardNumber.HeaderText = "شماره کارت طرف";
            this.dgSideCardNumber.Name = "dgSideCardNumber";
            this.dgSideCardNumber.ReadOnly = true;
            // 
            // dgPursuitNumber
            // 
            this.dgPursuitNumber.DataPropertyName = "PursuitNumber";
            this.dgPursuitNumber.HeaderText = "شماره پیگیری";
            this.dgPursuitNumber.Name = "dgPursuitNumber";
            this.dgPursuitNumber.ReadOnly = true;
            // 
            // dgRrn
            // 
            this.dgRrn.DataPropertyName = "Rrn";
            this.dgRrn.HeaderText = "شماره ارجاع تراکنش/ شاپرکی";
            this.dgRrn.Name = "dgRrn";
            this.dgRrn.ReadOnly = true;
            // 
            // dgAcquireCode
            // 
            this.dgAcquireCode.DataPropertyName = "AcquireCode";
            this.dgAcquireCode.HeaderText = "شاخص درگاه بانک پذیرنده";
            this.dgAcquireCode.Name = "dgAcquireCode";
            this.dgAcquireCode.ReadOnly = true;
            // 
            // dgAcquireName
            // 
            this.dgAcquireName.DataPropertyName = "AcquireName";
            this.dgAcquireName.HeaderText = " نام درگاه بانک پذیرنده";
            this.dgAcquireName.Name = "dgAcquireName";
            this.dgAcquireName.ReadOnly = true;
            // 
            // dgCardNumber
            // 
            this.dgCardNumber.DataPropertyName = "CardNumber";
            this.dgCardNumber.HeaderText = "شماره کارت";
            this.dgCardNumber.Name = "dgCardNumber";
            this.dgCardNumber.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(493, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 149;
            this.label1.Text = "تاریخ پایان:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(675, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 150;
            this.label2.Text = "تاریخ شروع:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mskToDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.mskFromDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAccountNumber);
            this.groupBox1.Controls.Add(this.mskToTime);
            this.groupBox1.Controls.Add(this.mskFromTime);
            this.groupBox1.Location = new System.Drawing.Point(153, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // mskToDate
            // 
            this.mskToDate.BackColor = System.Drawing.SystemColors.Window;
            this.mskToDate.Location = new System.Drawing.Point(387, 78);
            this.mskToDate.Mask = "0000/00/00";
            this.mskToDate.Name = "mskToDate";
            this.mskToDate.PromptChar = ' ';
            this.mskToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mskToDate.ShowDate = true;
            this.mskToDate.Size = new System.Drawing.Size(100, 27);
            this.mskToDate.TabIndex = 2;
            this.mskToDate.Text = "14020712";
            // 
            // mskFromDate
            // 
            this.mskFromDate.BackColor = System.Drawing.SystemColors.Window;
            this.mskFromDate.Location = new System.Drawing.Point(569, 78);
            this.mskFromDate.Mask = "0000/00/00";
            this.mskFromDate.Name = "mskFromDate";
            this.mskFromDate.PromptChar = ' ';
            this.mskFromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mskFromDate.Size = new System.Drawing.Size(100, 27);
            this.mskFromDate.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // LoadingWorker
            // 
            this.LoadingWorker.WorkerReportsProgress = true;
            this.LoadingWorker.WorkerSupportsCancellation = true;
            this.LoadingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadingWorker_DoWork);
            this.LoadingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadingWorker_RunWorkerCompleted);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.btnClear.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.btnClear.ButtonText = "حذف شرایط جستجو";
            this.btnClear.CornerRadius = 5;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClear.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.btnClear.Location = new System.Drawing.Point(14, 57);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 33);
            this.btnClear.TabIndex = 2;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.btnClose.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.btnClose.ButtonText = "برگشت";
            this.btnClose.CornerRadius = 5;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClose.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.btnClose.Location = new System.Drawing.Point(14, 97);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.btnShow.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.btnShow.ButtonText = "نمایش";
            this.btnShow.CornerRadius = 5;
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnShow.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            this.btnShow.Location = new System.Drawing.Point(14, 17);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(133, 33);
            this.btnShow.TabIndex = 1;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // FrmProvidingInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(913, 510);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtResultCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFirstResult);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgProvidingInvoices);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FrmProvidingInvoices";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارائه صورتحساب";
            this.Load += new System.EventHandler(this.FrmProvidingInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProvidingInvoices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.MaskedTextBox mskToTime;
        private System.Windows.Forms.MaskedTextBox mskFromTime;
        private System.Windows.Forms.TextBox txtFirstResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResultCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgProvidingInvoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private SaminControl.SaminButton btnShow;
        private SaminControl.SaminButton btnClose;
        private SaminControl.SaminButton btnClear;
        private PopupCalendar mskFromDate;
        private PopupCalendar mskToDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker LoadingWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBalanceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTransactionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSideName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSideAccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSideNationalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOperatorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSpecialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOptionalDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSideImd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTerminalNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAcquirerImd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSideCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPursuitNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRrn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAcquireCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAcquireName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCardNumber;
    }
}