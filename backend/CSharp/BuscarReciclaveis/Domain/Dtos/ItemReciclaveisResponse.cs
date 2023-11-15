namespace BuscarReciclaveis.Domain.Dtos
{
    public class ItemReciclaveisResponse
    {
        public int Id { get; set; }
        public int IdCategoriasReciclaveis { get; set; }
        public required string TextoItem { get; set; }
    }
}
