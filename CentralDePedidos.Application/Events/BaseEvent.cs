using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Application.Events
{
    public abstract class BaseEvent
    {
        public Guid? Id { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
    }
}
