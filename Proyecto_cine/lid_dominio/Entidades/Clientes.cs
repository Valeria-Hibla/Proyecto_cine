//se usa para declarar las variables de la entidad clientes
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Clientes
    {
        [Key]public int IdCliente { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public int IdMembresia { get; set; }
        [ForeignKey("IdMembresia")] public Membresias? _IdMembresia { get; set; }
        public List<Boletos>? Boletos { get; set; }
        public List<ClientesProductos>? ClientesProductos { get; set; }
    }
}
