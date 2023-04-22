using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Application.Events
{
    public class PedidoRealizadoEvent : BaseEvent
    {
        public string? DetalhesPedido { get; set; }
    }
}
