using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ISucursalesAplicacion
    {
        List<Sucursales> ListarSucursales();
        Sucursales? Guardar(Sucursales? entidad);
        Sucursales? Modificar(Sucursales? entidad);
        Sucursales? Borrar(Sucursales? entidad);
    }
}