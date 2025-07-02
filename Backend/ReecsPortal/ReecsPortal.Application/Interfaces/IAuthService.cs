
using ReecsPortal.Application.DTOs.Auth;

namespace ReecsPortal.Application.Interfaces
{
    public interface IAuthService
    {
       Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<AuthResponseDto> Register(RegisterDto registerDto);
    }
}
