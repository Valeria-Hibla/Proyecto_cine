//se usa para declarar las variables de la entidad tecnicos
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Tecnicos
    {
        [Key] public int IdTecnicos { get; set; }
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        [ForeignKey ("Equipos")]public int IdEquipos { get; set; }
        List<Equipos>? _Equipos { get; set; }
    }
}
