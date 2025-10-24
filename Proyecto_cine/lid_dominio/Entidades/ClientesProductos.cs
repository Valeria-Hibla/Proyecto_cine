using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class ClientesProductos
    {
        [Key]public int IdClienteProducto { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Monto { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")] public Productos? _IdProducto { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _IdCliente { get; set; }
    }
}
