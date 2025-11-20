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
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Membresias",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Membresias> Listar()
        {
            var lista = this.IConexion!.Membresias!
                .Take(50).ToList();

            foreach (var elemento in lista)
            {
                elemento.Clientes = this.IConexion!.Clientes!
                    .Where(x => x.IdMembresia == elemento.IdMembresias)
                    .ToList();

            }
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Membresias",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return lista;
        }

        public List<Membresias> PorNombre(Membresias? entidad)
        {
            var lista = this.IConexion!.Membresias!
                            .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                            .Take(50)
                            .ToList();

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Membresias",
                Accion = "PorNombre",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return lista;
        }
        public Membresias? Modificar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMembresias == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Membresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Membresias",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Membresias? Guardar(Membresias? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if (entidad.IdMembresias != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Membresias!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Membresias",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
