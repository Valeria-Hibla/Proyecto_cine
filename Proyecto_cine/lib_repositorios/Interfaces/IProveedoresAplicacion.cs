using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IProveedoresAplicacion
    {
        List<Proveedores> ListarProveedores();
        Proveedores? Guardar(Proveedores? entidad);
        Proveedores? Modificar(Proveedores? entidad);
        Proveedores? Borrar(Proveedores? entidad);
    }
}