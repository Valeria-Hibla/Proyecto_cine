//se usa para declarar las variables de la entidad clientes
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Clientes
    {
        [Key]public int IdCliente { get; set; }
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public short Edad { get; set; }

    }
}
