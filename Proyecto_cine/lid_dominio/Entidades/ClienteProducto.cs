//se usa para declarar las variables de la entidad clienteproducto
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class ClienteProducto
    {
        [Key]public int IdClienteProducto { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Monto { get; set; }
        public int IdProductos { get; set; }
        public int IdCliente { get; set; }
    }
}
