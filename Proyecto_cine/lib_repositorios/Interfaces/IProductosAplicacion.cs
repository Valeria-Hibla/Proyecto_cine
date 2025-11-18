using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IProductosAplicacion
    {
        void Configurar(string cadenaConexion);
        List<Productos> Listar();
        List<Productos> PorNombre(Productos? entidad);
        Productos? Guardar(Productos? entidad);
        Productos? Modificar(Productos? entidad);
        Productos? Borrar(Productos? entidad);
    }
}