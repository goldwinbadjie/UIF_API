namespace UIF_API.Models
{
    public class SendBankDetailsRequest
    {
        public int ApplicationNumber { get; set; }
        public int BankBranchID { get; set; }
        public string? AccountNumber { get; set; }
        public int AccountType { get; set; }
        public string? AccountHolder { get; set; }
        public string? BranchCode { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdateBy { get; set; }
        public string? UpdateDate { get; set; }
    }

    public class SendBankDetailsResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
