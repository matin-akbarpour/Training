namespace Gateway.Models
{
    public class TransferSatnaResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
        public int RsCode { get; set; }
        public string TransactionDate { get; set; }
        public long Amount { get; set; }
        public string RecieverName { get; set; }
        public string RecieverlastName { get; set; }
        public string DestinationDepNum { get; set; }
        public string UserReferenceNumber { get; set; }
        public string TransactionCode { get; set; }
    }
}
