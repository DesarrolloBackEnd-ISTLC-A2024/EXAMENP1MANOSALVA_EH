namespace EXAMENP1MANOSALVA_EH.Model
{
    public class Equipo
    {
        public int Id_equipo { get; set; }
        public string Nombre { get; set; }
        public int? Partidos { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? equipoModificacion { get; set; }
    }
}
