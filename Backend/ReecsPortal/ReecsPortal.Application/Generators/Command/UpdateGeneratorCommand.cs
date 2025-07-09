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
    public record UpdateGeneratorCommand(UpdateGenRequest gen, int genCode) : IRequest<GenResponse>;
    public class UpdateGeneratorCommandHandler(IGeneratorService generatorService)
        : IRequestHandler<UpdateGeneratorCommand, GenResponse>
    {
        public async Task<GenResponse> Handle(UpdateGeneratorCommand request, CancellationToken cancellationToken)
        {
            return await generatorService.UpdateGeneratorAsync(request.gen, request.genCode);
        }
    }
}
