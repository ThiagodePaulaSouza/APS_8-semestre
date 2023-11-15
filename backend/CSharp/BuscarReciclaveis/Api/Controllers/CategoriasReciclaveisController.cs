using BuscarReciclaveis.Domain.Dtos;
using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BuscarReciclaveis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasReciclaveisController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriasReciclaveisController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/teste")]
        [SwaggerOperation("Busca todos as categorias reciclaveis.", Tags = new[] { "CategoriasReciclaveis" })]
        [ProducesResponseType(typeof(IList<CategoriasReciclaveisResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriasReciclaveisAsync()
        {
            IList<CategoriasReciclaveis> categoriasReciclaveis = await _unitOfWork.ICategoriasReciclaveis.SelectAllAsync();
            if(categoriasReciclaveis == null)
            {
                return NotFound();
            }
            
            IList<CategoriasReciclaveisResponse> result = categoriasReciclaveis
                .Select(i => new CategoriasReciclaveisResponse { Id = i.Id, TextoCategoria = i.TextoCategoria })
                .ToList();

            return Ok(result);
        }
    }
}