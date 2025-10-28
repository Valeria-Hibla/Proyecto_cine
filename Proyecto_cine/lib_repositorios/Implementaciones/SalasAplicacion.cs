using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class SalasAplicacion : ISalasAplicacion
    {
        private IConexion? IConexion = null;

        public SalasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Salas? Borrar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSalas == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Salas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Salas> Listar()
        {
            return this.IConexion!.Salas!.Take(20)
                .Include(c => c.HorariosFunciones)
                .Include(c => c.Boletos)
                .ToList();
        }
        public Salas? Modificar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSalas == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Salas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Salas? Guardar(Salas? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if ((entidad.Capacidad) < 0)
                throw new Exception("lbCapacidadRequerida");

            if (entidad.IdSalas != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Salas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
