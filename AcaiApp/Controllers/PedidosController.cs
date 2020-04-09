using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcaiApp.Data.Context;
using AcaiApp.Domain.Entities;
using AcaiApp.Services.Interfaces;

namespace AcaiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService service;

        public PedidosController(IPedidoService service)
        {
            this.service = service;
        }

        // GET: api/Pedidoes
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            return service.ObterTodosPedidos().ToList();
            
        }

        // GET: api/Pedidoes/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = service.ObterPedidoPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            try
            {
                service.AtualizarPedido(pedido);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pedidoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Pedido> PostPedido(Pedido pedido)
        {
            service.CriarPedido(pedido);

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidoes/5
        [HttpDelete("{id}")]
        public ActionResult<Pedido> DeletePedido(int id)
        {
            var pedido = service.ObterPedidoPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }

            service.ExcluirPedido(id);

            return pedido;
        }

        private bool PedidoExists(int id)
        {
            return service.PedidoExiste(id);
        }
    }
}
