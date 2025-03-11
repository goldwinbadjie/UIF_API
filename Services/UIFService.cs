using UIF_API.Models;

namespace UIF_API.Services
{
    public class UIFService : IUIFService
    {
        public UserVerificationResponse? GetUfilingUserValidation(UserModel user)
        {
            return new UserVerificationResponse
            {
                Initials = "P",
                Response = true,
                ResponseMessage = "Success",
                TradeName = null
            };
        }

        public RegisterResponse? Registeruser(UserModel user)
        {
            return new RegisterResponse
            {
                UserName = user.UserName
            };
        }

        public ForgotPasswordResponse? SaveForgetPassword(ForgotPasswordRequest request)
        {
            return new ForgotPasswordResponse
            {
                Response = true,
                ResponseMessage = "Success"
            };
        }

        public ForgotPasswordResponse? SaveResetPassword(ResetPasswordRequest request)
        {
            return new ForgotPasswordResponse
            {
                Response = true,
                ResponseMessage = "Success"
            };
        }
    }
}
