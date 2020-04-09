using AcaiApp.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public EnumTamanho Tamanho { get; set; }
        public EnumSabores Sabores { get; set; }
        public double ValorTotal { get; set; }
        public IEnumerable<PedidoAdicional> PedidoAdicional { get; set; }
        public IEnumerable<Adicional> Adicional { get; set; }
    }
}
