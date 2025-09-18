//se usa para declarar las variables de la entidad empleados
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Empleados
    {
        [Key] public int IdEmpleados { get; set; }
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        [ForeignKey("Sucursal")] public int IdSucursal { get; set; }
        List<Sucursales>? _Sucursales { get; set; }
}
}
