namespace APIClientes.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnit { get; set; }

        public Produto Produto { get; set; }
    }
}
