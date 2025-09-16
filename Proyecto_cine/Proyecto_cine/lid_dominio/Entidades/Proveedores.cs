//se usa para declarar las variables de la entidad proveedores
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Proveedores
    {
        [Key] public int IdProveedores { get; set; }
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public int IdProductos { get; set; }
    }
}
