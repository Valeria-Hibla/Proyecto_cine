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
        [ForeignKey ("Clientes")]public int IdCliente { get; set; }
        
        public int IdSalas { get; set; }
    }
    
}
