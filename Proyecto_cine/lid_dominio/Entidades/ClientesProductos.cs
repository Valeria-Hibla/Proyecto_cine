//se usa para declarar las variables de la entidad clienteproducto
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
        [NotMapped] public Productos? _IdProducto { get; set; }
        public int IdCliente { get; set; }
        [NotMapped] public Clientes? _IdCliente { get; set; }
        /*List<Productos>? _Productos { get; set; }
        List<Clientes>? _Clientes { get; set; }*/
    }
}
