using UIF_API.Models;

namespace UIF_API.Services
{
    public interface IUIFService
    {
        RegisterResponse? Registeruser(UserModel user);
        ForgotPasswordResponse? SaveForgetPassword(ForgotPasswordRequest request);
        ForgotPasswordResponse? SaveResetPassword(ResetPasswordRequest request);
        UserVerificationResponse? GetUfilingUserValidation(UserModel user);
        BankResponse? GetAllBanks();
        BranchCodeResponse? GetBranchCode(BranchCodeRequest branchCodeRequest);
        SendBankDetailsResponse? SendBankDetails(SendBankDetailsRequest sendBankDetailsRequest);

    }
}
