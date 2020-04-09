using AcaiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Services.Interfaces
{
    public interface ICalculosService
    {
        double CalcularValorTotal(Pedido pedido);
        int CalculaTempoDePreparo(Pedido pedido);
    }
}
