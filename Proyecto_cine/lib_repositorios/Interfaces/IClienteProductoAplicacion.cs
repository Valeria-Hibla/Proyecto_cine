using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClienteProductoAplicacion
    {
        List<ClienteProducto> ListarClienteProducto();
        ClienteProducto? Guardar(ClienteProducto? entidad);
        ClienteProducto? Modificar(ClienteProducto? entidad);
        ClienteProducto? Borrar(ClienteProducto? entidad);
    }
}