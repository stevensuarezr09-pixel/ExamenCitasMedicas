namespace API_CitasMedicas.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public string Motivo { get; set; } = string.Empty;

       
        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }
    }
}