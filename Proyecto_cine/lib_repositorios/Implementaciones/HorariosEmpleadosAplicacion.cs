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
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Empleados",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<HorariosEmpleados> Listar()
        {
            var lista = this.IConexion!.HorariosEmpleados!
                .Take(50).ToList();

            foreach (var elemento in lista)
            {
                elemento.Empleados = this.IConexion!.Empleados!
                    .Where(x => x.IdHorarioEmpleado == elemento.IdHorariosEmpleados)
                    .ToList();

            }
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Empleados",
                Accion = "Listar",
                Fecha = DateTime.Now
            });

            return lista;
        }
        public HorariosEmpleados? Modificar(HorariosEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosEmpleados == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<HorariosEmpleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Empleados",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public HorariosEmpleados? Guardar(HorariosEmpleados? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");


            if ((entidad.HoraInicio.Hour) < 8)
                throw new Exception("lbHorarioNoExiste");

            this.IConexion!.HorariosEmpleados!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Horarios-Empleados",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}