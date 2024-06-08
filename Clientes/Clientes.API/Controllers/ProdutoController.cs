using APIClientes.Entities;
using APIClientes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            List<Produto> lista = new ProdutoRepository().ObterLista();

            return lista;
        }

        [HttpGet("nameStartsWith/{name}")]
        public Produto GetByName(string name)
        {
            Produto produto = new Produto();

            return produto;
        }
        /*
        [HttpPost]
        public Produto Insert(Produto produto)
        {
            
            return produto;
        }

        [HttpPut]
        public Produto Update(Produto produto)
        {
            
            return produto;
        }
        */
    }
}
