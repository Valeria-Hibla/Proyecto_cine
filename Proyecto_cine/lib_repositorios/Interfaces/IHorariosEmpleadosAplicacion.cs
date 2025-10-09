using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHorariosEmpleadosAplicacion
    {
        List<HorariosEmpleados> ListarHorariosEmpleados();
        HorariosEmpleados? Guardar(HorariosEmpleados? entidad);
        HorariosEmpleados? Modificar(HorariosEmpleados? entidad);
        HorariosEmpleados? Borrar(HorariosEmpleados? entidad);
    }
}
