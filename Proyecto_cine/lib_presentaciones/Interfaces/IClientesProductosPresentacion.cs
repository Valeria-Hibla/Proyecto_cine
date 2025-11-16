using System.Diagnostics.Metrics;
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesProductosPresentacion
    {
        Task<List<ClientesProductos>> Listar();
        //Task<List<ClientesProductos>> PorFecha(ClientesProductos? entidad);
        Task<ClientesProductos?> Guardar(ClientesProductos? entidad);
        Task<ClientesProductos?> Modificar(ClientesProductos? entidad);
        Task<ClientesProductos?> Borrar(ClientesProductos? entidad);
    }
}