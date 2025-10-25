//se usa para declarar las variables de la entidad peliculas
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Peliculas
    {
        [Key] public int IdPelicula { get; set; }
        public string? Titulo { get; set; }
        public TimeSpan Duracion { get; set; }
        public string? Genero { get; set; }
        public int? IdClasificacion { get; set; }
        [ForeignKey("IdClasificacion")] public Clasificaciones? _IdClasificacion { get; set; }
        public List<HorariosFunciones>? HorariosFunciones { get; set; }
    }
}
