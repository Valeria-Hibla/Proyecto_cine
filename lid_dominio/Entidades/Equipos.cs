//se usa para declarar las variables de la entidad equipos
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Equipos
    {
        [Key] public int IdEquipos { get; set; }
        public string? Tipo { get; set; }
        public string? Marca { get; set; }
        public bool Estado { get; set; }

        [ForeignKey("Sucursal")] public int IdSucursal { get; set; }
    }
}
