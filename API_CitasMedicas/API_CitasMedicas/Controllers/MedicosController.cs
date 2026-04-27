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
    public class MedicosController : ControllerBase
    {
        // LA CLAVE: Esta lista estática vive en la RAM del servidor de Somee
        private static List<Medico> _medicosMemoria = new List<Medico>();

        // GET: api/Medicos/List
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedico()
        {
            // Retornamos la lista de la RAM
            return Ok(_medicosMemoria);
        }

        // POST: api/Medicos/Save
        [HttpPost("Save")]
        public async Task<ActionResult<Medico>> PostMedico(Medico medico)
        {
            // Simulamos un ID autoincremental
            medico.Id = _medicosMemoria.Count + 1;

            // Guardamos en la RAM
            _medicosMemoria.Add(medico);

            return Ok(medico);
        }

        // POST: api/Medicos/Update (Tu ApiService busca este para editar)
        [HttpPost("Update")]
        public async Task<IActionResult> PutMedico(Medico medico)
        {
            var index = _medicosMemoria.FindIndex(m => m.Id == medico.Id);
            if (index != -1)
            {
                _medicosMemoria[index] = medico;
                return Ok(true);
            }
            return NotFound();
        }

        // DELETE: api/Medicos/Deleted?id=5
        [HttpDelete("Deleted")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            var medico = _medicosMemoria.FirstOrDefault(m => m.Id == id);
            if (medico != null)
            {
                _medicosMemoria.Remove(medico);
                return Ok(true);
            }
            return NotFound();
        }
    }
}