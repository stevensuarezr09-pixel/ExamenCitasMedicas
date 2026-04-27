using Microsoft.AspNetCore.Mvc;
using CitasMedicas.Web.Services;
using API_CitasMedicas.Models;

namespace CitasMedicas.Web.Controllers
{
    public class CitasController : Controller
    {
        private readonly ApiService _apiService;
        public CitasController() { _apiService = new ApiService(); }

        public async Task<IActionResult> Index()
        {
            // Cambiamos a "citas" para consistencia con la API
            var lista = await _apiService.GetListAsync<Cita>("citas");
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cita cita)
        {
            // Llama a PUT /api/citas/Save según el examen
            var exito = await _apiService.PostAsync("citas", cita);
            if (exito) return RedirectToAction(nameof(Index));
            return View(cita);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lista = await _apiService.GetListAsync<Cita>("citas");
            var cita = lista.FirstOrDefault(c => c.Id == id);
            return View(cita);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cita cita)
        {
            // Llama a POST /api/citas/Update según el examen
            await _apiService.PutAsync("citas", cita);
            return RedirectToAction(nameof(Index));
        }

        // Aquí es donde se corregirá el error rojo CS7036
        public async Task<IActionResult> Delete(int id)
        {
            // Enviamos entidad "citas" e ID por separado
            // Generará: /api/citas/Deleted?id=X
            await _apiService.DeleteAsync("citas", id);
            return RedirectToAction(nameof(Index));
        }
    }
}