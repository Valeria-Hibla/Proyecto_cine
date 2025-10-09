using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class ClienteProductoAplicacion : IClienteProductoAplicacion
    {
        private IConexion? IConexion = null;

        public ClienteProductoAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public ClienteProducto? Borrar(ClienteProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClienteProducto == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.ClienteProducto!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClienteProducto> ListarClienteProducto()
        {
            return this.IConexion!.ClienteProducto!.Take(20).ToList();
        }
        public ClienteProducto? Modificar(ClienteProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClienteProducto == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<ClienteProducto>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public ClienteProducto? Guardar(ClienteProducto? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdCliente == 0)
                throw new Exception("lbNoExisteLaFactura");

            if ((entidad.IdProductos) == 0)
                throw new Exception("lbNoExisteLaFactura");

            if (entidad.Monto <= 0)
                throw new Exception("lbNoExisteLaFactura");

            this.IConexion!.ClienteProducto!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}