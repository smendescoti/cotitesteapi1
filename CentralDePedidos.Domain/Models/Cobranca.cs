using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Domain.Models
{
    public class Cobranca
    {
        public Guid? Id { get; set; }
        public string? NumeroCartao { get; set; }
        public string? NomeImpressoNoCartao { get; set; }
        public int? MesValidade { get; set; }
        public int? AnoValidade { get; set; }
        public int? CodigoSeguranca { get; set; }
        public decimal? Valor { get; set; }

        public Pedido? Pedido { get; set; }
    }
}
