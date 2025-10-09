using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class HorariosEmpleadosAplicacion : IHorariosEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public HorariosEmpleadosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public HorariosEmpleados? Borrar(HorariosEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosEmpleados == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.HorariosEmpleados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<HorariosEmpleados> ListarHorariosEmpleados()
        {
            return this.IConexion!.HorariosEmpleados!.Take(20).ToList();
        }
        public HorariosEmpleados? Modificar(HorariosEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosEmpleados == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<HorariosEmpleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public HorariosEmpleados? Guardar(HorariosEmpleados? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdEmpleados == 0)
                throw new Exception("lbHorarioNoExite");

            if ((entidad.HoraInicio.Hour) < 8)
                throw new Exception("lbHorarioNoExiste");

            this.IConexion!.HorariosEmpleados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}