using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClientesAplicacion
    {
        List<Clientes> ListarClientes();
        Clientes? Guardar(Clientes? entidad);
        Clientes? Modificar(Clientes? entidad);
        Clientes? Borrar(Clientes? entidad);
    }
}