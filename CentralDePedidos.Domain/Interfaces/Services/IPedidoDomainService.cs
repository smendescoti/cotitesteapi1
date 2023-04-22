using CentralDePedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Domain.Interfaces.Services
{
    public interface IPedidoDomainService : IDisposable
    {
        void Add(Pedido pedido);
    }
}
