using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class BoletosAplicacion : IBoletosAplicacion
    {
        private IConexion? IConexion = null;

        public BoletosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Boletos? Borrar(Boletos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdBoletos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Boletos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Boletos> ListarBoletos()
        {
            return this.IConexion!.Boletos!.Take(20).ToList();
        }
        public Boletos? Modificar(Boletos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdBoletos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Boletos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Boletos? Guardar(Boletos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdSala == 0)
                throw new Exception("lbNoExistenLosBoletos");

            if ((entidad.IdCliente) == 0)
                throw new Exception("lbNoExistenLosBoletos");

            if (entidad.Precio <= 0)
                throw new Exception("lbNoExistenLosBoletos");

            this.IConexion!.Boletos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}