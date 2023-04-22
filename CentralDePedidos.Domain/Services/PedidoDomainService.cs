using CentralDePedidos.Domain.Interfaces.Repositories;
using CentralDePedidos.Domain.Interfaces.Services;
using CentralDePedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Domain.Services
{
    public class PedidoDomainService : IPedidoDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public PedidoDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Pedido pedido)
        {
            foreach (var item in pedido.Produtos)
                _unitOfWork.ProdutoRepository.Add(item);

            _unitOfWork.ClienteRepository.Add(pedido.Cliente);
            _unitOfWork.CobrancaRepository.Add(pedido.Cobranca);
            _unitOfWork.PedidoRepository.Add(pedido);

            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
