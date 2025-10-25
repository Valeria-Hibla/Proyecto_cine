//se usa para declarar las variables de la entidad tecnicos
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Tecnicos
    {
        [Key] public int IdTecnicos { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public int IdEquipo { get; set; }
        [ForeignKey("IdEquipo")] public Equipos? _IdEquipo { get; set; }
    }
}
