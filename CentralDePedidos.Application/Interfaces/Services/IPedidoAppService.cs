using CentralDePedidos.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Application.Interfaces.Services
{
    public interface IPedidoAppService : IDisposable
    {
        Task Add(PedidoCreateCommand command);
    }
}
