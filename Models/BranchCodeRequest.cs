namespace UIF_API.Models
{
    public class BranchCodeRequest
    {
        public int BankID { get; set; }
    }

    public class BranchCodeResponse
    {
        public int BankID { get; set; }
        public string? BankName { get; set; }
        public int BankBranchID { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
