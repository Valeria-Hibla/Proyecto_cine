using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IHorariosEmpleadosPresentacion
    {
        Task<List<HorariosEmpleados>> Listar();
        Task<HorariosEmpleados?> Guardar(HorariosEmpleados? entidad);
        Task<HorariosEmpleados?> Modificar(HorariosEmpleados? entidad);
        Task<HorariosEmpleados?> Borrar(HorariosEmpleados? entidad);
    }
}