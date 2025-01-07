using RestaurantWebApi.Core.Application.Dtos.Account;
using RestaurantWebApi.Core.Application.Dtos.Users;

namespace RestaurantWebApi.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginDto dto);
        Task SignOutAsync();
        Task<RegisterResponse> RegisterWaiterAsync(UserSaveDto dto, string origin);
        Task<RegisterResponse> RegisterAdminAsync(UserSaveDto dto, string origin);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordDto dto, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordDto dto);
    }
}