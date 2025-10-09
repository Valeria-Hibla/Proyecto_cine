using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEmpleadosAplicacion
    {
        List<Empleados> ListarEmpleados();
        Empleados? Guardar(Empleados? entidad);
        Empleados? Modificar(Empleados? entidad);
        Empleados? Borrar(Empleados? entidad);
    }
}