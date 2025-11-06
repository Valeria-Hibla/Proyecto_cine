//se usa para declarar las variables de la entidad sucursales
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Sucursales
    {
        [Key] public int IdSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        [NotMapped] public List<Salas>? Salas { get; set; }
        [NotMapped] public List<Empleados>? Empleados { get; set; }
        [NotMapped] public List<Equipos>? Equipos { get; set; }
    }
}
