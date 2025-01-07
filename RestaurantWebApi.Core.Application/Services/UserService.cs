using AutoMapper;
using RestaurantWebApi.Core.Application.Dtos.Account;
using RestaurantWebApi.Core.Application.Dtos.Users;
using RestaurantWebApi.Core.Application.Interfaces.Services;

namespace RestaurantWebApi.Core.Application.Services;

public class UserService : IUserService
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public UserService(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse> LoginAsync(LoginDto dto)
    {
        AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(dto);
        AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
        return userResponse;
    }
    public async Task SignOutAsync()
    {
        await _accountService.SignOutAsync();
    }

    public async Task<RegisterResponse> RegisterWaiterAsync(UserSaveDto dto, string origin)
    {
        RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(dto);
        return await _accountService.RegisterWaiterUserAsync(registerRequest, origin);
    }

    public async Task<RegisterResponse> RegisterAdminAsync(UserSaveDto dto, string origin)
    {
        RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(dto);
        return await _accountService.RegisterAdminUserAsync(registerRequest, origin);
    }

    public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordDto dto, string origin)
    {
        ForgotPasswordRequest forgotRequest = _mapper.Map<ForgotPasswordRequest>(dto);
        return await _accountService.ForgotPasswordAsync(forgotRequest, origin);
    }

    public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordDto dto)
    {
        ResetPasswordRequest resetRequest = _mapper.Map<ResetPasswordRequest>(dto);
        return await _accountService.ResetPasswordAsync(resetRequest);
    }
}