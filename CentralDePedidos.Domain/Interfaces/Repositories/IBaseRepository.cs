using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        void Add(TEntity entity);
    }
}
