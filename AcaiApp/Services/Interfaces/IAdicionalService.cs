using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Interfaces
{
    public interface IAdicionalService
    {
        Adicional CriarAdicional(Adicional adicional);
        Adicional AtualizarAdicional(Adicional adicional);
        Adicional ObterAdicionalPorId(int id);
        void ExcluirAdicional(int id);
        IEnumerable<Adicional> ObterTodosAdicionais();
        bool AdicionalExiste(int id);
    }
}
