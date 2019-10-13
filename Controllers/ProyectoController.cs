using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ng_core_crud.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ng_core_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public ProyectoController(ProyectoContext context)
        {
            _context = context;

            if (_context.Proyectos.Count() == 0)
            {
                // Create a new TodoItem if collection is empty, which means you can't delete all TodoItems.
                _context.Proyectos.Add(new Proyecto {
                    Codigo = "OIK-00",
                    Nombre = "Proyecto zero",
                    Estado = "Propuesto",
                    Archivo = null
                });
                _context.Proyectos.Add(new Proyecto {
                    Codigo = "OIK-35",
                    Nombre = "Detección de patrones delictivos",
                    Estado = "Ejecucion",
                    Archivo = null
                });
                _context.Proyectos.Add(new Proyecto {
                    Codigo = "OIK-07",
                    Nombre = "Alcantarillado para el pueblo",
                    Estado = "Viable",
                    Archivo = null
                });
                _context.Proyectos.Add(new Proyecto {
                    Codigo = "OIK-12",
                    Nombre = "Implementación de paneles solares",
                    Estado = "Viable",
                    Archivo = null
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAll()
        {
            return await _context.Proyectos.ToListAsync();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> Get(long id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        [ProducesResponseType(201)]     // Created
        [ProducesResponseType(400)]     // BadRequest
        
        //POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Proyecto>> Post(Proyecto item)
        {
            _context.Proyectos.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Proyecto item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}