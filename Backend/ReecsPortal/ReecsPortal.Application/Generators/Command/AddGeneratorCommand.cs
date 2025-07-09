

using MediatR;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.Interfaces;

namespace ReecsPortal.Application.Generators.Command
{
    public record AddGeneratorCommand(GenRequest gen) : IRequest<GenResponse>;
    public class AddGeneratorCommandHandler(IGeneratorService generatorService)
        : IRequestHandler<AddGeneratorCommand, GenResponse>
    {
        public async Task<GenResponse> Handle(AddGeneratorCommand request, CancellationToken cancellationToken)
        {
            return await generatorService.CreateGeneratorAsync(request.gen);
        }
    }
}
