using APIClientes.Entities;
using Dapper;
using System.Data.SqlClient;
using W4G.Extensions.documents;

namespace APIClientes.Repositories
{
    public class ClienteRepository : Repository
    {
        public IEnumerable<Cliente> ObterLista()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Clientes";
                var lista = connection.Query<Cliente>(sql);
                return lista;
            }
        }

        public IEnumerable<Cliente> ObterListaPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM Clientes WHERE Nome LIKE '%@Nome%'";
                var lista = connection.Query<Cliente>(sql, new { Nome = nome });
                return lista;
            }
        }

        public Cliente ObterPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Clientes WHERE Id = @Id";
                var cliente = connection.QueryFirstOrDefault<Cliente>(sql, new { Id = id });
                return cliente;
            }
        }

        public Cliente ObterPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Clientes WHERE Nome = @Nome";
                var cliente = connection.QueryFirstOrDefault<Cliente>(sql, new { Nome = nome });
                return cliente;
            }
        }
        public dynamic Inserir(Cliente cliente)
        {
            string documento = cliente.CPF;

            if (!documento.CpfIsValid())
                return new { erro = new { mensagem = "CPF invalido" } };


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Clientes (Nome, DataNascimento, CPF, Email) VALUES (@Nome, @DataNascimento, @CPF, @Email)";
                connection.Execute(sql, cliente);
                return cliente;
            }
        }

    }
}
