using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class MembresiasAplicacion : IMembresiasAplicacion
    {
        private IConexion? IConexion = null;

        public MembresiasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Membresias? Borrar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMembresias == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Membresias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Membresias> Listar()
        {
            return this.IConexion!.Membresias!.Take(20).ToList();
        }
        public Membresias? Modificar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMembresias == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Membresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Membresias? Guardar(Membresias? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");


            if (entidad.IdCliente == 0)
            {
                throw new Exception("lbClienteNoExiste");
            }
            if (entidad.IdMembresias != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Membresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
