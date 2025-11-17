using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Clientes? Borrar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCliente == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Clientes!.Remove(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdCliente != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Clientes!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Clientes> Listar()
        {
            // FALTA LA LISTA DE CLIENTES_PRODUCTOS
            var lista = this.IConexion!.Clientes!
                .Take(50).ToList();

            foreach (var elemento in lista)
            {
                //Boletos
                elemento.Boletos = this.IConexion!.Boletos!
                    .Where(x => x.IdCliente == elemento.IdCliente)
                    .ToList();

                // ClientesProductos
                elemento.ClientesProductos = this.IConexion!.ClientesProductos!
                    .Where(x => x.IdCliente == elemento.IdCliente)
                    .ToList();

            }
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return lista;
        }
        public Clientes? Modificar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCliente == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clientes",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}