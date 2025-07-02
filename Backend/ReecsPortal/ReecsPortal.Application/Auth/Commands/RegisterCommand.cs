using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReecsPortal.Application.DTOs.Auth;
using ReecsPortal.Application.Interfaces;

namespace ReecsPortal.Application.Auth.Commands
{   
    public record RegisterCommand(RegisterDto RegisterDto) : IRequest<AuthResponseDto>;
    public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        public Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return authService.Register(request.RegisterDto);
        }
    }
}
