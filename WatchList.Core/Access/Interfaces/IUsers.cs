using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;
using WatchList.Core.Models;
using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Access.Interfaces
{
    public interface IUsers
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest? request);
        Task<ReauthenticateResponse> ReauthenticateAsync(ReauthenticateRequest? request);
        Task<WhoAmIResponse> WhoAmIAsync(User user);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<CheckPasswordResetResponse> CheckPasswordResetAsync(CheckPasswordResetRequest request);
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<ConfirmEmailAddressResponse> ConfirmEmailAddressAsync(ConfirmEmailAddressRequest request);
        Task<RequestEmailAddressConfirmationResponse> RequestEmailAddressConfirmationAsync(RequestEmailAddressConfirmationRequest request);
    }
}
