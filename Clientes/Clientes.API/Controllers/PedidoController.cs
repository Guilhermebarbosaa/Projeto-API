using APIClientes.Entities;
using APIClientes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            List<Pedido> lista = new PedidoRepository().ObterLista();

            return lista;
        }

        [HttpGet("{id}")]
        public Pedido GetById(int id) => new PedidoRepository().ObterPorId(id);

        [HttpGet("{id}/detalhado")]
        public Pedido GetPedidoDetalhado(int id) => new PedidoRepository().ObterPedidoCompleto(id);

        [HttpPost]
        public Pedido Post(Pedido pedido) => new ItemRepository().Inserir(pedido);
        /*   
            return pedido;
        }

        [HttpPut]
        public Pedido Update(Pedido pedido)
        {
            
            return pedido;
        }
        */
    }
}
