namespace UIF_API.Models
{
    public class ResetPasswordRequest
    {
        public string? UserName { get; set; }
        public string? NewPassword { get; set; }
    }
}
