using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class EquiposAplicacion : IEquiposAplicacion
    {
        private IConexion? IConexion = null;

        public EquiposAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Equipos? Borrar(Equipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEquipos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Equipos!.Remove(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Equipos",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Equipos> Listar()
        {
            var lista = this.IConexion!.Equipos!
                .Take(50).ToList();

            foreach (var elemento in lista)
            {
                elemento.Tecnicos = this.IConexion!.Tecnicos!
                    .Where(x => x.IdEquipo == elemento.IdEquipos)
                    .ToList();

            }
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Equipos",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return lista;
        }

        public List<Equipos> PorMarca(Equipos? entidad)
        {
            var lista = this.IConexion!.Equipos!
                            .Where(x => x.Marca!.Contains(entidad!.Marca!))
                            .Take(50)
                            .ToList();

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Equipos",
                Accion = "PorMarca",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return lista;
        }
        public Equipos? Modificar(Equipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEquipos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Equipos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Equipos",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Equipos? Guardar(Equipos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdSucursal == 0)
                throw new Exception("lbNoExisteElEquipo");

            this.IConexion!.Equipos!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Equipos",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}