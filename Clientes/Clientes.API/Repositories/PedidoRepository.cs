using APIClientes.Entities;
using Dapper;
using System.Data.SqlClient;

namespace APIClientes.Repositories
{
    public class PedidoRepository : Repository
    {
        public List<Pedido> ObterLista()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Pedidos";

                var lista = connection.Query<Pedido>(sql).ToList();

                return lista;
            }
        }

        public Pedido ObterPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM Pedidos WHERE Id=@Id";
                var pedido = connection.QueryFirstOrDefault<Pedido>(sql, new { Id = id });
                return pedido;
            }
        }

        public Pedido ObterPedidoCompleto(int id)
        {
            Pedido pedido = ObterPorId(id);
            pedido.Cliente = new ClienteRepository().ObterPorId(pedido.ClienteId);
            pedido.Itens = new ItemRepository().ObterListaPorPedido(pedido.Id);
            foreach (Item item in pedido.Itens)
            {
                item.Produto = new ProdutoRepository().ObterPorId(item.ProdutoId);
            }
            return pedido;
        }
        public Pedido Inserir(Pedido pedido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Pedido (Id, ClienteId, Data, Cliente, Itens) VALUES (@Id, @ClienteId, @Data, @Cliente, @Itens)";
                connection.Execute(sql, pedido);
                return pedido;
            }
        }
    }
}