//se usa para declarar las variables de la entidad horariosfuncion
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class HorariosFuncion
    {
        [Key] public int IdHorariosFuncion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdSalas { get; set; }
        public int IdPelicula { get; set; }
    }
}
