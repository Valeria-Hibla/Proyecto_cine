using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class PeliculasAplicacion : IPeliculasAplicacion
    {
        private IConexion? IConexion = null;

        public PeliculasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Peliculas? Borrar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdPelicula == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Peliculas!.Remove(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Peliculas",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Peliculas> Listar()
        {
            var lista = this.IConexion!.Peliculas!
                .Take(50).ToList();


            foreach (var elemento in lista)
            {
                elemento.HorariosFunciones = this.IConexion!.HorariosFunciones!
                    .Where(x => x.IdPelicula == elemento.IdPelicula)
                    .ToList();

            }


            return lista;
        }
        public Peliculas? Modificar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdPelicula == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Peliculas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Peliculas",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Peliculas? Guardar(Peliculas? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrWhiteSpace(entidad.Titulo))
                throw new Exception("lbNombreRequerido");

            if ((entidad.Duracion.TotalHours > 5))
                throw new Exception("lbDuracionExcedida");

            if (entidad.IdPelicula == 0)
            {
                throw new Exception("lbProveedorNoExiste");
            }
            if (entidad.IdPelicula != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Peliculas!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Peliculas",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
