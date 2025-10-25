using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class TecnicosAplicacion : ITecnicosAplicacion
    {
        private IConexion? IConexion = null;

        public TecnicosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Tecnicos? Borrar(Tecnicos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdTecnicos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Tecnicos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Tecnicos? Guardar(Tecnicos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if (this.IConexion!.Tecnicos!.Any(t => t.Nombre == entidad.Nombre))
                throw new Exception("lbNombreDuplicado");

            if (entidad.IdTecnicos != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Tecnicos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Tecnicos> Listar()
        {
            return this.IConexion!.Tecnicos!.Take(20).ToList();
        }
        public Tecnicos? Modificar(Tecnicos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdTecnicos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Tecnicos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
