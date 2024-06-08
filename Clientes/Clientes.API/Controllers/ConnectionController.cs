using Microsoft.AspNetCore.Mvc;
namespace Clientes.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        [HttpPost]
        public dynamic Post([FromBody] string connection)
        {
            var variableValue = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(variableValue))
            {
                Environment.SetEnvironmentVariable("ConnectionString", connection, EnvironmentVariableTarget.User);
                return new { message = "Connection string set successfully" };
            }
            else
            {
                return new { message = "Connection string already set" };
            }
        }
    }
}