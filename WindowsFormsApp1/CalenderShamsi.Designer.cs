namespace WindowsFormsApp1
{
    partial class CalenderSHamsi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dgCalender = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnToday = new WindowsFormsApp1.CalendarMonthButton();
            this.btnNextYear = new WindowsFormsApp1.CalendarYearButton();
            this.btnNextMonth = new WindowsFormsApp1.CalendarMonthButton();
            this.btnBackMonth = new WindowsFormsApp1.CalendarMonthButton();
            this.btnBackYear = new WindowsFormsApp1.CalendarYearButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCalender)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnNextYear);
            this.panel2.Controls.Add(this.btnNextMonth);
            this.panel2.Controls.Add(this.btnBackMonth);
            this.panel2.Controls.Add(this.lblYear);
            this.panel2.Controls.Add(this.btnBackYear);
            this.panel2.Controls.Add(this.lblMonth);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(269, 31);
            this.panel2.TabIndex = 1;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = false;
            this.lblYear.Font = new System.Drawing.Font("B Yekan", 9F);
            this.lblYear.ForeColor = System.Drawing.Color.Black;
            this.lblYear.Location = new System.Drawing.Point(39, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(36, 18);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "9999";
            // 
            // lblMonth
            // 
            this.lblMonth.Font = new System.Drawing.Font("B Yekan", 9F);
            this.lblMonth.ForeColor = System.Drawing.Color.Black;
            this.lblMonth.Location = new System.Drawing.Point(166, 6);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(58, 19);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "اردیبهشت";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Font = new System.Drawing.Font("B Yekan", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDate.Location = new System.Drawing.Point(0, 170);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(85, 23);
            this.lblDate.TabIndex = 31;
            this.lblDate.Text = "1399/12/31";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgCalender
            // 
            this.dgCalender.AllowUserToAddRows = false;
            this.dgCalender.AllowUserToDeleteRows = false;
            this.dgCalender.AllowUserToResizeColumns = false;
            this.dgCalender.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgCalender.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCalender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCalender.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgCalender.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCalender.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCalender.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCalender.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgCalender.Location = new System.Drawing.Point(0, 33);
            this.dgCalender.MultiSelect = false;
            this.dgCalender.Name = "dgCalender";
            this.dgCalender.ReadOnly = true;
            this.dgCalender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgCalender.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.dgCalender.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgCalender.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgCalender.Size = new System.Drawing.Size(269, 135);
            this.dgCalender.TabIndex = 32;
            this.dgCalender.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "ش";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "ی";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 35;
            // 
            // Column3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "د";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 35;
            // 
            // Column4
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.HeaderText = "س";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 35;
            // 
            // Column5
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.HeaderText = "چ";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 35;
            // 
            // Column6
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.Column6.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column6.HeaderText = "پ";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 35;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.Column7.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column7.HeaderText = "ج";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // btnToday
            // 
            this.btnToday.Font = new System.Drawing.Font("B Yekan", 9F);
            this.btnToday.Location = new System.Drawing.Point(195, 169);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(73, 24);
            this.btnToday.TabIndex = 30;
            this.btnToday.Text = "امروز";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnNextYear
            // 
            this.btnNextYear.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.btnNextYear.ForeColor = System.Drawing.Color.Black;
            this.btnNextYear.Location = new System.Drawing.Point(79, 3);
            this.btnNextYear.Name = "btnNextYear";
            this.btnNextYear.Size = new System.Drawing.Size(31, 21);
            this.btnNextYear.TabIndex = 6;
            this.btnNextYear.Text = "<<";
            this.btnNextYear.UseVisualStyleBackColor = true;
            this.btnNextYear.Click += new System.EventHandler(this.btnNextYear_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.btnNextMonth.ForeColor = System.Drawing.Color.Black;
            this.btnNextMonth.Location = new System.Drawing.Point(229, 3);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(34, 21);
            this.btnNextMonth.TabIndex = 4;
            this.btnNextMonth.Text = "<<";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnBackMonth
            // 
            this.btnBackMonth.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.btnBackMonth.ForeColor = System.Drawing.Color.Black;
            this.btnBackMonth.Location = new System.Drawing.Point(128, 3);
            this.btnBackMonth.Name = "btnBackMonth";
            this.btnBackMonth.Size = new System.Drawing.Size(33, 21);
            this.btnBackMonth.TabIndex = 2;
            this.btnBackMonth.Text = ">>";
            this.btnBackMonth.UseVisualStyleBackColor = true;
            this.btnBackMonth.Click += new System.EventHandler(this.btnBackMonth_Click);
            // 
            // btnBackYear
            // 
            this.btnBackYear.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.btnBackYear.ForeColor = System.Drawing.Color.Black;
            this.btnBackYear.Location = new System.Drawing.Point(3, 3);
            this.btnBackYear.Name = "btnBackYear";
            this.btnBackYear.Size = new System.Drawing.Size(31, 21);
            this.btnBackYear.TabIndex = 1;
            this.btnBackYear.Text = ">>";
            this.btnBackYear.UseVisualStyleBackColor = true;
            this.btnBackYear.Click += new System.EventHandler(this.btnBackYear_Click);
            // 
            // CalenderSHamsi
            // 
            this.Controls.Add(this.dgCalender);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.Name = "CalenderSHamsi";
            this.Size = new System.Drawing.Size(271, 194);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCalender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private CalendarMonthButton btnBackMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private CalendarYearButton btnBackYear;
        private CalendarMonthButton btnNextMonth;
        private CalendarYearButton btnNextYear;
        public System.Windows.Forms.Label lblDate;
        private CalendarMonthButton btnToday;
        public System.Windows.Forms.DataGridView dgCalender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}
