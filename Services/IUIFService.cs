using UIF_API.Models;

namespace UIF_API.Services
{
    public interface IUIFService
    {
        Task<BankDetails?> GeBankingDetails(RequestByIdNumber request);
        Task<BankResponse?> GetAllBanks();
        Task<BranchCodeResponse?> GetBranchCode(BranchCodeRequest request);
        Task<UserVerificationResponse?> GetUfilingUserValidation(UserModel user);
        Task<RegisterResponse?> Registeruser(UserModel user);
        Task<ForgotPasswordResponse?> SaveForgetPassword(ForgotPasswordRequest request);
        Task<ForgotPasswordResponse?> SaveResetPassword(ResetPasswordRequest request);
        Task<SendBankDetailsResponse?> SendBankDetails(SendBankDetailsRequest request);
        Task<GenericResponse?> SaveAddressDetails(PostalAddress request);
        Task<OccupationResponse?> GetOccupations();
        Task<QualificationResponse?> GetQualifications();
        Task<LabourDolCentreResponse?> GetLabourCentres(string dolRegionID);

    }
}
