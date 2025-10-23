using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class ClientesProductosAplicacion : IClientesProductosAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesProductosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public ClientesProductos? Borrar(ClientesProductos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClienteProducto == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.ClientesProductos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClientesProductos> ListarClientesProductos()
        {
            return this.IConexion!.ClientesProductos!.Take(20).ToList();
        }
        public ClientesProductos? Modificar(ClientesProductos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClienteProducto == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<ClientesProductos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public ClientesProductos? Guardar(ClientesProductos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdCliente == 0)
                throw new Exception("lbNoExisteLaFactura");

            if ((entidad.IdProducto) == 0)
                throw new Exception("lbNoExisteLaFactura");

            if (entidad.Monto <= 0)
                throw new Exception("lbNoExisteLaFactura");

            this.IConexion!.ClientesProductos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}