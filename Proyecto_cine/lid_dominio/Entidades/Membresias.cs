//se usa para declarar las variables de la entidad membresias
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Membresias
    {
        [Key] public int IdMembresias { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        [NotMapped] public List<Clientes>? Clientes{ get; set; }
    }
}
