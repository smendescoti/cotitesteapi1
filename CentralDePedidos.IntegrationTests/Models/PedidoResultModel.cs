using CentralDePedidos.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.IntegrationTests.Models
{
    /// <summary>
    /// Modelo de dados para deserializar a resposta da API
    /// após o processamento de um pedido (POST)
    /// </summary>
    public class PedidoResultModel
    {
        public string? Message { get; set; }
        public PedidoCreateCommand? Pedido { get; set; }
    }
}
