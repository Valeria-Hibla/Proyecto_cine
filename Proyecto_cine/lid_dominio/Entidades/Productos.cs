//se usa para declarar las variables de la entidad productos
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Productos
    {
        [Key] public int IdProductos { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }

    }
}
