

using MediatR;
using ReecsPortal.Application.DTOs.Auth;
using ReecsPortal.Application.Interfaces;

namespace ReecsPortal.Application.Auth.Commands
{   
    public record LoginCommand(LoginDto LoginDto) : IRequest<AuthResponseDto>;
    public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, AuthResponseDto>
    {
        public Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return authService.Login(request.LoginDto);
        }
    }
}
