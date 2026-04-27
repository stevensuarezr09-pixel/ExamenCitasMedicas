using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_CitasMedicas.Models;

namespace API_CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        // La lista estática para guardar las citas en RAM
        private static List<Cita> _citasMemoria = new List<Cita>();

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCita()
        {
            // Retornamos la lista directamente (en memoria ya tiene los objetos si los guardas bien)
            return Ok(_citasMemoria);
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = _citasMemoria.FirstOrDefault(c => c.Id == id);
            if (cita == null) return NotFound();
            return Ok(cita);
        }

        // PUT: api/Citas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.Id) return BadRequest();

            var index = _citasMemoria.FindIndex(c => c.Id == id);
            if (index != -1)
            {
                _citasMemoria[index] = cita;
                return NoContent();
            }
            return NotFound();
        }

        // POST: api/Citas
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            // Simulamos ID autoincremental
            cita.Id = (_citasMemoria.Count > 0) ? _citasMemoria.Max(c => c.Id) + 1 : 1;

            _citasMemoria.Add(cita);

            return CreatedAtAction("GetCita", new { id = cita.Id }, cita);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = _citasMemoria.FirstOrDefault(c => c.Id == id);
            if (cita == null) return NotFound();

            _citasMemoria.Remove(cita);
            return NoContent();
        }

        private bool CitaExists(int id)
        {
            return _citasMemoria.Any(e => e.Id == id);
        }
    }
}