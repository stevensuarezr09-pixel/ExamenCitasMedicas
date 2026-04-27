using Microsoft.AspNetCore.Mvc;
using CitasMedicas.Web.Services;
using API_CitasMedicas.Models;

namespace CitasMedicas.Web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApiService _apiService;

        public PacientesController()
        {
            _apiService = new ApiService();
        }

        public async Task<IActionResult> Index()
        {
            // Usamos "pacientes" en minúscula para que coincida con la ruta de la API
            var lista = await _apiService.GetListAsync<Paciente>("pacientes");
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            // Ahora llama a PUT /api/pacientes/Save
            var exito = await _apiService.PostAsync("pacientes", paciente);
            if (exito) return RedirectToAction(nameof(Index));
            return View(paciente);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lista = await _apiService.GetListAsync<Paciente>("pacientes");
            var paciente = lista.FirstOrDefault(p => p.Id == id);
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Paciente paciente)
        {
            // Ahora llama a POST /api/pacientes/Update (según el examen)
            await _apiService.PutAsync("pacientes", paciente);
            return RedirectToAction(nameof(Index));
        }

        // Este es el que te daba el error rojo CS7036
        public async Task<IActionResult> Delete(int id)
        {
            // Ahora enviamos la entidad "pacientes" y el id como un número entero
            // Esto generará la ruta: /api/pacientes/Deleted?id=X
            await _apiService.DeleteAsync("pacientes", id);
            return RedirectToAction(nameof(Index));
        }
    }
}