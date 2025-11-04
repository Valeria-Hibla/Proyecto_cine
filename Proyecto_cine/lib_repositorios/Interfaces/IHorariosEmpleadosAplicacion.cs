using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHorariosEmpleadosAplicacion
    {
        void Configurar(string cadenaConexion);
        List<HorariosEmpleados> Listar();
        HorariosEmpleados? Guardar(HorariosEmpleados? entidad);
        HorariosEmpleados? Modificar(HorariosEmpleados? entidad);
        HorariosEmpleados? Borrar(HorariosEmpleados? entidad);
    }
}
