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
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Salas",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Salas> Listar()
        {
            var lista = this.IConexion!.Salas!
                .Include(p => p._IdSucursal)
                .Take(50)
                .ToList();

            foreach (var elemento in lista)
            {
                //Boletos
                elemento.Boletos = this.IConexion!.Boletos!
                    .Where(x => x.IdSala == elemento.IdSalas)
                    .ToList();

                //HorariosFunciones
                elemento.HorariosFunciones = this.IConexion!.HorariosFunciones!
                    .Where(x => x.IdSala == elemento.IdSalas)
                    .ToList();

            }

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Salas",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return lista;
        }
        public Salas? Modificar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSalas == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Salas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Salas",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
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
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Salas",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
