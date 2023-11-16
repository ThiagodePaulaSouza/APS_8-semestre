using BuscarReciclaveis.Domain.Entidades;

namespace BuscarReciclaveis.Domain.Dtos
{
    public record ItemCategoriaRequest (CategoriaReciclavel CategoriaReciclavel, int IdCategoria, string TextoItem)
    {
    }
}
