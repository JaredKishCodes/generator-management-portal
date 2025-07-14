using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.Generators.Command;
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

        [HttpPost]
        public async Task<GenResponse> CreateGenerator(GenRequest request)
        {
            var query = new AddGeneratorCommand(request);
            return await sender.Send(query);
        }

        [HttpPut("{genCode}")]
        public async Task<ActionResult<GenResponse>> UpdateGenerator(int genCode, [FromBody] UpdateGenRequest gen)
        {
            gen.GenCode = genCode; // Set it explicitly if not already included
            var result = await sender.Send(new UpdateGeneratorCommand(gen, genCode));

            if (result == null)
                return NotFound("Generator not found or update failed.");

            return Ok(result);
        }



        [HttpDelete("{genCode}")]
        public async Task<IActionResult> DeleteGenerator(int genCode)
        {
            try
            {
                var result = await sender.Send(new DeleteGeneratorCommand(genCode));

                if (result)
                    return NoContent(); // 204 success

                return StatusCode(500, "Deletion failed unexpectedly.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // 404 Not Found
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
