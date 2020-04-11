using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Domain.Entities
{
    public class Adicional : BaseEntity
    {
        public string Descricao { get; set; }
        public int TempoPreparo { get; set; }
        public double ValorAdicional { get; set; }
    }
}
