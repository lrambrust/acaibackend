using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcaiApp.Data.Context;
using AcaiApp.Domain.Entities;
using AcaiApp.Data.Interfaces;
using AcaiApp.Services.Interfaces;

namespace AcaiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionaisController : ControllerBase
    {
        private readonly IAdicionalService service;

        public AdicionaisController(IAdicionalService service)
        {
            this.service = service;
        }

        // GET: api/Adicionais
        [HttpGet]
        public ActionResult<IEnumerable<Adicional>> GetAdicionals()
        {
            return service.ObterTodosAdicionais().ToList();
        }

        // GET: api/Adicionais/5
        [HttpGet("{id}")]
        public ActionResult<Adicional> GetAdicional(int id)
        {
            var adicional = service.ObterAdicionalPorId(id);

            if (adicional == null)
            {
                return NotFound();
            }

            return adicional;
        }

        // PUT: api/Adicionais/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutAdicional(int id, Adicional adicional)
        {
            if (id != adicional.Id)
            {
                return BadRequest();
            }

            try
            {
                service.AtualizarAdicional(adicional);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdicionalExists(id))
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

        // POST: api/Adicionais
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Adicional> PostAdicional(Adicional adicional)
        {
            service.CriarAdicional(adicional);

            return CreatedAtAction("GetAdicional", new { id = adicional.Id }, adicional);
        }

        // DELETE: api/Adicionais/5
        [HttpDelete("{id}")]
        public ActionResult<Adicional> DeleteAdicional(int id)
        {
            var adicional = service.ObterAdicionalPorId(id);
            if (adicional == null)
            {
                return NotFound();
            }

            service.ExcluirAdicional(id);

            return adicional;
        }

        private bool AdicionalExists(int id)
        {
            return service.AdicionalExiste(id);
        }
    }
}
