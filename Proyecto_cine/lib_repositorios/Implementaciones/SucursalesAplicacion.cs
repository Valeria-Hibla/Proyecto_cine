using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class SucursalesAplicacion : ISucursalesAplicacion
    {
        private IConexion? IConexion = null;

        public SucursalesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Sucursales? Borrar(Sucursales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSucursal == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Sucursales!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Sucursales> Listar()
        {
            return this.IConexion!.Sucursales!.Take(20).ToList();
        }
        public Sucursales? Modificar(Sucursales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSucursal == 0)
                throw new Exception("lbNoSeGuardo");

            if (string.IsNullOrWhiteSpace(entidad.Nombre)) // Si el campo de nombre esta vacio/en blanco tira la excepcion
                throw new Exception("El nombre de la sucursal es obligatorio.");

            if (this.IConexion!.Sucursales!.Any(t => t.Direccion == entidad.Direccion))
                throw new Exception("lbDireccionDuplicado");

            var entry = this.IConexion!.Entry<Sucursales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Sucursales? Guardar(Sucursales? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrWhiteSpace(entidad.Direccion))
                throw new Exception("lbDireccionRequerido");

            if (string.IsNullOrWhiteSpace(entidad.Nombre)) 
                throw new Exception("El nombre de la sucursal es obligatorio.");

            if (this.IConexion!.Sucursales!.Any(t => t.Direccion == entidad.Direccion))
                throw new Exception("lbDireccionDuplicado");

            if (entidad.IdSucursal != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Sucursales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}