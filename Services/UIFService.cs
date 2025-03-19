using Azure;
using UIF_API.Models;

namespace UIF_API.Services
{
    public class UIFService : IUIFService
    {
        public UIFService()
        {
        }

        public async Task<BankDetails?> GeBankingDetails(RequestByIdNumber request)
        {
            if (request == null || string.IsNullOrEmpty(request.IdNumber))
            {
                return null;
            }

            var mockData = new List<BankDetails>
            {
                new BankDetails
                {
                    ApplicationNumber = 101,
                    BankBranchID = 1,
                    AccountNumber = "123456789",
                    AccountType = 1,
                    AccountHolder = "John Doe",
                    BranchCode = "XYZ123",
                    CreatedBy = "Admin",
                    UpdateBy = "Admin",
                    UpdateDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                    IdNumber = "ID123456"
                },
                new BankDetails
                {
                    ApplicationNumber = 102,
                    BankBranchID = 2,
                    AccountNumber = "987654321",
                    AccountType = 2,
                    AccountHolder = "Jane Smith",
                    BranchCode = "ABC456",
                    CreatedBy = "Admin",
                    UpdateBy = "Admin",
                    UpdateDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                    IdNumber = "ID654321"
                }
            };

            return await Task.FromResult(mockData.FirstOrDefault(b => b.IdNumber == request.IdNumber));
        }

        public async Task<BankResponse?> GetAllBanks()
        {
            var response = new BankResponse
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

            return await Task.FromResult(response);
        }

        public async Task<BranchCodeResponse?> GetBranchCode(BranchCodeRequest request)
        {
            var response = request.BankID == 185
                ? new BranchCodeResponse
                {
                    BankID = 185,
                    BankName = "VBS MUTUAL BANK",
                    BankBranchID = 13018,
                    BranchCode = "588000",
                    BranchName = "LOUIS TRICHARDT",
                    Message = "success",
                    Success = true
                }
                : new BranchCodeResponse
                {
                    BankID = request.BankID,
                    Message = "Bank ID not found",
                    Success = false
                };

            return await Task.FromResult(response);
        }

        public async Task<LabourDolCentreResponse?> GetLabourCentres(string dolRegionID)
        {
            var centres = new List<LabourDolCentre>
            {
                new LabourDolCentre{ DolCentre = "Atteridgeville", DolCentreId = 8}
            };

            var response = new LabourDolCentreResponse
            {
                DolCentres = centres,
                Message = "success",
                Success = true
            };
            return await Task.FromResult(response);
        }

        public async Task<OccupationResponse?> GetOccupations()
        {
            var occupations = new List<Occupation>
        {
            new Occupation { OccupationName = "(D) HAIR DRESSER INDUSTRY", OccupationCode = "0721" },
            new Occupation { OccupationName = "(E) OTHER INDUSTRIES", OccupationCode = "0723" },
            new Occupation { OccupationName = "ACCOMMODATION AND REFRESHMENTS", OccupationCode = "1102" },
            new Occupation { OccupationName = "ADMINISTRATIVE", OccupationCode = "0604" },
            new Occupation { OccupationName = "BRICKLAYER", OccupationCode = "0713" },
            new Occupation { OccupationName = "BUILDING INDUSTRY", OccupationCode = "1003" },
            new Occupation { OccupationName = "CARPENTER AND JOINER", OccupationCode = "0715" },
            new Occupation { OccupationName = "CHEMICAL AND RUBBER INDUSTRY", OccupationCode = "1009" },
            new Occupation { OccupationName = "CLERICAL", OccupationCode = "0605" },
            new Occupation { OccupationName = "CLOTHING INDUSTRY", OccupationCode = "1005" },
            new Occupation { OccupationName = "DOMESTIC WORKER", OccupationCode = "0025" },
            new Occupation { OccupationName = "ELECTRICAL WIREMAN", OccupationCode = "0711" },
            new Occupation { OccupationName = "ELECTRICIAN (GENERAL ENGINEERING IND)", OccupationCode = "0701" },
            new Occupation { OccupationName = "FARMING MACHINE OPERATOR", OccupationCode = "1201" },
            new Occupation { OccupationName = "FITTER AND/OR TURNER", OccupationCode = "0702" },
            new Occupation { OccupationName = "FOOD; DRINK AND TOBACCO INDUSTRY", OccupationCode = "1006" },
            new Occupation { OccupationName = "GENERAL FARM WORKER", OccupationCode = "1301" },
            new Occupation { OccupationName = "GLASS; CEMENT; BRICK AND TILES INDUSTRY", OccupationCode = "1008" },
            new Occupation { OccupationName = "MANAGERIAL AND EXECUTIVE", OccupationCode = "0603" },
            new Occupation { OccupationName = "MECHANIC", OccupationCode = "0707" },
            new Occupation { OccupationName = "MINING INDUSTRY", OccupationCode = "0801" },
            new Occupation { OccupationName = "MOTOR ENGINEERING INDUSTRY", OccupationCode = "1002" },
            new Occupation { OccupationName = "OPERATORS AND SEMI-SKILLED WORKER", OccupationCode = "1001" },
            new Occupation { OccupationName = "OTHER", OccupationCode = "0705" },
            new Occupation { OccupationName = "OTHER INDUSTRIES", OccupationCode = "1012" },
            new Occupation { OccupationName = "PAINTER", OccupationCode = "0716" },
            new Occupation { OccupationName = "PERSONAL", OccupationCode = "1103" },
            new Occupation { OccupationName = "PLASTER", OccupationCode = "0714" },
            new Occupation { OccupationName = "PLATER / BOILER MAKER", OccupationCode = "0704" },
            new Occupation { OccupationName = "PLUMBER", OccupationCode = "0712" },
            new Occupation { OccupationName = "PRINTING AND PAPER INDUSTRY", OccupationCode = "1010" },
            new Occupation { OccupationName = "PROFESSIONAL AND SEMI-PROFESSIONAL", OccupationCode = "0601" },
            new Occupation { OccupationName = "SALES AND RELATED WORK", OccupationCode = "0606" },
            new Occupation { OccupationName = "SECURITY", OccupationCode = "1101" },
            new Occupation { OccupationName = "SHELTERED EMPLOYMENT", OccupationCode = "1501" },
            new Occupation { OccupationName = "SHOE AND LEATHER INDUSTRY", OccupationCode = "1007" },
            new Occupation { OccupationName = "TECHNICAL", OccupationCode = "0602" },
            new Occupation { OccupationName = "TRANSPORT; DELIVERY AND COMMUNICATION", OccupationCode = "0901" },
            new Occupation { OccupationName = "UNCLASSIFIED", OccupationCode = "1601" },
            new Occupation { OccupationName = "UNSKILLED WORKER", OccupationCode = "1401" },
            new Occupation { OccupationName = "WELDER", OccupationCode = "0703" },
            new Occupation { OccupationName = "WOOD AND FURNITURE INDUSTRY", OccupationCode = "1004" }
        };

            var response = new OccupationResponse
            {
                Occupations = occupations,
                Message = "success",
                Success = true
            };

            return await Task.FromResult(response);
        }

        public async Task<QualificationResponse?> GetQualifications()
        {
            var qualifications = new List<Qualification>
        {
            new Qualification { QualificationId = 1, QualificationName = "SPECIAL SCHOOL CERTIFICATE" },
            new Qualification { QualificationId = 2, QualificationName = "BELOW STD. 6" },
            new Qualification { QualificationId = 3, QualificationName = "STD. 6 - 7" },
            new Qualification { QualificationId = 4, QualificationName = "STD. 8 - 9" },
            new Qualification { QualificationId = 5, QualificationName = "STD. 10" },
            new Qualification { QualificationId = 6, QualificationName = "ABOVE STD. 10" }
        };


            var response = new QualificationResponse
            {
                Qualifications = qualifications,
                Message = "success",
                Success = true
            };
            return await Task.FromResult(response);
        }

        public async Task<UserVerificationResponse?> GetUfilingUserValidation(UserModel user)
        {
            var response = new UserVerificationResponse
            {
                Initials = "P",
                Response = true,
                ResponseMessage = "Success",
                TradeName = null
            };

            return await Task.FromResult(response);
        }

        public async Task<RegisterResponse?> Registeruser(UserModel user)
        {
            var response = new RegisterResponse
            {
                UserName = user.UserName
            };

            return await Task.FromResult(response);
        }

        public async Task<GenericResponse?> SaveAddressDetails(PostalAddress request)
        {
            var response = new GenericResponse
            {
                Message = "Successful saved address details",
                Success = true
            };

            return await Task.FromResult(response);
        }

        public async Task<ForgotPasswordResponse?> SaveForgetPassword(ForgotPasswordRequest request)
        {
            var response = new ForgotPasswordResponse
            {
                Response = true,
                ResponseMessage = "Success"
            };

            return await Task.FromResult(response);
        }

        public async Task<ForgotPasswordResponse?> SaveResetPassword(ResetPasswordRequest request)
        {
            var response = new ForgotPasswordResponse
            {
                Response = true,
                ResponseMessage = "Success"
            };

            return await Task.FromResult(response);
        }

        public async Task<SendBankDetailsResponse?> SendBankDetails(SendBankDetailsRequest request)
        {
            var response = new SendBankDetailsResponse
            {
                Message = "Successfully saved banking details",
                Success = true
            };

            return await Task.FromResult(response);
        }
    }
}
