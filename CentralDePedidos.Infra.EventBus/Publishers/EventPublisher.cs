using CentralDePedidos.Application.Events;
using CentralDePedidos.Application.Interfaces.Publishers;
using CentralDePedidos.Infra.EventBus.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Infra.EventBus.Publishers
{
    public class EventPublisher : IEventPublisher
    {
        private readonly MessageBrokerSettings? _messageBrokerSettings;

        public EventPublisher(IOptions<MessageBrokerSettings>? messageBrokerSettings)
        {
            _messageBrokerSettings = messageBrokerSettings.Value;
        }

        public async Task Publish(BaseEvent @event)
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(_messageBrokerSettings.ConnectionString)
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    if (@event is PedidoRealizadoEvent)
                    {
                        var pedidoRealizado = @event as PedidoRealizadoEvent;

                        channel.QueueDeclare(
                            queue: _messageBrokerSettings.QueueName,
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null
                        );

                        await Task.Run(() =>
                            channel.BasicPublish(
                                exchange: string.Empty,
                                routingKey: _messageBrokerSettings.QueueName,
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pedidoRealizado))
                            )
                        );
                    }
                }
            }
        }
    }
}
