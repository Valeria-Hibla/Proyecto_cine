//se usa para declarar las variables de la entidad tecnicos
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Tecnicos
    {
        [Key] public int IdTecnicos { get; set; }
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public int IdEquipos { get; set; }
    }
}
