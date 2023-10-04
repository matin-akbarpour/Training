namespace WinUI.BaseDataEntry
{
    public class BaseData
    {

        public BaseData()
        {

        }

        public char ValidNumber(char key)
        {
            if (key == 8)
                return key;
            if (System.Text.RegularExpressions.Regex.IsMatch(key.ToString(), "[^0-9]"))
                return (char)0;
            else
                return key;
        }
    }
}
