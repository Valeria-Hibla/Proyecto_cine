using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMembresiasPresentacion
    {
        Task<List<Membresias>> Listar();
        Task<List<Membresias>> PorNombre(Membresias? entidad);
        Task<Membresias?> Guardar(Membresias? entidad);
        Task<Membresias?> Modificar(Membresias? entidad);
        Task<Membresias?> Borrar(Membresias? entidad);
    }
}