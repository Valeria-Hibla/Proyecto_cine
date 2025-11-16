using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISalasPresentacion
    {
        Task<List<Salas>> Listar();
        //Task<List<Salas>> PorCapacidad(Salas? entidad);
        Task<Salas?> Guardar(Salas? entidad);
        Task<Salas?> Modificar(Salas? entidad);
        Task<Salas?> Borrar(Salas? entidad);
    }
}