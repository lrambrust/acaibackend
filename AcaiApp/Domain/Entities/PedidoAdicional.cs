using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Domain.Entities
{
    public class PedidoAdicional : BaseEntity
    {
        public int IdAdicional { get; set; }
        public Pedido Pedido { get; set; }
        public Adicional Adicional { get; set; }
    }
}
