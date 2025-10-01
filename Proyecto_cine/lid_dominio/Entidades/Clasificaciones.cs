using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Clasificaciones
    {
        [Key] public int IdClasificaciones { get; set; }
        public string? Categoria { get; set; }
        public int EdadMinima { get; set; }
        public string? Descripcion { get; set; }
    }
}
