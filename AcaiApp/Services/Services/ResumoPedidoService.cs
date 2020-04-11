using AcaiApp.Domain.DTOs;
using AcaiApp.Domain.Entities;
using AcaiApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Services
{
    public class ResumoPedidoService : IResumoPedidoService
    {
        private readonly ICalculosService _calculosService;
        private readonly IAdicionalService _adicionalService;
        private readonly IPedidoAdicionalService _pedidoAdicionalService;
        public ResumoPedidoService(ICalculosService calculosService, IAdicionalService adicionalService, IPedidoAdicionalService pedidoAdicionalService)
        {
            _calculosService = calculosService;
            _adicionalService = adicionalService;
            _pedidoAdicionalService = pedidoAdicionalService;
        }

        public ResumoPedido resumoPedido(Pedido pedido)
        {
            var resumoPedido = new ResumoPedido();

            var pedidoAdicional = _pedidoAdicionalService.ObterTodosPedidosAdicionais().Where(p => p.Pedido.Id == pedido.Id).Select(p => p.IdAdicional);
            var adicionais = _adicionalService.ObterTodosAdicionais().Where(a => pedidoAdicional.Contains(a.Id));

            resumoPedido.Tamanho = $"Tamanho: {pedido.Tamanho}";
            resumoPedido.Sabor = $"Sabor: {pedido.Sabores}";
            resumoPedido.Adicional = $"Adicionais :{string.Join(", ", adicionais.Select(p => p.Descricao))}."; 
            resumoPedido.TempoTotalPreparo = _calculosService.CalculaTempoDePreparo(pedido);
            resumoPedido.ValorTotalPedido = _calculosService.CalcularValorTotal(pedido);

            return resumoPedido;
        }
        


    }
}
