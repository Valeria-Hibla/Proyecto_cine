using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaPeliculas2
    {
        private readonly IPeliculasAplicacion? iPeliculasAplicacion;
        private List<Peliculas>? lista;
        private Peliculas? entidadPeliculas;
        private Conexion iConexion = new Conexion();

        public PruebaPeliculas2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iPeliculasAplicacion = new PeliculasAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar()
        {
            lista = iConexion!.Peliculas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadPeliculas = EntidadesNucleo.Peliculas()!;
            iConexion!.Peliculas!.Add(entidadPeliculas);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadPeliculas!.Titulo = "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = iConexion!.Entry(entidadPeliculas);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Peliculas!.Remove(entidadPeliculas!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}