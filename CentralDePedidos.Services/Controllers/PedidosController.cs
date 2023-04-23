using CentralDePedidos.Application.Commands;
using CentralDePedidos.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralDePedidos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoAppService? _pedidoAppService;

        public PedidosController(IPedidoAppService? pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PedidoCreateCommand command)
        {
            await _pedidoAppService.Add(command);

            return StatusCode(201,
               new
               {
                   message = "Pedido realizado com sucesso.",
                   pedido = command
               });
        }

    }
}
