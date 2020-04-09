using AcaiApp.Data.Context;
using AcaiApp.Data.Interfaces;
using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Repositories
{
    public class PedidosRepository : BaseRepository<Pedido>, IPedidosRepository
    {
        public PedidosRepository(AcaiContext context) : base(context) 
        { 
        }

        public IEnumerable<Pedido> ObterTodosPedidos()
        {
            return _context.Pedidos.ToList();
        }

        public Pedido ObterPedidoPorId(int id)
        {
            return _context.Pedidos.SingleOrDefault(p => p.Id == id);
        }

        public bool PedidoExiste(int id)
        {
            return _context.Pedidos.Any(p => p.Id == id);
        }
    }
}
