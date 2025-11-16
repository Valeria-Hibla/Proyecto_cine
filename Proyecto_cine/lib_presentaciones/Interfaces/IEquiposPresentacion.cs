using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEquiposPresentacion
    {
        Task<List<Equipos>> Listar();
        Task<List<Equipos>> PorMarca(Equipos? entidad);
        Task<Equipos?> Guardar(Equipos? entidad);
        Task<Equipos?> Modificar(Equipos? entidad);
        Task<Equipos?> Borrar(Equipos? entidad);
    }
}