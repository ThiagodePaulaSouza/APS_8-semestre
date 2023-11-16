namespace BuscarReciclaveis.Domain.Dtos
{
    public class ItemRequest
    {
        public required int IdCategoria { get; set; }
        public required string TextoItem { get; set; }
    }
}
