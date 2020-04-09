using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Interfaces
{
    public interface IPedidoAdicionalService
    {
        PedidoAdicional CriarPedidoAdicional(PedidoAdicional pedido);
        PedidoAdicional AtualizarPedidoAdicional(PedidoAdicional pedido);
        PedidoAdicional ObterPedidoAdicionalPorId(int id);
        void ExcluirPedidoAdicional(int id);
        IEnumerable<PedidoAdicional> ObterTodosPedidosAdicionais();
        bool PedidoAdicionalExiste(int id);
    }
}
