//se usa para declarar las variables de la entidad horariosempleados
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class HorariosEmpleados
    {
        [Key] public int IdHorariosEmpleados { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public int IdEmpleados { get; set; }
    }
}
