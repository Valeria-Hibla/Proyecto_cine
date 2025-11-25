using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresAplicacion
    {
        private IConexion? IConexion = null;

        public ProveedoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Proveedores? Borrar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProveedor == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Proveedores!.Remove(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Proveedores",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Proveedores? Guardar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdProveedor != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Proveedores!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Proveedores",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Proveedores> Listar()
        {
            var lista = this.IConexion!.Proveedores!
                .Include(p => p._Producto)
                .Take(50)
                .ToList();
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Proveedores",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return lista;
        }

        public List<Proveedores> PorCedula(Proveedores? entidad)
        {
            var lista = this.IConexion!.Proveedores!
                        .Include(p => p._Producto)
                        .Where(x => x.Cedula!.Contains(entidad!.Cedula!))
                        .Take(50)
                        .ToList();

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Proveedores",
                Accion = "PorCedula",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return lista;
        }
        public Proveedores? Modificar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProveedor == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Proveedores",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}