using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ISucursalesAplicacion
    {
        void Configurar(string cadenaConexion);
        List<Sucursales> Listar();
        List<Sucursales> PorCiudad(Sucursales? entidad);
        Sucursales? Guardar(Sucursales? entidad);
        Sucursales? Modificar(Sucursales? entidad);
        Sucursales? Borrar(Sucursales? entidad);
    }
}