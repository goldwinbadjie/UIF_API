using UIF_API.Models;

namespace UIF_API.Services
{
    public class UIFService : IUIFService
    {
        public BankResponse? GetAllBanks()
        {
            return new BankResponse
            {
                BankInfo = new List<Bank>
            {
                new Bank { BankID = 172, BankName = "ABN-AMRO BANK" },
                new Bank { BankID = 179, BankName = "ABSA" },
                new Bank { BankID = 169, BankName = "ABSA(VOL,TRU,UNT,UNI,ALLI)" },
                new Bank { BankID = 173, BankName = "ABSA-ITHALA" },
                new Bank { BankID = 167, BankName = "AFRICAN BANK" }
            },
                Message = "success",
                Success = true
            };
        }

        public BranchCodeResponse? GetBranchCode(BranchCodeRequest branchCodeRequest)
        {
            if (branchCodeRequest.BankID == 185)
            {
                return new BranchCodeResponse
                {
                    BankID = 185,
                    BankName = "VBS MUTUAL BANK",
                    BankBranchID = 13018,
                    BranchCode = "588000",
                    BranchName = "LOUIS TRICHARDT",
                    Message = "success",
                    Success = true
                };
            }
            return new BranchCodeResponse
            {
                BankID = branchCodeRequest.BankID,
                Message = "Bank ID not found",
                Success = false
            };
        }

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

        public SendBankDetailsResponse? SendBankDetails(SendBankDetailsRequest sendBankDetailsRequest)
        {
            return new SendBankDetailsResponse
            {
                Message = "Successfully saved banking details",
                Success = true
            };
        }
    }
}
