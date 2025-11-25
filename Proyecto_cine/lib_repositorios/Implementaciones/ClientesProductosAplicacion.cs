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
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes-Productos",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClientesProductos> Listar()
        {

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes-Productos",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return this.IConexion!.ClientesProductos!
                .Include(p => p._IdProducto)
                .Include(p => p._IdCliente)
                .Take(50)
                .ToList();
        }
        public ClientesProductos? Modificar(ClientesProductos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClienteProducto == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<ClientesProductos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes-Productos",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public ClientesProductos? Guardar(ClientesProductos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdClienteProducto != 0)
                throw new Exception("lbYaSeGuardo");


            if (entidad.Monto <= 0)
                throw new Exception("lbNoExisteLaFactura");

            this.IConexion!.ClientesProductos!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes-Productos",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}