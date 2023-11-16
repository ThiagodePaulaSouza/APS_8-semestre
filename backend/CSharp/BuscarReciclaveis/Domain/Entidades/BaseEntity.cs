using BuscarReciclaveis.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuscarReciclaveis.Domain.Entidades
{
    public abstract class BaseEntity<T> : FluentValidation.AbstractValidator<T> where T : BaseEntity<T>
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Ativo;
        public DateTime DataCriado { get; set; } = DateTime.UtcNow;
        public DateTime DataAtualizado { get; set; } = DateTime.UtcNow;

        protected BaseEntity() => ValidationResult = new FluentValidation.Results.ValidationResult();

        [NotMapped]
        public FluentValidation.Results.ValidationResult ValidationResult { get; protected set; }
        public abstract bool IsValid();

        public string? ErrorMessage()
        {
            if (!ValidationResult.IsValid)
            {
                return string.Join("\r", ValidationResult.Errors.Select((FluentValidation.Results.ValidationFailure error) => error.ErrorMessage + ": " + error.PropertyName));
            }

            return null;
        }
    }
}