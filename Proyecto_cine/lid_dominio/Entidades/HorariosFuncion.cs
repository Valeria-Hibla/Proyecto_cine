//se usa para declarar las variables de la entidad horariosfuncion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class HorariosFuncion
    {
        [Key] public int IdHorariosFuncion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora {  get; set; }
        [ForeignKey("Salas")] public int IdSalas { get; set; }
        [ForeignKey("Peliculas")] public int IdPelicula { get; set; }
        List<Salas>? _Salas { get; set; }
        List<Peliculas>? _Peliculas { get; set; }
    }
}
