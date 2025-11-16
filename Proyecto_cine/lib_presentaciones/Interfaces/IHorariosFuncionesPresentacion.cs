using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IHorariosFuncionesPresentacion
    {
        Task<List<HorariosFunciones>> Listar();
        Task<HorariosFunciones?> Guardar(HorariosFunciones? entidad);
        Task<HorariosFunciones?> Modificar(HorariosFunciones? entidad);
        Task<HorariosFunciones?> Borrar(HorariosFunciones? entidad);
    }
}