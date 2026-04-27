namespace API_CitasMedicas.Models
{
    public class Paciente
    {
        public int Id { get; set; } // El examen pide Id como PK
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
    }
}