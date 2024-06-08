namespace APIClientes.Repositories
{
    public class Repository
    {
        protected string connectionString = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
    }
}