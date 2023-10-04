using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Specialized;
//using WindowsFormsApplication3;

namespace SBS.WinUIControls
{
    public class ThousandsTextBox : TextBox
    {
        public ThousandsTextBox()
        {
            InitializeComponent();
        }
        byte start = 0;
        long tmpNumber = 0;
        char tmpSign = ' ';
        bool ereaser = false;
        string[] masks = new string[] { "#", "##", "###", "#,###", "##,###", "###,###", "#,###,###", "##,###,###", "###,###,###", "#,###,###,###" };

        

        protected override void OnKeyUp(KeyEventArgs e)
        {
            try
            {
                ThreeSepratorUp(e.KeyValue);
            }
            catch { }
        }

        protected override void OnEnter(EventArgs e)
        {
            if (this.Text == "0" && this.Enabled && !this.ReadOnly)
            {
                this.Text = "";
            }
        }

        string _currentTypedValue = "";
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown && this.Enabled==true && this.ReadOnly==false )
            {
                Cal();
            }
            if (this.ReadOnly == false)
                ThreeSepratorDown(e.KeyValue);
            base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if(this.ReadOnly == false)
                e.KeyChar = ValidNumber(e.KeyChar);
            else
            {
                e.KeyChar = (char)0;
            }
        }
        public string CurrentTypedValue
        {
            get { return _currentTypedValue; }
            set { _currentTypedValue = value; }
        }

        int _value = 0;
        public int CurrentValue
        {
            get
            {
                _value = CalculateValue();
                return _value;
            }
            set
            {
                _value = value;
                PlaceValueInTextBox(_value);
            }
        }

        private void PlaceValueInTextBox(int _value)
        {
            string val = Convert.ToString(_value);
            if (_value > 0)
            {
                Text = AddCommas(val);
                Select(0, Text.Length);
            }
        }

        private int CalculateValue()
        {
            string val = SubtractCommas(Text);

            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
            }
            return 0;
        }

        private string AddCommas(string text)
        {
            string mask = "";
            if (text.Length > 0)
            {
                mask = masks[text.Length - 1];
            }

            for (int i = 0; i < text.Length; i++)
            {
                int index = mask.IndexOf('#');
                if (index >= 0)
                {
                    mask = mask.Insert(index, text[i].ToString());
                    mask = mask.Remove(index + 1, 1);
                }
            }

            return mask;
        }

        private string SubtractCommas(string text)
        {
            while (text.Contains(","))
            {
                text = text.Remove(text.IndexOf(','), 1);
            }

            return text;
        }

        public  bool IsNumeric(char val)
        {
            Regex patternMatcher = new Regex(@"\d");
            return patternMatcher.Match(val.ToString()).Success;
        }

        private char ValidNumber(char key)
        {
            string s;
            int SelStart;
            if (Text != string.Empty && SelectionStart != 0)
            {
                if (key.ToString() == "+")
                {
                    SelStart = SelectionStart;
                    Text = Text.Remove(SelectionStart, SelectionLength);
                    s = Text.Insert(SelStart, "000");
                    if (s.Length <= MaxLength)
                    {
                        Text = s;
                    }
                    Select(SelStart + 3, 0);
                }
                else if (key.ToString() == "-")
                {
                    SelStart = SelectionStart;
                    Text = Text.Remove(SelectionStart, SelectionLength);
                    s = Text.Insert(SelStart, "00");
                    if (s.Length <= MaxLength)
                    {
                        Text = s;
                    }
                    Select(SelStart + 2, 0);
                }
            }
            if ((int)key == 8) return key;
            if (key != '0' && key != '1' && key != '2' && key != '3' && key != '4' && key != '5' && key != '6' && key != '7' && key != '8' && key != '9') return (char)0; else return key;
        }
        int SelStart, counter, counter1;
        private void ThreeSepratorDown(int key)
        {
            if (key == 13)
            {
                return;
            }
            counter = 0;
            SelStart = SelectionStart;
            Text = Text.Remove(SelectionStart, SelectionLength);
            for (int i = 0; i < Text.Length; i++)
            {
                if (i >= SelStart) break;
                if (Text[i] == ',') counter++;
            }
            Text = Text.Replace(",", "");
            //if (((key >= 48 && key <= 57) || (key >= 96 && key <= 105)) || key == 107 || key == 109)
            //{
            Select(SelStart - counter, 0);
            //}

        }
        private void ThreeSepratorUp(int key)
        {
            //if (((key >= 48 && key <= 57) || (key >= 96 && key <= 105))|| key==107 || key==109)
            //{
            counter1 = 0;
            if (Text.Trim() != "")
            {
                long k = Convert.ToInt64(Text.Replace(",",""));
                Text = k.ToString("#,##0");
            }
            for (int i = 0; i < Text.Length; i++)
            {
                if (i >= SelStart) break;
                if (Text[i] == ',') counter1++;
            }
            SelStart -= counter;
            if (key == 107) Select(SelStart + counter1 + 4, 0);
            else if (key == 109) Select(SelStart + counter1 + 2, 0);
            else if (((key >= 48 && key <= 57) || (key >= 96 && key <= 105)) || key == 39) Select(SelStart + counter1 + 1, 0);
            else if (key == 37 || key == 8) Select(SelStart + counter1 - 1, 0);
            else Select(SelStart + counter1, 0);

        }
        short sign_flag;
        public string NumberToText(long N)
        {
            if (text=="")
            {
                return "";
            }
            // N = (int)(N);
            if (N < 0)
            {
                sign_flag = -1;
                N = -N;
            }
            else
            {
                sign_flag = 1;
            }

            //if (N > 999999999999999) 
            //{
            //    return " ";
            //}

            if (N == 0)
            {
                return "صفر";
            }

            //--------------- Source ----------------'
            string st;
            short i;
            long j;
            string[] a = { "", "", " هزار", " ميليون", " ميليارد", " بیلیون", " بیلیارد", " تریلیون", " تریلیارد", " کادریلیون" };
            st = " ";
            for (i = 5; i >= 0; i--)
            {
                if (N != Mod_(N, Tavan(10, (i * 3))))
                {
                    j = N / (Tavan(10, (i * 3)));
                    st += f(j);
                    st += a[i + 1];
                    if (Mod_(N, Tavan(10, (i * 3))) == 0)
                    {
                        // st = st;
                    }
                    else
                    {
                        st += " و ";
                    }
                    N = Mod_(N, Tavan(10, (i * 3)));
                }
            }
            if (sign_flag > 0)
            {
                return st;
            }
            else
            {
                return "منفي" + st;
            }
        }
        public long Mod_(long X, long Y)
        {
            int B = (int)(X / Y);
            return X - B * Y;
        }
        long t;
        private long Tavan(long x, long y)
        {
            t = 1;
            for (int i = 0; i < y; i++)
            {
                t *= x;
            }
            return t;
        }
        public string f(long n)
        {
            if (n < 100)
            {
                return f1to100(n);
            }
            else
            {
                return f1to1000(n);
            }
        }
        public string f1to100(long n)
        {
            string X, Y;
            string[] str_array = { "", "يك", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه", "ده", "يازده", "دوازده", "سيزده", "چهارده", "پانزده", "شانزده", "هفده", "هيجده", "نوزده", "بيست" };
            string[] ten_array = { "", "ده", "بيست", "سي", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
            if (n <= 20)
            {
                return str_array[(int)n];
            }
            else
            {
                if (Mod_(n, 10) == 0)//اگر باقيمانده برابر صفر بود
                {
                    return ten_array[(int)n / 10];
                }
                else
                {
                    X = str_array[(int)Mod_(n, 10)];
                    Y = ten_array[(int)(n / 10)];
                    return Y.ToString() + " و " + X.ToString();
                }
            }
        }
        public string f1to1000(long n)
        {
            long r, D;
            string t;
            string[] h = { "", "يكصد", "دويست", "سيصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
            r = Mod_(n, 100);
            D = (int)(n / 100);
            if (r == 0)
            {
                t = "";
            }
            else
            {
                t = " و " + f1to100(r);
            }
            if (r == n)
            {
                return f1to100(n);
            }
            else
            {
                return h[(int)D] + t;
            }
        }
        string txt = "";
        public string text
        {
            get
            {
                txt = (Text.Replace(",", "")).ToString();
                if (txt != "")
                    return txt.ToString();
                else
                    return "0";
            }
            set
            {
                if (value != "" && value != null)
                {
                    long k = Convert.ToInt64(value.Replace(",", ""));
                    Text = k.ToString("#,##0");
                }
                //else
                //{
                //    Text = "0";
                //}
            }
        }
        string ftxt;
        public string Farsitext
        {
            get
            {
                if (text.Trim() != "") ftxt = (NumberToText(Convert.ToInt64(text.Trim())).ToString());
                return ftxt.ToString();
            }
        }
        private void Cal()
        {
            //tmpNumber = 0;
            //tmpSign = ' ';
            //Calculater user = new Calculater();// Calculater();
            //user.btn0.Click += new EventHandler(btn0_Click);
            //user.btn00.Click += new EventHandler(btn00_Click);
            //user.btn1.Click += new EventHandler(btn1_Click);
            //user.btn2.Click += new EventHandler(btn2_Click);
            //user.btn3.Click += new EventHandler(btn3_Click);
            //user.btn4.Click += new EventHandler(btn4_Click);
            //user.btn5.Click += new EventHandler(btn5_Click);
            //user.btn6.Click += new EventHandler(btn6_Click);
            //user.btn7.Click += new EventHandler(btn7_Click);
            //user.btn8.Click += new EventHandler(btn8_Click);
            //user.btn9.Click += new EventHandler(btn9_Click);
            //user.btnPlus.Click += new EventHandler(btnPlus_Click);
            //user.btnDiv.Click += new EventHandler(btnDiv_Click);
            //user.btnEqual.Click += new EventHandler(btnEqual_Click);
            //user.btnMin.Click += new EventHandler(btnMin_Click);
            //user.btnMul.Click += new EventHandler(btnMul_Click);
            //ToolStripControlHost toolhost = new ToolStripControlHost(user);
            //ToolStripDropDown tooldown = new ToolStripDropDown();
            //tooldown.Items.Add(toolhost);
            //tooldown.Show(this, new Point(-3, this.Location.Y)); 
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            SetNumber("0");
        }
        private void btn00_Click(object sender, EventArgs e)
        {
            SetNumber("00");
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            SetNumber("1");
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            SetNumber("2");
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            SetNumber("3");
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            SetNumber("4");
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            SetNumber("5");
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            SetNumber("6");
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            SetNumber("7");
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            SetNumber("8");
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            SetNumber("9");
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            if (!ereaser)
            {
                ereaser = true;
                tmpNumber = Cal(Convert.ToInt64(text));
            }
            tmpSign = '-';
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (!ereaser)
            {
                ereaser = true;
                tmpNumber = Cal(Convert.ToInt64(text));
            }
            tmpSign = '+';

        }
        private void btnMul_Click(object sender, EventArgs e)
        {
            if (!ereaser)
            {
                ereaser = true;
                tmpNumber = Cal(Convert.ToInt64(text));
            }
            tmpSign = '*';
        }
        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (!ereaser)
            {
                ereaser = true;
                tmpNumber = Cal(Convert.ToInt64(text));
            }
            tmpSign = '/';
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!ereaser)
            {
                ereaser = true;
                tmpNumber = Cal(Convert.ToInt64(text));
            }
        }
        private void SetNumber(string str)
        {
            if (ereaser)
            {
                text = str;
                ereaser = false;
            }
            else
            {
                text += str;
            }
        }
        private long Cal(long num)
        {
            switch (tmpSign)
            {
                case '+': num = tmpNumber + num;
                    break;
                case '-': num = tmpNumber - num;
                    break;
                case '*': num = tmpNumber * num;
                    break;
                case '/': num = tmpNumber / num;
                    break;
                case '=': num = tmpNumber + num;
                    break;
                default: break;
            }
            tmpSign = ' ';
            text = num.ToString();
            return num;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ThousandsTextBox
            // 
            Text = "";
            this.Enter += new System.EventHandler(this.ThousandsTextBox_Enter);
            this.ResumeLayout(false);
        }
        
        private void ThousandsTextBox_Enter(object sender, EventArgs e)
        {
            try
            {
                start = 1;
            }
            catch { }
        }

       

    }
}

