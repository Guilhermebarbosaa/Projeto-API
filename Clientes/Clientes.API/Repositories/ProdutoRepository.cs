using APIClientes.Entities;
using Dapper;
using System.Data.SqlClient;

namespace APIClientes.Repositories
{
    public class ProdutoRepository : Repository
    {
        public List<Produto> ObterLista()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Produtos";

                var lista = connection.Query<Produto>(sql).ToList();

                return lista;
            }
        }

        public Produto ObterPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Produtos WHERE Id=@Id";
                var produto = connection.QueryFirstOrDefault<Produto>(sql, new { Id = id });
                return produto;
            }
        }

    }
}
