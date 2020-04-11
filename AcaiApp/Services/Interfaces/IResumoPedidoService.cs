using AcaiApp.Domain.DTOs;
using AcaiApp.Domain.Entities;

namespace AcaiApp.Services.Interfaces
{
    public interface IResumoPedidoService
    {
        ResumoPedido resumoPedido(Pedido pedido);
    }
}
