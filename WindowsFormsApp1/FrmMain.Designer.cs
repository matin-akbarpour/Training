namespace WindowsFormsApp1
{
    partial class FrmMain
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msiAccountBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.msiProvidingInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.msiSatnaPaya = new System.Windows.Forms.ToolStripMenuItem();
            this.msiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.AutoSize = false;
            this.msMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.msMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.msMain.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msMain.GripMargin = new System.Windows.Forms.Padding(2);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiAccountBalance,
            this.msiProvidingInvoices,
            this.msiSatnaPaya,
            this.msiExit});
            this.msMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.msMain.Location = new System.Drawing.Point(872, 2);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(5);
            this.msMain.Size = new System.Drawing.Size(110, 857);
            this.msMain.TabIndex = 0;
            // 
            // msiAccountBalance
            // 
            this.msiAccountBalance.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msiAccountBalance.Name = "msiAccountBalance";
            this.msiAccountBalance.Padding = new System.Windows.Forms.Padding(2);
            this.msiAccountBalance.Size = new System.Drawing.Size(99, 28);
            this.msiAccountBalance.Text = "مانده حساب";
            this.msiAccountBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msiAccountBalance.Click += new System.EventHandler(this.msiAccountBalance_Click);
            // 
            // msiProvidingInvoices
            // 
            this.msiProvidingInvoices.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msiProvidingInvoices.Name = "msiProvidingInvoices";
            this.msiProvidingInvoices.Padding = new System.Windows.Forms.Padding(2);
            this.msiProvidingInvoices.Size = new System.Drawing.Size(99, 28);
            this.msiProvidingInvoices.Text = "ارائه صورتحساب";
            this.msiProvidingInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msiProvidingInvoices.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.msiProvidingInvoices.Click += new System.EventHandler(this.msiProvidingInvoices_Click);
            // 
            // msiSatnaPaya
            // 
            this.msiSatnaPaya.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msiSatnaPaya.Name = "msiSatnaPaya";
            this.msiSatnaPaya.Padding = new System.Windows.Forms.Padding(2);
            this.msiSatnaPaya.Size = new System.Drawing.Size(99, 28);
            this.msiSatnaPaya.Text = "ساتنا - پایا";
            this.msiSatnaPaya.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msiSatnaPaya.Click += new System.EventHandler(this.msiSatnaPaya_Click);
            // 
            // msiExit
            // 
            this.msiExit.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msiExit.Name = "msiExit";
            this.msiExit.Padding = new System.Windows.Forms.Padding(2);
            this.msiExit.Size = new System.Drawing.Size(99, 28);
            this.msiExit.Text = "خروج";
            this.msiExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.msiExit.Click += new System.EventHandler(this.msiExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.bg2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(870, 857);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msiAccountBalance;
        private System.Windows.Forms.ToolStripMenuItem msiProvidingInvoices;
        private System.Windows.Forms.ToolStripMenuItem msiSatnaPaya;
        private System.Windows.Forms.ToolStripMenuItem msiExit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}