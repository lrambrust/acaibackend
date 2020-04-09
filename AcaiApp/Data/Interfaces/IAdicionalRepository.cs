using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Interfaces
{
    public interface IAdicionalRepository : IRepository<Adicional>
    {
        IEnumerable<Adicional> ObterTodosAdicionais();
        Adicional ObterAdicionalPorId(int id);
        bool AdicionalExiste(int id);
    }
}
