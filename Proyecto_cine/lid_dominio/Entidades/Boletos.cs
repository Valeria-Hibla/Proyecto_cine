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
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _IdCliente { get; set; }
        //[NotMapped] public Clientes? _IdCliente { get; set; }
        public int IdSala { get; set; }
        [ForeignKey("IdSala")] public Salas? _IdSala { get; set; }
        //[NotMapped] public Salas? _IdSala { get; set; }
        
        /*List<Clientes>? _Clientes { get; set; }
        List<Salas>? _Salas { get; set; }*/
        // Las listas no se necesitan 
    }
    
}
