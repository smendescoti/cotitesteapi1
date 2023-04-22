using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }
        ICobrancaRepository CobrancaRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }

        void SaveChanges();
    }
}
