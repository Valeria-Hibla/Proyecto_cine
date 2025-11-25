using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class HorariosFuncionesAplicacion : IHorariosFuncionesAplicacion
    {
        private IConexion? IConexion = null;

        public HorariosFuncionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public HorariosFunciones? Borrar(HorariosFunciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosFuncion == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.HorariosFunciones!.Remove(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Funciones",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<HorariosFunciones> Listar()
        {
            var lista = this.IConexion!.HorariosFunciones!
                .Include(p => p._IdSala)
                .Include(p => p._IdPelicula)
                .Take(50)
                .ToList();
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Funciones",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return lista;
        }
        public HorariosFunciones? Modificar(HorariosFunciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosFuncion == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<HorariosFunciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Funciones",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public HorariosFunciones? Guardar(HorariosFunciones? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if(entidad.IdHorariosFuncion != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.HorariosFunciones!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Funciones",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}