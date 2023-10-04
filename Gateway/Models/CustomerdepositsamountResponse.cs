namespace Gateway.Models
{
    public class CustomerdepositsamountResponse
    {
        public string Message { get; set; }
        public int RsCode { get; set; }
        public bool IsSuccess { get; set; }
        public ResultData1 ResultData { get; set; }

        public class ResultData1
        {
            public long? CurrentAmount { get; set; }
            //public string CurrentAmount { get; set; }
            public long? CurrentWithdrawableAmount { get; set; }
            //public string CurrentWithdrawableAmount { get; set; }
        }
    }
}
