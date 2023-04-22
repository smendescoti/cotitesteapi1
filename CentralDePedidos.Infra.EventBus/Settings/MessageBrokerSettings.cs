using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Infra.EventBus.Settings
{
    public class MessageBrokerSettings
    {
        public string? ConnectionString { get; set; }
        public string? QueueName { get; set; }
    }
}
