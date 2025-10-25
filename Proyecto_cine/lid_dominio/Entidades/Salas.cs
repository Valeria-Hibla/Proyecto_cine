//se usa para declarar las variables de la entidad salas
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Salas
    {
        [Key] public int IdSalas { get; set; }
        public int NumeroSala { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }
        public int IdSucursal { get; set; }
        [ForeignKey("IdSucursal")] public Sucursales? _IdSucursal { get; set; }
        public List<HorariosFunciones>? HorariosFunciones { get; set; }
        public List<Boletos>? Boletos { get; set; }
    }
}
