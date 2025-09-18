//se usa para declarar las variables de la entidad boletos
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    
    public class Boletos
    {
        [Key]public int IdBoletos { get; set; }
        public string? Asiento { get; set; }
        public decimal Precio { get; set; }
        [ForeignKey("Clientes")] public int IdCliente { get; set; }
        [ForeignKey("Salas")] public int IdSalas { get; set; }
        List<Clientes>? _Clientes { get; set; }
        List<Salas>? _Salas { get; set; }
    }
    
}
