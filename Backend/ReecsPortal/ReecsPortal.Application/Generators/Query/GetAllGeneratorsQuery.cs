using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.Interfaces;
using ReecsPortal.Domain.Interfaces;

namespace ReecsPortal.Application.Generators.Query
{   
    public record GetAllGeneratorsQuery() : IRequest<IEnumerable<GenResponse>>;
    public class GetAllGeneratorsQueryHandler(IGeneratorService generatorService,IGeneratorRepository genRepo,IMapper mapper)
                : IRequestHandler<GetAllGeneratorsQuery, IEnumerable<GenResponse>>
    {
        public async Task<IEnumerable<GenResponse>> Handle(GetAllGeneratorsQuery request, CancellationToken cancellationToken)
        {
            var gen = await generatorService.GetAllGeneratorsAsync();

            return mapper.Map<IEnumerable<GenResponse>>(gen);

            
        }
    }
}
