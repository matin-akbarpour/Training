using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;


namespace WindowsFormsApp1
{
    public partial class CalenderSHamsi : UserControl
    {
        public CalenderSHamsi()
        {
            InitializeComponent();
        }
        static int MonthCount, yearCount;
        //static DataTable dt = new DataTable();
        PersianCalendar prc = new PersianCalendar();
        string MonthName = "", Year = "";
        public string day;
        static string DateShamsi, shamsiDayName = "";
        public static string shamsiDate, shamsiDay;
        static int column, row;
        private CalendarMonthButton _TempMonthButton = null;
        private CalendarYearButton _TempYearButton = null;
        public event EventHandler GridClick;



        public string currentDate
        {
            get { return shamsiDate; }
            set { }
        }

        public CalendarYearButton TempYearButton
        {
            get
            {
                return _TempYearButton;
            }
            set
            {
                if (value == null)
                    return;
                else
                {
                    
                    shamsiDate = lblYear.Text + "/" + MonthCount.ToString("00") + "/" + int.Parse(dgCalender.CurrentCell.Value.ToString()).ToString("00");
                }
            }
        }
        public CalendarMonthButton TempMonthButton
        {
            get
            {
                return _TempMonthButton;
            }
            set
            {
                if (value == null)
                    return;
                else
                {

                        shamsiDate = lblYear.Text + "/" +  MonthCount.ToString("00") + "/" +Int32.Parse(dgCalender.CurrentCell.Value.ToString()).ToString("00");
                }
            }
        }


        /// <summary>
        /// در لود برنامه تاریخ روز را نمایش می دهد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UserControl1_Load(object sender, EventArgs e)
        {
            try
            {
                dgCalender.Rows.Insert(0, 5);
                dgCalender.AllowUserToAddRows = false;
                MonthCount = prc.GetMonth(DateTime.Now);
                int Month = prc.GetMonth(DateTime.Now);
                Year = prc.GetYear(DateTime.Now).ToString();
                yearCount = prc.GetYear(DateTime.Now);
                GetYearAndMonth(Month);
                lblMonth.Text = MonthName;
                lblYear.Text = Year;
                DateShamsi = Year + "/" + Month.ToString("00") + "/" + "01";
                ConvertToGerigorian(DateShamsi, ref shamsiDayName);
                DataGridFill(shamsiDayName, GetNumberDayInMonth());
                lblDate.Text = Year + "/" + Month.ToString("00") + "/" + GetNumberDayInMonth().ToString("00");
                dgCalender.EndEdit();
                if ((MonthCount) == 12)
                {
                    btnNextMonth.Enabled = false;
                }
                if ((MonthCount) == 1)
                {
                    btnBackMonth.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// باگرفتن تاریخ نام ماه به شمسی را بر می گرداند
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>
        private string GetYearAndMonth(int Month)
        {
            try
            {
                switch (Month)
                {
                    case 1:
                        MonthName = "فروردین";
                        break;
                    case 2:
                        MonthName = "اردیبهشت";
                        break;
                    case 3:
                        MonthName = "خرداد";
                        break;
                    case 4:
                        MonthName = "تیر";
                        break;
                    case 5:
                        MonthName = "مرداد";
                        break;
                    case 6:
                        MonthName = "شهریور";
                        break;
                    case 7:
                        MonthName = "مهر";
                        break;
                    case 8:
                        MonthName = "آبان";
                        break;
                    case 9:
                        MonthName = "آذر";
                        break;
                    case 10:
                        MonthName = "دی";
                        break;
                    case 11:
                        MonthName = "بهمن";
                        break;
                    case 12:
                        MonthName = "اسفند";
                        break;
                    default:
                        break;
                }
                return MonthName;
            }
            catch (Exception ex)
            {
                switch (Month)
                {
                    case 1:
                        MonthName = "فروردین";
                        break;
                    case 2:
                        MonthName = "اردیبهشت";
                        break;
                    case 3:
                        MonthName = "خرداد";
                        break;
                    case 4:
                        MonthName = "تیر";
                        break;
                    case 5:
                        MonthName = "مرداد";
                        break;
                    case 6:
                        MonthName = "شهریور";
                        break;
                    case 7:
                        MonthName = "مهر";
                        break;
                    case 8:
                        MonthName = "آبان";
                        break;
                    case 9:
                        MonthName = "آذر";
                        break;
                    case 10:
                        MonthName = "دی";
                        break;
                    case 11:
                        MonthName = "بهمن";
                        break;
                    case 12:
                        MonthName = "اسفند";
                        break;
                    default:
                        break;
                }

                return MonthName;
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// در زمان لود شدن فرم تاریخ روز را نمایش می دهد
        /// </summary>
        /// <param name="date"></param>
        /// <summary>
        /// نام اولین روز هر ماه را گرفته و مکان آنرا در دیتا بیس پیدا نموده
        /// و مقدار آن مکان را برابر با یک قرار داده و طبق 6 مااول یا دوم بودن ماه 
        ///مقداراولین روز تا آخرین روز را دیتا بیس قرار می دهد 
        /// </summary>
        /// <param name="dayName"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private int DataGridFill(string dayName, int showDay)
        {
            try
            {
            switch (dayName)
            {
                case "شنبه":
                    column = 0;

                    break;
                case "یکشنبه":
                    column = 1;

                    break;
                case "دوشنبه":

                    column = 2;
                    break;
                case "سه شنبه":

                    column = 3;
                    break;
                case "چهارشنبه":

                    column = 4;
                    break;
                case "پنجشنبه":

                    column = 5;
                    break;
                case "جمعه":

                    column = 6;
                    break;
                default:
                    break;
            }
            int m = 1;
            int j = 0;
            int k = column;
            int l = column;
            //مقدار قبل از تاریخ یک را برابر با نال قرار می دهد
            for (; l >= 0; l--)
            {
                dgCalender[l, 0].Value = "";
            }



            for (; j < 5; j++)
            {
                for (; k <= 6; k++)
                {
                    if (MonthCount < 7)//اگر تاریخ جز 6 ماهه اول بود
                    {
                        if (m < 32)
                        {
                            dgCalender[k, j].Value = m;
                            if (m == showDay)
                            {
                                row = j;
                                column = k;
                            }
                            m += 1;
                        }
                        else
                        {
                            //مقدار عدد تاریخ را بعد از 31 را برابر با نال قرار می دهد
                            dgCalender[k, j].Value = "";
                        }
                    }
                    else  //اگر تاریخ جز 6 ماهه دوم بود
                    {
                        // اگر سال کبیسه بود تا عدد 30 را قرار می دهد در غیر اینصورت تا تاریخ 29 قرار می دهد
                        if (MonthCount == 12)
                        {
                            if (((yearCount - 3) % 4) == 0)
                            {
                                if (m < 31)
                                {
                                    dgCalender[k, j].Value = m;
                                    if (m == showDay)
                                    {
                                        row = j;
                                        column = k;
                                    }
                                    m += 1;
                                }
                                else
                                {
                                    //مقدار عدد تاریخ را بعد از 30 را برابر با نال قرار می دهد
                                    dgCalender[k, j].Value = "";
                                }
                            }
                            else
                            {
                                if (m < 30)
                                {
                                    dgCalender[k, j].Value = m;
                                    if (m == showDay)
                                    {
                                        row = j;
                                        column = k;
                                    }
                                    m += 1;
                                }
                                else
                                {
                                    //مقدار عدد تاریخ را بعد از 31 را برابر با نال قرار می دهد
                                    dgCalender[k, j].Value = "";
                                }
                            }

                        }
                        else
                        {
                            if (m < 31)
                            {
                                dgCalender[k, j].Value = m;
                                if (m == showDay)
                                {
                                    row = j;
                                    column = k;
                                }
                                m += 1;
                            }
                            else
                            {
                                //مقدار عدد تاریخ را بعد از 31 را برابر با نال قرار می دهد
                                dgCalender[k, j].Value = "";
                            }
                        }
                    }


                }
                k = 0;
            }




            for (int i = 0; i < 6; i++)
            {
                if (MonthCount < 7)
                {
                    if (m <= 31)
                    {
                        dgCalender[i, 0].Value = m;
                        if (m == showDay)
                        {
                            row = 0;
                            column = i;
                        }
                        m = m + 1;
                    }

                }
                else
                {
                    if (MonthCount == 12)
                    {
                        if (((yearCount - 3) % 4) == 0)
                        {
                            if (m <= 30)
                            {
                                dgCalender[i, 0].Value = m;
                                if (m == showDay)
                                {
                                    row = 0;
                                    column = i;
                                }
                                m = m + 1;
                            }
                        }
                        else
                        {
                            if (m <= 29)
                            {
                                dgCalender[i, 0].Value = m;
                                if (m == showDay)
                                {
                                    row = 0;
                                    column = i;
                                }
                                m = m + 1;
                            }
                        }

                    }
                    else
                    {
                        if (m <= 30)
                        {
                            dgCalender[i, 0].Value = m;
                            if (m == showDay)
                            {
                                row = 0;
                                column = i;
                            }
                            m = m + 1;
                        }

                    }
                }
                
            }

            dgCalender.BeginEdit(false);
            dgCalender[column, row].Selected = true;
            return column;
            }
            catch (Exception ex)
            {
                return column;
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// بعد از کلیک بر روی خانه های دیتا گرید ویو عدد روز انتخاب شده را بر می گرداند
        /// تاریخ انتخاب شده را نمایش می دهد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    day = dgCalender.CurrentCell.Value.ToString();
                    CountMonth();
                    if (day != "")
                    {
                        shamsiDay = Int32.Parse(day).ToString("00");
                        lblDate.Text = lblYear.Text + "/" + MonthCount.ToString("00") + "/" + Int32.Parse(day).ToString("00");
                        shamsiDate = lblYear.Text + "/" + MonthCount.ToString("00") + "/" + Int32.Parse(day).ToString("00");
                        GridClick(null, null);
                        this.OnClick(e);
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                
              MessageBox.Show(ex.ToString());
            }


        }
        /// <summary>
        /// مقدار سال را به شمسی بر می گرداند
        /// </summary>
        /// <returns></returns>
        public int GetNumberYear()
        {
            try
            {

            string Res;
            PersianCalendar DateFme = new PersianCalendar();
            Res = DateFme.GetYear(DateTime.Now).ToString();
            return Convert.ToInt32(Res);

            }
            catch (Exception ex)
            {
                return 0;
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// نام روز را به شمسی بر می گرداند
        /// </summary>
        /// <returns></returns>
        public string GetNameDayInMonth()
        {
            try
            {
                string Resme = "";
                string Res;
                PersianCalendar DateFme = new PersianCalendar();
                Res = DateFme.GetDayOfWeek(DateTime.Now).ToString();
                switch (Res)
                {
                    case "Saturday":
                        {
                            Resme = "شنبه";
                            break;
                        }
                    case "Sunday":
                        {
                            Resme = "یکشنبه";
                            break;
                        }
                    case "Monday":
                        {
                            Resme = "دوشنبه";
                            break;
                        }
                    case "Tuesday":
                        {
                            Resme = "سه شنبه";
                            break;
                        }
                    case "Wednesday":
                        {
                            Resme = "چهارشنبه";
                            break;
                        }
                    case "Thursday":
                        {
                            Resme = "پنجشنبه";
                            break;
                        }
                    case "Friday":
                        {
                            Resme = "جمعه";
                            break;
                        }
                }
                return Resme;

            }
            catch (Exception ex)
            {
                return null;
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// تاریخ شمسی را به میلادی تبدیل می نماید
        /// نام روز را به شمسی بر می گرداند
        /// </summary>
        /// <param name="strdate"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public string ConvertToGerigorian(string strdate, ref string dayName)
        {
            try
            {
                //strdate = "1391/01/01";
                string[] Date;
                PersianCalendar persianCalendar = new PersianCalendar();
                DateTime MiladiDate;
                Date = strdate.Split('/');
                MiladiDate = persianCalendar.ToDateTime(int.Parse(Date[0]), int.Parse(Date[1]), int.Parse(Date[2]), 0, 0, 0, 0);
                dayName = GetNameDay(persianCalendar.GetDayOfWeek(MiladiDate.Date).ToString());
                return dayName;
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }

        }
        /// <summary>
        /// باگرفتن نام ماه تعیین می کند چندمین ماه از سال است
        /// </summary>
        private void CountMonth()
        {
            try
            {
                string Month = lblMonth.Text;
                switch (Month)
                {
                    case "فروردین":
                        MonthCount = 1;
                        break;
                    case "اردیبهشت":
                        MonthCount = 2;
                        break;
                    case "خرداد":
                        MonthCount = 3;
                        break;
                    case "تیر":
                        MonthCount = 4;
                        break;
                    case "مرداد":
                        MonthCount = 5;
                        break;
                    case "شهریور":
                        MonthCount = 6;
                        break;
                    case "مهر":
                        MonthCount = 7;
                        break;
                    case "آبان":
                        MonthCount = 8;
                        break;
                    case "آذر":
                        MonthCount = 9;
                        break;
                    case "دی":
                        MonthCount = 10;
                        break;
                    case "بهمن":
                        MonthCount = 11;
                        break;
                    case "اسفند":
                        MonthCount = 12;
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// بدست اوردن   روز شمسی
        /// </summary>
        /// <returns></returns>      
        public int GetNumberDayInMonth()
        {
            int Res;
            try
            {
                PersianCalendar DateFme = new PersianCalendar();
                Res = DateFme.GetDayOfMonth(DateTime.Now);
            }
            catch
            {
                Res = 0;
            }
            return Res;
        }
        /// <summary>
        ///  تاریخ یک ماه  به جلو
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgCalender.CurrentCell.Value != "")
                {
                    CountMonth();
                    MonthCount = MonthCount + 1;
                    DateShamsi = lblYear.Text + "/" + (MonthCount) + "/" + "01";
                    ConvertToGerigorian(DateShamsi, ref shamsiDayName);
                    DataGridFill(shamsiDayName, Convert.ToInt32(dgCalender.CurrentCell.Value));
                    //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
                    if (day == null)
                    {
                        day = prc.GetDayOfMonth(DateTime.Now).ToString();
                    }
                    GetYearAndMonth((MonthCount));
                    lblMonth.Text = MonthName;
                    if ((MonthCount) == 12)
                    {
                        btnNextMonth.Enabled = false;
                    }
                    btnBackMonth.Enabled = true;
                    TempMonthButton = (CalendarMonthButton)sender;
                    this.OnClick(e);
                    lblDate.Text = shamsiDate;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        ///  تاریخ یک ماه  به عقب
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackMonth_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCalender.CurrentCell.Value != "")
                {
                    CountMonth();
                    MonthCount = MonthCount - 1;
                    DateShamsi = lblYear.Text + "/" + (MonthCount) + "/" + "01";
                    ConvertToGerigorian(DateShamsi, ref shamsiDayName);
                    DataGridFill(shamsiDayName, Convert.ToInt32(dgCalender.CurrentCell.Value));
                    //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
                    GetYearAndMonth((MonthCount));
                    lblMonth.Text = MonthName;
                    if ((MonthCount) == 1)
                    {
                        btnBackMonth.Enabled = false;
                    }
                    btnNextMonth.Enabled = true;
                    TempMonthButton = (CalendarMonthButton)sender;
                    this.OnClick(e);
                    lblDate.Text = shamsiDate;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        ///  تاریخ یک سال  به جلو
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextYear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCalender.CurrentCell.Value != "")
                {
                    yearCount = (Int32.Parse(lblYear.Text) + 1);
                    CountMonth();
                    DateShamsi = (Int32.Parse(lblYear.Text) + 1) + "/" + MonthCount + "/" + "01";
                    ConvertToGerigorian(DateShamsi, ref shamsiDayName);
                    DataGridFill(shamsiDayName, Convert.ToInt32(dgCalender.CurrentCell.Value));
                    //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
                    GetYearAndMonth(MonthCount);
                    lblMonth.Text = MonthName;
                    lblYear.Text = (Int32.Parse(lblYear.Text) + 1).ToString();
                    TempYearButton = (CalendarYearButton)sender;
                    this.OnClick(e);
                    lblDate.Text = shamsiDate;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        ///  تاریخ یک سال  به عقب
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackYear_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgCalender.CurrentCell.Value != "")
                {

                    yearCount = (Int32.Parse(lblYear.Text) - 1);
                    CountMonth();
                    DateShamsi = (Int32.Parse(lblYear.Text) - 1) + "/" + MonthCount + "/" + "01";
                    ConvertToGerigorian(DateShamsi, ref shamsiDayName);
                    DataGridFill(shamsiDayName, Convert.ToInt32(dgCalender.CurrentCell.Value));
                    //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
                    GetYearAndMonth(MonthCount);
                    lblMonth.Text = MonthName;

                    lblYear.Text = (Int32.Parse(lblYear.Text) - 1).ToString();
                    TempYearButton = (CalendarYearButton)sender;
                    this.OnClick(e);
                    lblDate.Text = shamsiDate;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// بدست آوردن این هفته به فارسی
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string GetNameDay(string Name)
        {
            if (Name.Equals("Saturday"))
                return "شنبه";
            else if (Name.Equals("Sunday"))
                return "یکشنبه";
            else if (Name.Equals("Monday"))
                return "دوشنبه";
            else if (Name.Equals("Tuesday"))
                return "سه شنبه";
            else if (Name.Equals("Wednesday"))
                return "چهارشنبه";
            else if (Name.Equals("Thursday"))
                return "پنجشنبه";
            else if (Name.Equals("Friday"))
                return "جمعه";
            else
                return "";

        }



        /// <summary>
        /// با کلیک بر روی دکمه امروز تاریخ روز را نمایش می دهد
        /// تاریخ ماه و سال را سیستم گرفته و با تعیین روز اول ماه تیبل را پر می کند
        /// و سپس تاریخ روز را نمایش می دهد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToday_Click(object sender, EventArgs e)
        {
            try
            {
                MonthCount = prc.GetMonth(DateTime.Now);
                int Month = prc.GetMonth(DateTime.Now);
                Year = prc.GetYear(DateTime.Now).ToString();
                GetYearAndMonth(Month);
                lblMonth.Text = MonthName;
                lblYear.Text = Year;
                DateShamsi = Year + "/" + Month.ToString("00") + "/" + "01";
                ConvertToGerigorian(DateShamsi, ref shamsiDayName);
                DataGridFill(shamsiDayName, GetNumberDayInMonth());
                dgCalender.EndEdit();
                shamsiDay = Int32.Parse(dgCalender.CurrentCell.Value.ToString()).ToString("00");
                shamsiDate = Year + "/" + MonthCount.ToString("00") + "/" + Int32.Parse(dgCalender.CurrentCell.Value.ToString()).ToString("00");
                lblDate.Text = shamsiDate;
                btnBackMonth.Enabled = true;
                btnNextMonth.Enabled = true;
                this.OnClick(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Close()
        {
            this.Hide();
        }
    }

    public class CalendarMonthButton : Button
    {
        [DefaultValue(false)]
        public Boolean date
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
    public class CalendarYearButton : Button
    {
        [DefaultValue(false)]
        public Boolean date
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }




}
