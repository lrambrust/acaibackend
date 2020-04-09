using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Interfaces
{
    public interface IPedidosRepository : IRepository<Pedido>
    {
        Pedido ObterPedidoPorId(int id);
        IEnumerable<Pedido> ObterTodosPedidos();
        bool PedidoExiste(int id);
    }
}
