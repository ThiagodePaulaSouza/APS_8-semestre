using BuscarReciclaveis.Domain.Dtos;
using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static BuscarReciclaveis.Domain.Entidades.ItemReciclavel;

namespace BuscarReciclaveis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemsController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("todos")]
        [SwaggerOperation("Busca todos os items reciclaveis.", Tags = new[] { "ItemReciclavel" })]
        [ProducesResponseType(typeof(IList<ItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemsReciclaveisAsync()
        {
            IList<ItemReciclavel> itemsReciclaveis = await _unitOfWork.IItemReciclavelRepository.SelectAllAsync();
            if(itemsReciclaveis == null)
            {
                return NotFound();
            }
            
            IList<ItemResponse> result = itemsReciclaveis
                .Select(i => new ItemResponse { TextoItem = i.TextoItem, IdCategoriaReciclavel = i.CategoriaReciclavel.IdCategoria })
                .ToList();

            return Ok(result);
        }

        [HttpPost]
        [Route("cadastrarVarios")]
        [SwaggerOperation("Cadastra varias items reciclaveis.", Tags = new[] { "ItemReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostItemsReciclaveisAsync(IList<ItemRequest> request)
        {
            var items = new List<ItemReciclavel>();
            foreach (var item in request)
            {
                var categoria = await _unitOfWork.ICategoriaReciclavel.SelectByCategoryIdAtivoAsync(item.IdCategoria);
                items.Add(Factory.New(new ItemCategoriaRequest(categoria, item.TextoItem)));
            }
            
            IList<string>? mensagemErro = null;
            foreach (var item in items)
            {
                if (!item.IsValid())
                {
                    mensagemErro.Add(item.ErrorMessage());
                }
            }

            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }

            await _unitOfWork.IItemReciclavelRepository.AddManyAsync(items);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpPut]
        [Route("{id}/editar")]
        [SwaggerOperation("Edita uma item reciclavel.", Tags = new[] { "ItemReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCategoriaReciclavelAsync(int id, ItemRequest request)
        {
            ItemReciclavel item = await _unitOfWork.IItemReciclavelRepository.SelectByIdAtivoAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            CategoriaReciclavel categoria = await _unitOfWork.ICategoriaReciclavel.SelectByCategoryIdAtivoAsync(request.IdCategoria);
            var result = new ItemCategoriaRequest(categoria, request.TextoItem);

            item.Update(result);

            if (!item.IsValid())
            {
                return BadRequest(item.ErrorMessage());
            }

            _unitOfWork.IItemReciclavelRepository.Update(item);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/excluir/virtual")]
        [SwaggerOperation("Deleta virtualmente uma item reciclavel.", Tags = new[] { "ItemReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVirtualCategoriaReciclavelAsync(int id)
        {
            ItemReciclavel item = await _unitOfWork.IItemReciclavelRepository.SelectByIdAtivoAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.VirtualDelete();

            _unitOfWork.IItemReciclavelRepository.Update(item);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/excluir/fisico")]
        [SwaggerOperation("Deleta fisicamente uma item reciclavel.", Tags = new[] { "ItemReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePhysicallyCategoriaReciclavelAsync(int id)
        {
            ItemReciclavel item = await _unitOfWork.IItemReciclavelRepository.SelectByIdAtivoAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _unitOfWork.IItemReciclavelRepository.Remove(id);
            await _unitOfWork.Commit();

            return Ok();
        }
    }
}