using CentralDePedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto, Guid>
    {

    }
}
