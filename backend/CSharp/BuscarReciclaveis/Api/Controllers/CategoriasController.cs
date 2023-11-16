using BuscarReciclaveis.Domain.Dtos;
using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static BuscarReciclaveis.Domain.Entidades.CategoriaReciclavel;

namespace BuscarReciclaveis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriasController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("todas")]
        [SwaggerOperation("Busca todas as categorias reciclaveis.", Tags = new[] { "CategoriaReciclavel" })]
        [ProducesResponseType(typeof(IList<CategoriaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriasReciclaveisAsync()
        {
            IList<CategoriaReciclavel> categoriasReciclaveis = await _unitOfWork.ICategoriaReciclavel.SelectAllAsync();
            if(categoriasReciclaveis == null)
            {
                return NotFound();
            }
            
            IList<CategoriaResponse> result = categoriasReciclaveis
                .Select(i => new CategoriaResponse { IdCategoria = i.IdCategoria, TextoCategoria = i.TextoCategoria })
                .ToList();

            return Ok(result);
        }
        
        [HttpPost]
        [Route("cadastrarVarios")]
        [SwaggerOperation("Cadastra varias categorias reciclaveis.", Tags = new[] { "CategoriaReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCategoriasReciclaveisAsync(IList<CategoriaRequest> request)
        {
            IList<CategoriaReciclavel> categorias = request
                .Select(Factory.New)
                .ToList();
            IList<string>? mensagemErro = null;

            foreach (var item in categorias)
            {
                if(!item.IsValid())
                {
                    mensagemErro.Add(item.ErrorMessage());
                }
            }

            if(mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }

            await _unitOfWork.ICategoriaReciclavel.AddManyAsync(categorias);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpPut]
        [Route("{categoriaId}/editar")]
        [SwaggerOperation("Edita uma categoria reciclavel.", Tags = new[] { "CategoriaReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCategoriaReciclavelAsync(int categoriaId, CategoriaRequest request)
        {
            CategoriaReciclavel categoria = await _unitOfWork.ICategoriaReciclavel.SelectByCategoryIdAtivoAsync(categoriaId);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Update(request);

            if(!categoria.IsValid())
            {
                return BadRequest(categoria.ErrorMessage());
            }

            _unitOfWork.ICategoriaReciclavel.Update(categoria);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        [Route("{categoriaId}/excluir/virtual")]
        [SwaggerOperation("Deleta virtualmente uma categoria reciclavel.", Tags = new[] { "CategoriaReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVirtualCategoriaReciclavelAsync(int categoriaId)
        {
            CategoriaReciclavel categoria = await _unitOfWork.ICategoriaReciclavel.SelectByCategoryIdAtivoAsync(categoriaId);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.VirtualDelete();

            _unitOfWork.ICategoriaReciclavel.Update(categoria);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        [Route("{categoriaId}/excluir/fisico")]
        [SwaggerOperation("Deleta fisicamente uma categoria reciclavel.", Tags = new[] { "CategoriaReciclavel" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePhysicallyCategoriaReciclavelAsync(int categoriaId)
        {
            CategoriaReciclavel categoria = await _unitOfWork.ICategoriaReciclavel.SelectByCategoryIdAtivoAsync(categoriaId);
            if (categoria == null)
            {
                return NotFound();
            }

            await _unitOfWork.ICategoriaReciclavel.Remove(categoria.Id);
            await _unitOfWork.Commit();

            return Ok();
        }
    }
}