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
    public class PedidoAdicionaisController : ControllerBase
    {
        private readonly IPedidoAdicionalService service;

        public PedidoAdicionaisController(IPedidoAdicionalService service)
        {
            this.service = service;
        }

        // GET: api/PedidoAdicionals
        [HttpGet]
        public ActionResult<IEnumerable<PedidoAdicional>> GetPedidosAdicionais()
        {
            return service.ObterTodosPedidosAdicionais().ToList();
        }

        // GET: api/PedidoAdicionals/5
        [HttpGet("{id}")]
        public ActionResult<PedidoAdicional> GetPedidoAdicional(int id)
        {
            var pedidoAdicional = service.ObterPedidoAdicionalPorId(id);

            if (pedidoAdicional == null)
            {
                return NotFound();
            }

            return pedidoAdicional;
        }

        // PUT: api/PedidoAdicionals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutPedidoAdicional(int id, PedidoAdicional pedidoAdicional)
        {
            if (id != pedidoAdicional.IdAdicional)
            {
                return BadRequest();
            }

            try
            {
                service.AtualizarPedidoAdicional(pedidoAdicional);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoAdicionalExists(id))
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

        // POST: api/PedidoAdicionals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<PedidoAdicional> PostPedidoAdicional(PedidoAdicional pedidoAdicional)
        {
            try
            {
                service.CriarPedidoAdicional(pedidoAdicional);
            }
            catch (DbUpdateException)
            {
                if (PedidoAdicionalExists(pedidoAdicional.IdAdicional))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPedidoAdicional", new { id = pedidoAdicional.IdAdicional }, pedidoAdicional);
        }

        // DELETE: api/PedidoAdicionals/5
        [HttpDelete("{id}")]
        public ActionResult<PedidoAdicional> DeletePedidoAdicional(int id)
        {
            var pedidoAdicional = service.ObterPedidoAdicionalPorId(id);
            if (pedidoAdicional == null)
            {
                return NotFound();
            }

            service.ExcluirPedidoAdicional(id);

            return pedidoAdicional;
        }

        private bool PedidoAdicionalExists(int id)
        {
            return service.PedidoAdicionalExiste(id);
        }
    }
}
