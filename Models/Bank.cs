namespace UIF_API.Models
{
    public class Bank
    {
        public int BankID { get; set; }
        public string? BankName { get; set; }
    }

    public class BankResponse
    {
        public List<Bank>? BankInfo { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
