using CentralDePedidos.Domain.Interfaces.Repositories;
using CentralDePedidos.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;

        public UnitOfWork(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public IClienteRepository ClienteRepository => new ClienteRepository(_dataContext);

        public ICobrancaRepository CobrancaRepository => new CobrancaRepository(_dataContext);

        public IPedidoRepository PedidoRepository => new PedidoRepository(_dataContext);

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(_dataContext);

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
