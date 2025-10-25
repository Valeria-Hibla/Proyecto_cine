//se usa para declarar las variables de la entidad horariosfuncion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class HorariosFunciones
    {
        [Key] public int IdHorariosFuncion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly? Hora { get; set; }
        public int IdSala { get; set; }
        [ForeignKey("IdSala")] public Salas? _IdSala { get; set; }
        public int IdPelicula { get; set; }
        [ForeignKey("IdPelicula")] public Peliculas? _IdPelicula { get; set; }
    }
}
