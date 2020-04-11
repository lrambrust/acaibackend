using AcaiApp.Data.Interfaces;
using AcaiApp.Domain.Entities;
using AcaiApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Services
{
    public class PedidoAdicionalService : IPedidoAdicionalService
    {
        private readonly IPedidoAdicionalRepository repository;

        public PedidoAdicionalService(IPedidoAdicionalRepository repository)
        {
            this.repository = repository;
        }

        public PedidoAdicional CriarPedidoAdicional(PedidoAdicional pedido)
        {
            repository.Insert(pedido);
            return pedido;
        }

        public PedidoAdicional AtualizarPedidoAdicional(PedidoAdicional pedido)
        {
            repository.Update(pedido);
            return pedido;
        }

        public PedidoAdicional ObterPedidoAdicionalPorId(int id)
        {
            return repository.ObterPedidoAdicionalPorId(id);
        }

        public void ExcluirPedidoAdicional(int id)
        {
            PedidoAdicional pedido = repository.Get(id);
            repository.Delete(pedido);
        }

        public IEnumerable<PedidoAdicional> ObterTodosPedidosAdicionais()
        {
            return repository.ObterTodosPedidosAdicionais();
        }

        public bool PedidoAdicionalExiste(long id)
        {
            return repository.PedidoAdicionalExiste(id);
        }
    }
}
