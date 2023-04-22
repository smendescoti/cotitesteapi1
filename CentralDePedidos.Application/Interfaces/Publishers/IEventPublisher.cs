using CentralDePedidos.Application.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Application.Interfaces.Publishers
{
    public interface IEventPublisher
    {
        Task Publish(BaseEvent @event);
    }
}
