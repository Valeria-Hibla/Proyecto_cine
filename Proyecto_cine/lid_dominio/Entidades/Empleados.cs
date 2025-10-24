using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Empleados
    {
        [Key] public int IdEmpleado { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int IdSucursal { get; set; }
        [ForeignKey("IdSucursal")] public Sucursales? _IdSucursal { get; set; }
        public int IdHorarioEmpleado { get; set; }
        [ForeignKey("IdHorarioEmpleado")] public HorariosEmpleados? _IdHorarioEmpleado { get; set; }
    }
}