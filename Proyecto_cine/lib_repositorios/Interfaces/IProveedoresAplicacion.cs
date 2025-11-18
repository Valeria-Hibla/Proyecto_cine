using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IProveedoresAplicacion
    {
        void Configurar(string cadenaConexion);
        List<Proveedores> Listar();
        List<Proveedores> PorCedula(Proveedores? entidad);
        Proveedores? Guardar(Proveedores? entidad);
        Proveedores? Modificar(Proveedores? entidad);
        Proveedores? Borrar(Proveedores? entidad);
    }
}