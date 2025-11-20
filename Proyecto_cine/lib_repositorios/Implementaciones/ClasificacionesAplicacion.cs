using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace lib_repositorios.Implementaciones
{
    public class ClasificacionesAplicacion : IClasificacionesAplicacion
    {
        private IConexion? IConexion = null;

        public ClasificacionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Clasificaciones? Borrar(Clasificaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClasificacion == 0)
                throw new Exception("lbNoSeGuardo");


            this.IConexion!.Clasificaciones!.Remove(entidad);

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clasificaciones",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<Clasificaciones> Listar()
        {
            var lista = this.IConexion!.Clasificaciones!
                .Take(50).ToList();

            foreach (var elemento in lista)
            {
                elemento.Peliculas = this.IConexion!.Peliculas!
                    .Where(x => x.IdClasificacion == elemento.IdClasificacion)
                    .ToList();
            }

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clasificaciones",
                Accion = "Listar",
                Fecha = DateTime.Now
            });

            return lista;
        }

        public List<Clasificaciones> PorCategoria(Clasificaciones? entidad)
        {
            var lista = this.IConexion!.Clasificaciones!
                            .Where(x => x.Categoria!.Contains(entidad!.Categoria!))
                            .Take(50)
                            .ToList();

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clasificaciones",
                Accion = "PorCategoria",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return lista;
        }

        public Clasificaciones? Modificar(Clasificaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClasificacion == 0)
                throw new Exception("lbNoSeGuardo");


            var entry = this.IConexion!.Entry<Clasificaciones>(entidad);
            entry.State = EntityState.Modified;

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clasificaciones",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Clasificaciones? Guardar(Clasificaciones? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.IdClasificacion != 0)
                throw new Exception("lbYaSeGuardo");

            if (entidad.EdadMinima < 0)
                throw new Exception("lb La edad minima no puede ser menor de 0");


            this.IConexion!.Clasificaciones!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Clasificaciones",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}