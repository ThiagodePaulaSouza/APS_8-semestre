using BuscarReciclaveis.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BuscarReciclaveis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocaisController : ControllerBase
    {
        public LocaisController()
        { 
        }

        [HttpGet]
        [Route("todas")]
        [SwaggerOperation("Busca locais.", Tags = new[] { "LocaisReciclaveis" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}