using BuscarReciclaveis.Domain.Dtos;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BuscarReciclaveis.Domain.Entidades
{
    public class ItemReciclavel : BaseEntity<ItemReciclavel>
    {
        public required string TextoItem { get; set; }

        [ForeignKey("IdCategoria")]
        public int IdCategoria { get; set; }
        public virtual CategoriaReciclavel CategoriaReciclavel { get; set; }

        public void Update(ItemCategoriaRequest request)
        {
            TextoItem = request.TextoItem;
            Status = Enums.Status.Ativo;
            IdCategoria = request.IdCategoria;
            CategoriaReciclavel = request.CategoriaReciclavel;
        }

        public void VirtualDelete()
        {
            Status = Enums.Status.Excluido;
        }

        private void ValidarTextoItem()
        {
            RuleFor((ItemReciclavel o) => o.TextoItem).MaximumLength(250).WithMessage("O Texto do Item Reciclavel precisa ter no máximo 250 caracteres");
            RuleFor((ItemReciclavel o) => o.TextoItem).MinimumLength(3).WithMessage("O Texto do Item Reciclavel precisa ter no minimo 3 caracteres");
        }

        public override bool IsValid()
        {
            ValidarTextoItem();
            base.ValidationResult = Validate(this);
            return base.ValidationResult.IsValid;
        }

        public static class Factory
        {
            public static ItemReciclavel New(ItemCategoriaRequest request)
            {

                var item = new ItemReciclavel
                {
                    Status = Enums.Status.Ativo,
                    TextoItem = request.TextoItem,
                    IdCategoria = request.IdCategoria,
                    CategoriaReciclavel = request.CategoriaReciclavel
                };
                return item;
            }
        }
    }
}