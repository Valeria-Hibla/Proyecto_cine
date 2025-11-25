using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Roles
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public int? IdUsuario { get; set; }
        [ForeignKey("IdUsuario")] public Usuarios? _IdUsuario { get; set; }
        public int? IdPermiso { get; set; }
        [ForeignKey("IdPermiso")] public Permisos? _IdPermiso { get; set; }
    }
}
