using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClasificacionesPresentacion
    {
        Task<List<Clasificaciones>> Listar();
        Task<List<Clasificaciones>> PorClasificacion(Clasificaciones? entidad);
        Task<Clasificaciones?> Guardar(Clasificaciones? entidad);
        Task<Clasificaciones?> Modificar(Clasificaciones? entidad);
        Task<Clasificaciones?> Borrar(Clasificaciones? entidad);
    }
}