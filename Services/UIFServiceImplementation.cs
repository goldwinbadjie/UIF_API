using UIF_API.Models;

namespace UIF_API.Services
{
    public class UIFServiceImplementation : IUIFService
    {
        private readonly HttpClient _httpClient;
        private string? BaseUrl;

        public UIFServiceImplementation(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            BaseUrl = configuration.GetValue<string>("BaseUrl");

        }

        public async Task<BankDetails?> GeBankingDetails(RequestByIdNumber request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/getBanks/geBankingDetails", request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<BankDetails>();

            return null;
        }

        public async Task<BankResponse?> GetAllBanks()
        {
            return await _httpClient.GetFromJsonAsync<BankResponse>($"{BaseUrl}/getBanks/getAllBanks");
        }

        public async Task<BranchCodeResponse?> GetBranchCode(BranchCodeRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/getBanks/getBranchCode", request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<BranchCodeResponse>();

            return null;
        }

        public async Task<LabourDolCentreResponse?> GetLabourCentres(string dolRegionID)
        {
            return await _httpClient.GetFromJsonAsync<LabourDolCentreResponse>($"{BaseUrl}/getLabourCentre/dolRegion/${dolRegionID}");
        }

        public async Task<OccupationResponse?> GetOccupations()
        {
            return await _httpClient.GetFromJsonAsync<OccupationResponse>($"{BaseUrl}/getOccupations");
        }

        public async Task<QualificationResponse?> GetQualifications()
        {
            return await _httpClient.GetFromJsonAsync<QualificationResponse>($"{BaseUrl}/getQualifications");
        }

        public async Task<UserVerificationResponse?> GetUfilingUserValidation(UserModel user)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/getUfilingUserValidation", user);
            return await response.Content.ReadFromJsonAsync<UserVerificationResponse>();
        }

        public async Task<RegisterResponse?> Registeruser(UserModel user)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/registeruser", user);
            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }

        public async Task<GenericResponse?> SaveAddressDetails(PostalAddress request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/getPostal/saveAddressDetails", request);
            return await response.Content.ReadFromJsonAsync<GenericResponse>();
        }

        public async Task<ForgotPasswordResponse?> SaveForgetPassword(ForgotPasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/saveForgetPassword", request);
            return await response.Content.ReadFromJsonAsync<ForgotPasswordResponse>();
        }

        public async Task<ForgotPasswordResponse?> SaveResetPassword(ResetPasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/saveResetPassword", request);
            return await response.Content.ReadFromJsonAsync<ForgotPasswordResponse>();
        }

        public async Task<SendBankDetailsResponse?> SendBankDetails(SendBankDetailsRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/getBanks/sendBankdetails", request);
            return await response.Content.ReadFromJsonAsync<SendBankDetailsResponse>();
        }
    }
}
