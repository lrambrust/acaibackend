using AcaiApp.Data.Context;
using AcaiApp.Data.Interfaces;
using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Repositories
{
    public class AdicionalRepository : BaseRepository<Adicional>, IAdicionalRepository
    {
        public AdicionalRepository(AcaiContext context) : base(context)
        {
        }

        public IEnumerable<Adicional> ObterTodosAdicionais()
        {
            return _context.Adicionals.ToList();
        }

        public Adicional ObterAdicionalPorId(int id)
        {
            return _context.Adicionals.SingleOrDefault(p => p.Id == id);
        }

        public bool AdicionalExiste(int id)
        {
            return _context.Adicionals.Any(p => p.Id == id);
        }
    }
}
