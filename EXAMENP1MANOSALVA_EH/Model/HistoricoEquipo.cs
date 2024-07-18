namespace EXAMENP1MANOSALVA_EH.Model
{
    public class HistoricoEquipo
    {
        public int Id { get; set; }
        public int FutbolistaId { get; set; }
        public int EquipoId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Futbolista Futbolista { get; set; }
        public Equipo Equipo { get; set; }
    }
}
