namespace BuscarReciclaveis.Domain.Dtos
{
    public class LocaisRequest
    {
        public required int IdCategoria { get; set; }
        public required string TextoItem { get; set; }
    }
}
