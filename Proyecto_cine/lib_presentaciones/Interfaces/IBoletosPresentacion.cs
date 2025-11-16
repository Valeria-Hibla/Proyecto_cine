using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IBoletosPresentacion
    {
        Task<List<Boletos>> Listar();
        //Task<List<Boletos>> PorPrecio(Boletos? entidad);

        Task<Boletos?> Guardar(Boletos? entidad);
        Task<Boletos?> Modificar(Boletos? entidad);
        Task<Boletos?> Borrar(Boletos? entidad);
    }
}