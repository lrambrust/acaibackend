using AcaiApp.Domain.Entities;
using AcaiApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Services
{
    public class CalculosService : ICalculosService
    {
        private readonly IPedidoService pedidoService;
        private readonly IAdicionalService adicionalService;
        private readonly IPedidoAdicionalService pedidoAdicionalService;

        public CalculosService(IPedidoService pedidoService, IAdicionalService adicionalService, IPedidoAdicionalService pedidoAdicionalService)
        {
            this.pedidoService = pedidoService;
            this.adicionalService = adicionalService;
            this.pedidoAdicionalService = pedidoAdicionalService;
        }

        public double CalcularValorTotal(Pedido pedido)
        {
            double valorTotal = 0.0;
            var tamanho = pedido.Tamanho.ToString();

            if (tamanho == "pequeno")
            {
                valorTotal = 10.00;
            } else if (tamanho == "medio")
            {
                valorTotal = 13.00;
            } else
            {
                valorTotal = 15.00;
            }

            foreach (var adicional in pedido.Adicional)
            {
                valorTotal += adicional.ValorAdicional;
            }

            return valorTotal;
        }

        public int CalculaTempoDePreparo(Pedido pedido)
        {
            int tempoDePreparo = 0;
            foreach (var tempo in pedido.Adicional)
            {
                tempoDePreparo += tempo.TempoPreparo;
            }

            return tempoDePreparo;
        }
    }
}
