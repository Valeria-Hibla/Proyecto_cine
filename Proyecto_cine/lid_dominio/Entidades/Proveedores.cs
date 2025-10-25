//se usa para declarar las variables de la entidad proveedores
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Proveedores
    {
        [Key] public int IdProveedor { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")] public Productos? _Producto { get; set; }

    }
}
