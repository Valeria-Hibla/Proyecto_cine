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
        [ForeignKey("Sucursal")] public int IdSucursal { get; set; }
        List<Sucursales>? _Sucursales { get; set; }
    }
}
