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
    public class PacientesController : ControllerBase
    {
        // La lista mágica que nos salva el examen
        private static List<Paciente> _pacientesMemoria = new List<Paciente>();

        // GET: api/Pacientes/List
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()
        {
            return Ok(_pacientesMemoria);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = _pacientesMemoria.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

        // POST: api/Pacientes/Update
        [HttpPost("Update")]
        public async Task<IActionResult> PutPaciente(Paciente paciente)
        {
            var index = _pacientesMemoria.FindIndex(p => p.Id == paciente.Id);
            if (index != -1)
            {
                _pacientesMemoria[index] = paciente;
                return Ok();
            }
            return NotFound();
        }

        // PUT: api/Pacientes/Save
        [HttpPut("Save")]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            // Generamos un ID manual
            paciente.Id = (_pacientesMemoria.Count > 0) ? _pacientesMemoria.Max(p => p.Id) + 1 : 1;

            _pacientesMemoria.Add(paciente);

            // Código 201 Created como pide el profe
            return StatusCode(201, paciente);
        }

        // DELETE: api/Pacientes/Deleted?id={id}
        [HttpDelete("Deleted")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = _pacientesMemoria.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();

            _pacientesMemoria.Remove(paciente);
            return Ok();
        }
    }
}