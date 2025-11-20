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
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Boletos",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Boletos> Listar()
        {

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Boletos",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
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

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Boletos",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Boletos? Guardar(Boletos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdBoletos != 0)
                throw new Exception("lbYaSeGuardo");

            if (entidad.Precio <= 0)
                throw new Exception("lb El Precio no puede ser negativo");

            this.IConexion!.Boletos!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Boletos",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}