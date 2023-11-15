using BuscarReciclaveis.Domain.Dtos;
using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BuscarReciclaveis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsReciclaveisController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemsReciclaveisController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        [SwaggerOperation("Busca todos os items reciclaveis.", Tags = new[] { "ItemsReciclaveis" })]
        [ProducesResponseType(typeof(IList<ItemReciclaveisResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemsReciclaveisAsync()
        {
            IList<ItemsReciclaveis> itemsReciclaveis = await _unitOfWork.IItemsReciclaveisRepository.SelectAllAsync();
            if(itemsReciclaveis == null)
            {
                return NotFound();
            }
            
            IList<ItemReciclaveisResponse> result = itemsReciclaveis
                .Select(i => new ItemReciclaveisResponse { TextoItem = i.TextoItem, IdCategoriasReciclaveis = i.IdCategoriasReciclaveis })
                .ToList();

            return Ok(result);
        }
    }
}