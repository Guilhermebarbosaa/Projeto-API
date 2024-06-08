using APIClientes.Entities;
using APIClientes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Cliente> Get() => new ClienteRepository().ObterLista();

        [HttpGet("{id}")]
        public Cliente GetById(int id) => new ClienteRepository().ObterPorId(id);

        [HttpGet("name/{name}")]
        public Cliente GetByName(string name) => new ClienteRepository().ObterPorNome(name);    

        [HttpGet("nameStartsWith/{name}")]
        public IEnumerable<Cliente> GetByPartName(string name) => new ClienteRepository().ObterListaPorNome(name);

    
        [HttpPost]
        public dynamic Post(Cliente cliente) => new ClienteRepository().Inserir(cliente);
  /*-
        [HttpPut]
        public Cliente Update(Cliente cliente)
        {
            
            return cliente;
        }*/
    }
}
