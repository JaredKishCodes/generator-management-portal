using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.Generators.Query;

namespace ReecsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GenResponse>> GetAllGenerators()
        {
            var query = new GetAllGeneratorsQuery();
            return await sender.Send(query);
        }
    }
}
