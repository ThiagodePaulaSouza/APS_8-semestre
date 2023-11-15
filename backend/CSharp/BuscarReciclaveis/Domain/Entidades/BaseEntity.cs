using System.ComponentModel.DataAnnotations;
using BuscarReciclaveis.Domain.Enums;

namespace BuscarReciclaveis.Domain.Entidades
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Ativo;
        public DateTime DataCriado { get; set; } = DateTime.Now;
        public DateTime DataAtualizado { get; set; } = DateTime.Now;
    }
}