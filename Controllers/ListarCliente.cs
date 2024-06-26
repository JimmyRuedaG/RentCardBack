using Microsoft.AspNetCore.Mvc;
using RentCard.Repository.Interface;

namespace RentCard.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ListarCliente : ControllerBase
    { 
        private readonly IClientesRepository cliente;
        
        public ListarCliente(IClientesRepository clientes)
        {
            cliente = clientes;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> listar()
        {
            var clientes = cliente.ListarClientes();
            
            return Ok(clientes);
        }

        [HttpGet]
        [Route("consultar")]
        public async Task<IActionResult> consultar()
        {
            var clientes = cliente.consultar();

            return Ok(clientes);
        }

        [HttpGet]
        [Route("estadistica")]
        public async Task<IActionResult> cantidadAlquiler()
        {
            var clientes = cliente.cantidadAlquiler();

            return Ok(clientes);
        }

    }
}
