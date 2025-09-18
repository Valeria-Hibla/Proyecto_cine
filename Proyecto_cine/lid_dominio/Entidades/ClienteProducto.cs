//se usa para declarar las variables de la entidad clienteproducto
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class ClienteProducto
    {
        [Key]public int IdClienteProducto { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Monto { get; set; }
        [ForeignKey("Productos")] public int IdProductos { get; set; }
        [ForeignKey("Clientes")] public int IdCliente { get; set; }
        List<Productos>? _Productos { get; set; }
        List<Clientes>? _Clientes { get; set; }
    }
}
