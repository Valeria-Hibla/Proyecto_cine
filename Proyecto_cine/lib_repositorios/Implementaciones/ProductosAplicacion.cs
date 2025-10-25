using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion? IConexion = null;

        public ProductosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Productos? Borrar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProductos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Productos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Productos> Listar()
        {
            return this.IConexion!.Productos!.Take(20).ToList();
        }
        public Productos? Modificar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProductos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Productos? Guardar(Productos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if ((entidad.Precio) < 0)
                throw new Exception("lbPrecioInvalido");

            if (entidad.IdProductos != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Productos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
