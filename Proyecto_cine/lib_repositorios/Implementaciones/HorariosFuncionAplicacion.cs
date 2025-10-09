using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class HorariosFuncionAplicacion : IHorariosFuncionAplicacion
    {
        private IConexion? IConexion = null;

        public HorariosFuncionAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public HorariosFuncion? Borrar(HorariosFuncion? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosFuncion == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.HorariosFuncion!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<HorariosFuncion> ListarHorariosFuncion()
        {
            return this.IConexion!.HorariosFuncion!.Take(20).ToList();
        }
        public HorariosFuncion? Modificar(HorariosFuncion? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosFuncion == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<HorariosFuncion>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public HorariosFuncion? Guardar(HorariosFuncion? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Hora.TotalHours <= 0 && entidad.Hora.TotalSeconds <= 0)
                throw new Exception("lbHorarioDeFuncionNoValido");

            if ((entidad.IdPelicula) == 0)
                throw new Exception("lbNoExisteLaFuncion");

            if (entidad.IdSalas == 0)
                throw new Exception("lbNoExisteLaFuncion");

            if (entidad.IdHorariosFuncion != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.HorariosFuncion!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}