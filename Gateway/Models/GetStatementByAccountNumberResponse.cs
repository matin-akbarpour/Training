using System.Collections.Generic;

namespace Gateway.Models
{
    public class GetStatementByAccountNumberResponse
    {
        public int RsCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ResultData2> ResultData { get; set; }

        public class ResultData2
        {
            public string AccountNumber { get; set; }
            public long? BalanceAmount { get; set; }
            //public string BalanceAmount { get; set; }
            public long? Bed { get; set; }
            //public string Bed { get; set; }
            public long? Bes { get; set; }
            //public string Bes { get; set; }
            public string TransactionDate { get; set; }
            public string TransactionTime { get; set; }
            public string SideNationalCode { get; set; }
            public string DocNumber { get; set; }
            public string OperatorCode { get; set; }
            public string SpecialNumber { get; set; }
            public string OptionalDescription { get; set; }
            public string SideImd { get; set; }
            public string TerminalNumber { get; set; }
            public string AcquirerImd { get; set; }
            public string SideCardNumber { get; set; }
            public string PursuitNumber { get; set; }
            public string SideName { get; set; }
            public string SideAccountNumber { get; set; }
            public string Rrn { get; set; }
            public string AcquireCode { get; set; }
            public string AcquireName { get; set; }
            public string CardNumber { get; set; }
        }
    }
}
