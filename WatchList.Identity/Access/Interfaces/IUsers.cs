using WatchList.Core.Models;
using WatchList.Identity.Models.Requests;
using WatchList.Identity.Models.Responses;

namespace WatchList.Identity.Access.Interfaces
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
        Task<LogoutResponse> LogoutAsync(User user);
        Task<ForceLogoutResponse> ForceLogoutAsync(User user);
    }
}
