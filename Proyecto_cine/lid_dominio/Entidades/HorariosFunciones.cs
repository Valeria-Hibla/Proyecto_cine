//se usa para declarar las variables de la entidad horariosfuncion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class HorariosFunciones
    {
        [Key] public int IdHorariosFuncion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdSala { get; set; }
        [NotMapped]public Salas? _Sala { get; set; }
        public int IdPelicula { get; set; }
        [NotMapped] public Peliculas? _Pelicula { get; set; }
    }
}
