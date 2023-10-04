namespace Gateway.Models
{
    public class TransferPayaResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
        public int RsCode { get; set; }
        public string TransactionDate { get; set; }
        public long Amount { get; set; }
        public string RecieverFullName { get; set; }
        public string DestinationIban { get; set; }
        public string Description { get; set; }
        public string EndToEndId { get; set; }
        public string TransactionCode { get; set; }
    }
}
