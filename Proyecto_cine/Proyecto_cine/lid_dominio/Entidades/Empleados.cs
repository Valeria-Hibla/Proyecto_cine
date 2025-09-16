//se usa para declarar las variables de la entidad empleados
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Empleados
    {
        [Key] public int IdEmpleados { get; set; }
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int IdSucursal { get; set; }
    }
}
