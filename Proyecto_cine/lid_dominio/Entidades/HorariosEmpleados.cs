//se usa para declarar las variables de la entidad horariosempleados
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class HorariosEmpleados
    {
        [Key] public int IdHorariosEmpleados { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        [ForeignKey("Empleados")] public int IdEmpleados { get; set; }
        List<Empleados>? _Empleados { get; set; }
    }
}
