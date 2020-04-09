using AcaiApp.Data.Interfaces;
using AcaiApp.Domain.Entities;
using AcaiApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Services
{
    public class AdicionalService : IAdicionalService
    {
        private readonly IAdicionalRepository repository;

        public AdicionalService(IAdicionalRepository repository)
        {
            this.repository = repository;
        }

        public Adicional CriarAdicional(Adicional adicional)
        {
            repository.Insert(adicional);
            return adicional;
        }

        public Adicional AtualizarAdicional(Adicional adicional)
        {
            repository.Update(adicional);
            return adicional;
        }

        public Adicional ObterAdicionalPorId(int id)
        {
            return repository.ObterAdicionalPorId(id);
        }

        public void ExcluirAdicional(int id)
        {
            Adicional adicional = repository.Get(id);
            repository.Delete(adicional);
        }

        public IEnumerable<Adicional> ObterTodosAdicionais()
        {
            return repository.ObterTodosAdicionais();
        }

        public bool AdicionalExiste(int id)
        {
            return repository.AdicionalExiste(id);
        }
    }
}
