using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITecnicosPresentacion
    {
        Task<List<Tecnicos>> Listar();
        Task<List<Tecnicos>> PorCedula(Tecnicos? entidad);
        Task<Tecnicos?> Guardar(Tecnicos? entidad);
        Task<Tecnicos?> Modificar(Tecnicos? entidad);
        Task<Tecnicos?> Borrar(Tecnicos? entidad);
    }
}