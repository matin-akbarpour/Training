using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.ComponentModel;

namespace WinUI
{
    public class PopupCalendar : MaskedTextBox
    {
        public PopupCalendar()
        {
            InitializeComponent();
        }

        private Button btnLoadCalender;
        private ToolStripDropDown tooldown;
        private bool _ShowDate;

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value == "    /  /")
                {
                    base.Text = string.Empty;
                }
                else
                {
                    if (!_ShowDate)
                        base.Text = value;
                    else
                    {
                        PersianCalendar prc = new PersianCalendar();
                        base.Text = prc.GetYear(DateTime.Now).ToString() + prc.GetMonth(DateTime.Now).ToString("00") + prc.GetDayOfMonth(DateTime.Now).ToString("00");
                    }
                }
            }
        }

        [DefaultValue(false)]
        [Description("Show date or not")]
        public bool ShowDate
        {
            get
            {
                return _ShowDate;
            }
            set
            {
                _ShowDate = value;
                if (_ShowDate == true)
                {
                    PersianCalendar prc = new PersianCalendar();
                    base.Text = prc.GetYear(DateTime.Now).ToString() + prc.GetMonth(DateTime.Now).ToString("00") + prc.GetDayOfMonth(DateTime.Now).ToString("00");
                }
                else
                {
                    base.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// تاريخ انتخابي را بر مي گرداند
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void calender_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(CalenderSHamsi.shamsiDay))
                {
                    _ShowDate = false;
                    Text = CalenderSHamsi.shamsiDate;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (Enabled)
                {
                    base.BackColor = SystemColors.Window;
                }
                else
                {
                    base.BackColor = SystemColors.Control;
                }
            }
        }
        //public  HorizontalAlignment TextAlign
        //{
        //    get { return HorizontalAlignment.Left; }
        //    set { base.TextAlign = HorizontalAlignment.Left; }
        //}
        //public override RightToLeft RightToLeft
        //{
        //    get { return RightToLeft.Yes; }
        //    set { base.RightToLeft = RightToLeft.Yes; }
        //}

        ///<summary> 
        ///Required method for Designer support - do not modify 
        ///the contents of this method with the code editor.
        ///</summary>
        private void InitializeComponent()
        {
            btnLoadCalender = new Button();
            SuspendLayout();
            // 
            // btnLoadCalender
            // 
            btnLoadCalender.BackColor = SystemColors.ControlLight;
            btnLoadCalender.BackgroundImage = WinUI.Properties.Resources.Calendar_1;
            btnLoadCalender.BackgroundImageLayout = ImageLayout.Center;
            btnLoadCalender.Cursor = Cursors.Default;
            btnLoadCalender.Location = new Point(0, 0);
            btnLoadCalender.Name = "btnLoadCalender";
            btnLoadCalender.Size = new Size(17, 20);
            btnLoadCalender.TabIndex = 0;
            btnLoadCalender.TabStop = false;
            btnLoadCalender.UseVisualStyleBackColor = true;
            btnLoadCalender.Click += new EventHandler(btnLoadCalender_Click);
            // 
            // PopupCalendar
            // 
            BackColor = SystemColors.Window;
            Controls.Add(btnLoadCalender);
            Mask = "0000/00/00";
            PromptChar = ' ';
            Size = new Size(95, 20);
            Text = "    /  /";
            TextAlignChanged += new EventHandler(PopupCalendar_TextAlignChanged);
            RightToLeftChanged += new EventHandler(PopupCalendar_RightToLeftChanged);
            ResumeLayout(false);

        }

        void PopupCalendar_TextAlignChanged(object sender, EventArgs e)
        {
            if (Enabled)
            {
                TextAlign = HorizontalAlignment.Left;
            }
            else
            {
                TextAlign = HorizontalAlignment.Center;
            }
        }

        //void PopupCalendar_EnabledChanged(object sender, EventArgs e)
        //{
        //    if (Enabled)
        //    {
        //        btnLoadCalender.Visible = true;
        //        this.TextAlign = HorizontalAlignment.Center;
        //    }
        //    else
        //    {
        //        btnLoadCalender.Visible = false;
        //        this.TextAlign = HorizontalAlignment.Left;
        //    }
        //}

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
            {
                BackColor = SystemColors.Window;
                btnLoadCalender.Visible = true;
                TextAlign = HorizontalAlignment.Left;
            }
            else
            {
                btnLoadCalender.Visible = false;
                TextAlign = HorizontalAlignment.Center;
                BackColor = SystemColors.Control;
            }
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public  bool Enabled
        //{
        //    get
        //    {
        //        return base.Enabled;
        //    }
        //    set
        //    {
        //        base.Enabled = value;
        //        if (value)
        //        {
        //            BackColor = SystemColors.Window;
        //        }
        //        else
        //        {
        //            BackColor = SystemColors.Control;
        //        }
        //    }
        //}
        /// <summary>
        /// بعد از کلیک بر روی باتن تقویم نمایش داده می شود
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnLoadCalender_Click(object sender, EventArgs e)
        {
            try
            {
                CalenderSHamsi calender = new CalenderSHamsi();
                calender.Click += new EventHandler(calender_Click);
                calender.GridClick += new EventHandler(calender_GridClick);
                ToolStripControlHost toolhost = new ToolStripControlHost(calender);
                tooldown = new ToolStripDropDown();
                tooldown.Items.Add(toolhost);
                tooldown.BackColor = Color.Transparent;
                tooldown.Show(this, new Point(0 + Width + btnLoadCalender.Width, 0 + Height));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// بعد از کلیک بر روی دیتا گرید  تاریخ روز نمایش داده می شود و تقویم حذف می شود
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void calender_GridClick(object sender, EventArgs e)
        {
            try
            {
                tooldown.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void PopupCalendar_RightToLeftChanged(object sender, EventArgs e)
        {
            //    if (RightToLeft == System.Windows.Forms.RightToLeft.No)
            //    {
            //        btnLoadCalender.Location = new Point(Width - btnLoadCalender.Width - 3, 0);
            //    }
            //    else if (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
            //    {
            //        btnLoadCalender.Location = new Point(0, 0);
            base.RightToLeft = RightToLeft.Yes;
            //    }
        }
        /// <summary>
        /// چک می کند که تاریخ درست وارد شود
        /// </summary>
        /// <param name="StrDate"></param>
        /// <returns></returns>
        public string ValidDate(string StrDate)
        {
            try
            {
                if (StrDate.CompareTo("    /  /") == 0)
                {
                    return "تاريخ معتبر نيست: سال، ماه و روز را کامل وارد نمایید";
                }


                string m_Year = "";
                string m_Month = "";
                string m_Day = "";
                string[] s;
                s = StrDate.Split('/');
                if (s.Length == 3)
                {
                    m_Year = s[0].Trim();
                    m_Month = s[1].Trim();
                    m_Day = s[2].Trim();
                }

                if (m_Year.Length < 4)
                {
                    return "تاريخ معتبر نيست: عدد انتخابي براي سال اشتباه است";
                }
                else if (m_Month.Length < 2)
                {
                    return "تاريخ معتبر نيست: عدد انتخابي براي ماه اشتباه است";
                }
                else if (m_Day.Length < 2)
                {
                    return "تاريخ معتبر نيست: عدد انتخابي براي روز اشتباه است";
                }

                if (m_Year == "" || m_Year.Substring(0, 1) == " " || m_Year.Substring(1, 1) == " " || m_Year.Substring(3, 1) == " " || m_Year.Substring(2, 1) == " ")
                {
                    return "تاريخ معتبر نيست: عدد انتخابي براي سال اشتباه است";
                }
                if (m_Month.CompareTo("01") < 0 || m_Month.CompareTo("12") > 0 || m_Month.Substring(0, 1) == " " || m_Month.Substring(1, 1) == " ")
                {
                    return "تاريخ معتبر نيست: عدد انتخابي براي ماه اشتباه است";
                }
                if (m_Month.CompareTo("07") < 0 && (m_Day.CompareTo("01") < 0 || m_Day.CompareTo("31") > 0) || m_Day.Substring(0, 1) == " " || m_Day.Substring(1, 1) == " ")
                {
                    return "تاريخ معتبر نيست: عدد انتخابي براي روز اشتباه است";
                }
                if (m_Month.CompareTo("07") >= 0 && (m_Day.CompareTo("01") < 0 || m_Day.CompareTo("30") > 0) || m_Day.Substring(0, 1) == " " || m_Day.Substring(1, 1) == " ")
                {
                    return "تاريخ معتبر نيست: عدد انتخابي براي روز اشتباه است";
                }
                return "1";
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.PageDown && this.Enabled == true && this.ReadOnly == false)
            //{
            //    Cal();
            //}
            //if (this.ReadOnly == false)
            //    ThreeSepratorDown(e.KeyValue);
            base.OnKeyDown(e);
        }


    }
}
