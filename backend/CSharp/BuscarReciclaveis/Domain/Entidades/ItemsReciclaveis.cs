using System.ComponentModel.DataAnnotations.Schema;

namespace BuscarReciclaveis.Domain.Entidades
{
    public class ItemsReciclaveis : BaseEntity
    {
        public required string TextoItem { get; set; }

        [ForeignKey("CategoriasReciclaveis")]
        public int IdCategoriasReciclaveis { get; set; }
        public required virtual CategoriasReciclaveis CategoriasReciclaveis { get; set; }
    }
}