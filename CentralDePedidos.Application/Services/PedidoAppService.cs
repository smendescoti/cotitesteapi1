using AutoMapper;
using CentralDePedidos.Application.Commands;
using CentralDePedidos.Application.Events;
using CentralDePedidos.Application.Interfaces.Publishers;
using CentralDePedidos.Application.Interfaces.Services;
using CentralDePedidos.Domain.Interfaces.Services;
using CentralDePedidos.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoDomainService? _pedidoDomainService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper? _mapper;

        public PedidoAppService(IPedidoDomainService? pedidoDomainService, IEventPublisher eventPublisher, IMapper? mapper)
        {
            _pedidoDomainService = pedidoDomainService;
            _eventPublisher = eventPublisher;
            _mapper = mapper;            
        }

        public async Task Add(PedidoCreateCommand command)
        {
            #region Adicionando o pedido

            var model = _mapper.Map<Pedido>(command);
            _pedidoDomainService.Add(model);

            #endregion

            #region Gerando o evento de pedido realizado

            var @event = new PedidoRealizadoEvent
            {
                Id = Guid.NewGuid(),
                DataHoraCriacao = DateTime.Now,
                DetalhesPedido = JsonConvert.SerializeObject(model, Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                })
            };

            await _eventPublisher.Publish(@event);

            #endregion
        }

        public void Dispose()
        {
            _pedidoDomainService.Dispose();
        }
    }
}
