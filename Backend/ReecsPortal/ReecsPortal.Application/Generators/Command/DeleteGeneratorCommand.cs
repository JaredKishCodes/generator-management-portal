using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.Interfaces;

namespace ReecsPortal.Application.Generators.Command
{
    public record DeleteGeneratorCommand(int genCode) : IRequest<bool>;
    public class DeleteGeneratorCommandHandler(IGeneratorService generatorService)
        : IRequestHandler<DeleteGeneratorCommand, bool>
    {
        public async Task<bool> Handle(DeleteGeneratorCommand request, CancellationToken cancellationToken)
        {
             await generatorService.DeleteGeneratorAsync(request.genCode);
            return true;
        }
    }
}
