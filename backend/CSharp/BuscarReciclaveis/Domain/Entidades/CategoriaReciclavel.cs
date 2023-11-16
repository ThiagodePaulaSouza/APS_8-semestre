using BuscarReciclaveis.Domain.Dtos;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BuscarReciclaveis.Domain.Entidades
{
    public class CategoriaReciclavel : BaseEntity<CategoriaReciclavel> 
    {
        public int IdCategoria { get; set; }
        public string TextoCategoria { get; set; }

        public void Update(CategoriaRequest request)
        {
            TextoCategoria = request.TextoCategoria;
            Status = Enums.Status.Ativo;
            IdCategoria = request.IdCategoria;
        }

        public void VirtualDelete()
        {
            Status = Enums.Status.Excluido;
        }

        private void ValidarTextoCategoria()
        {
            RuleFor((CategoriaReciclavel o) => o.TextoCategoria).MaximumLength(250).WithMessage("O Texto Categoria precisa ter no máximo 250 caracteres");
            RuleFor((CategoriaReciclavel o) => o.TextoCategoria).MinimumLength(3).WithMessage("O Texto Categoria precisa ter no minimo 3 caracteres");
        }

        public override bool IsValid()
        {
            ValidarTextoCategoria();
            base.ValidationResult = Validate(this);
            return base.ValidationResult.IsValid;
        }

        public static class Factory
        {
            public static CategoriaReciclavel New(CategoriaRequest request)
            {
                var categoria = new CategoriaReciclavel
                {
                    Status = Enums.Status.Ativo,
                    TextoCategoria = request.TextoCategoria,
                    IdCategoria = request.IdCategoria
                };
                return categoria;
            }
        }
    }
}