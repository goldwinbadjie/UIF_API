namespace UIF_API.Models
{
    public class UserVerificationResponse
    {
        public string? TradeName { get; set; }
        public string? Initials { get; set; }
        public bool Response { get; set; }
        public string? ResponseMessage { get; set; }
    }
}
