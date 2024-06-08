using APIClientes.Entities;
using Dapper;
using System.Data.SqlClient;

namespace APIClientes.Repositories
{
    public class ItemRepository : Repository
    {
        public List<Item> ObterLista()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Itens";
                var lista = connection.Query<Item>(sql).ToList();
                return lista;
            }
        }
        public List<Item> ObterListaPorPedido(int pedidoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Itens WHERE PedidoId=@PedidoId";
                var lista = connection.Query<Item>(sql, new { PedidoId = pedidoId }).ToList();
                return lista;
            }
        }

        public Item Inserir(Item item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Itens (PedidoId, ProdutoId, Quantidade, ValorUnit) VALUES (@PedidoId, @ProdutoId, @Quantidade, @ValorUnit)";
                connection.Execute(sql, item);
                return item;
            }
        }

        internal Pedido Inserir(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
