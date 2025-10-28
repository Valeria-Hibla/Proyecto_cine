using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class EquiposAplicacion : IEquiposAplicacion
    {
        private IConexion? IConexion = null;

        public EquiposAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Equipos? Borrar(Equipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEquipos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Equipos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Equipos> Listar()
        {
            return this.IConexion!.Equipos!.Take(20)
                .Include(c => c.Tecnicos)
                .ToList();
        }
        public Equipos? Modificar(Equipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEquipos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Equipos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Equipos? Guardar(Equipos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdSucursal == 0)
                throw new Exception("lbNoExisteElEquipo");

            this.IConexion!.Equipos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}