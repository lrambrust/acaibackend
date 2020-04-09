using AcaiApp.Data.Interfaces;
using AcaiApp.Domain.Entities;
using AcaiApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidosRepository repository;

        public PedidoService(IPedidosRepository repository)
        {
            this.repository = repository;
        }

        public Pedido CriarPedido(Pedido pedido)
        {
            repository.Insert(pedido);
            return pedido;
        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            repository.Update(pedido);
            return pedido;
        }

        public Pedido ObterPedidoPorId(int id)
        {
            return repository.ObterPedidoPorId(id);
        }

        public void ExcluirPedido(int id)
        {
            Pedido pedido = repository.Get(id);
            repository.Delete(pedido);
        }

        public IEnumerable<Pedido> ObterTodosPedidos()
        {
            return repository.ObterTodosPedidos();
        }

        public bool PedidoExiste(int id)
        {
            return repository.PedidoExiste(id);
        }
    }
}
