using AcaiApp.Data.Context;
using AcaiApp.Data.Interfaces;
using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Repositories
{
    public class PedidoAdicionalRepository : BaseRepository<PedidoAdicional>, IPedidoAdicionalRepository
    {
        public PedidoAdicionalRepository(AcaiContext context) : base(context)
        {
        }

        public IEnumerable<PedidoAdicional> ObterTodosPedidosAdicionais()
        {
            return _context.PedidosAdicionais.ToList();
        }

        public PedidoAdicional ObterPedidoAdicionalPorId(int id)
        {
            return _context.PedidosAdicionais.SingleOrDefault(p => p.Id == id);
        }

        public bool PedidoAdicionalExiste(int id)
        {
            return _context.PedidosAdicionais.Any(p => p.Id == id);
        }
    }
}
