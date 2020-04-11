using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Domain.Entities
{
    public class PedidoAdicional : BaseEntity
    {
        public long IdAdicional { get; set; }
        public Pedido Pedido { get; set; }
        public IEnumerable<Adicional> Adicional { get; set; }
    }
}
