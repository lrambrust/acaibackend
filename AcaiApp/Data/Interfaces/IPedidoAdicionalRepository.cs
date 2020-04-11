using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Interfaces
{
    public interface IPedidoAdicionalRepository : IRepository<PedidoAdicional>
    {
        PedidoAdicional ObterPedidoAdicionalPorId(int id);
        IEnumerable<PedidoAdicional> ObterTodosPedidosAdicionais();
        public bool PedidoAdicionalExiste(long id);
    }
}
