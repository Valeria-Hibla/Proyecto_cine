using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IProductosAplicacion
    {
        List<Productos> ListarProductos();
        Productos? Guardar(Productos? entidad);
        Productos? Modificar(Productos? entidad);
        Productos? Borrar(Productos? entidad);
    }
}