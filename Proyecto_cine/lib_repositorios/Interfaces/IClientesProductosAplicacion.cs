using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClientesProductosAplicacion
    {
        List<ClientesProductos> Listar();
        ClientesProductos? Guardar(ClientesProductos? entidad);
        ClientesProductos? Modificar(ClientesProductos? entidad);
        ClientesProductos? Borrar(ClientesProductos? entidad);
    }
}