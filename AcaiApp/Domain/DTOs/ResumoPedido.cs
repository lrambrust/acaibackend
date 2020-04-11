using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Domain.DTOs
{
    public class ResumoPedido
    {
        public int TempoTotalPreparo { get; set; }
        public double ValorTotalPedido { get; set; }
        public string Tamanho { get; set; }
        public string Sabor { get; set; }
        public string Adicional { get; set; }
    }
}
