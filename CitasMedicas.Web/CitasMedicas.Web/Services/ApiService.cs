using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Json;

namespace CitasMedicas.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        // IMPORTANTE: Cuando publiques en Somee, cambia esta URL
        // CAMBIADO: Ahora apunta a Somee
        private readonly string _baseUrl = "https://api-citas-examen.onrender.com/api/";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // 1. Obtener lista (Ajustado a /List)
        public async Task<List<T>> GetListAsync<T>(string entity)
        {
            try
            {
                // El examen pide: /api/pacientes/List
                var response = await _httpClient.GetAsync($"{_baseUrl}{entity}/List");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(content) ?? new List<T>();
                }
                return new List<T>();
            }
            catch { return new List<T>(); }
        }

        // 2. Crear (Ajustado a PUT /Save según página 3 del examen)
        public async Task<bool> PostAsync<T>(string entity, T data)
        {
            // El examen pide: PUT /api/pacientes/Save
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}{entity}/Save", data);
            return response.IsSuccessStatusCode;
        }

        // 3. Editar (Ajustado a POST /Update según página 3 del examen)
        public async Task<bool> PutAsync<T>(string entity, T data)
        {
            // El examen pide: POST /api/pacientes/Update
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}{entity}/Update", data);
            return response.IsSuccessStatusCode;
        }

        // 4. Eliminar (Ajustado a DELETE /Deleted?id={id} según página 3)
        public async Task<bool> DeleteAsync(string entity, int id)
        {
            // El examen pide: DELETE /api/pacientes/Deleted?id=5
            var response = await _httpClient.DeleteAsync($"{_baseUrl}{entity}/Deleted?id={id}");
            return response.IsSuccessStatusCode;
        }
    }
}