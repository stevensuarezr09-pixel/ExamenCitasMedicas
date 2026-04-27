using Microsoft.AspNetCore.Mvc;
using CitasMedicas.Web.Services;
using API_CitasMedicas.Models;

namespace CitasMedicas.Web.Controllers
{
    public class MedicosController : Controller
    {
        private readonly ApiService _apiService;

        public MedicosController()
        {
            _apiService = new ApiService();
        }

        // Listado de Médicos (Llamará a /api/medicos/List)
        public async Task<IActionResult> Index()
        {
            var lista = await _apiService.GetListAsync<Medico>("medicos");
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Crear (Llamará a PUT /api/medicos/Save)
        [HttpPost]
        public async Task<IActionResult> Create(Medico medico)
        {
            var exito = await _apiService.PostAsync("medicos", medico);
            if (exito)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lista = await _apiService.GetListAsync<Medico>("medicos");
            var medico = lista.FirstOrDefault(m => m.Id == id);
            if (medico == null) return NotFound();
            return View(medico);
        }

        // Editar (Llamará a POST /api/medicos/Update)
        [HttpPost]
        public async Task<IActionResult> Edit(Medico medico)
        {
            // Ya no pasamos la ruta con el ID, solo el nombre de la entidad
            var exito = await _apiService.PutAsync("medicos", medico);
            if (exito) return RedirectToAction(nameof(Index));
            return View(medico);
        }

        // Eliminar (Llamará a DELETE /api/medicos/Deleted?id=X)
        public async Task<IActionResult> Delete(int id)
        {
            // Corregimos el error enviando entidad e id por separado
            var exito = await _apiService.DeleteAsync("medicos", id);
            return RedirectToAction(nameof(Index));
        }
    }
}