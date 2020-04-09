using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Interfaces
{
    public interface IPedidoService
    {
        Pedido CriarPedido(Pedido pedido);
        Pedido AtualizarPedido(Pedido pedido);
        Pedido ObterPedidoPorId(int id);
        void ExcluirPedido(int id);
        IEnumerable<Pedido> ObterTodosPedidos();
        bool PedidoExiste(int id);
    }
}
