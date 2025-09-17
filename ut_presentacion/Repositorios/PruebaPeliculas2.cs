using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
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
            iPeliculasAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Peliculas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadPeliculas = EntidadesNucleo.Peliculas()!;
            this.iConexion!.Peliculas!.Add(this.entidadPeliculas);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadPeliculas!.Titulo = "Test #2";
            var entry = this.iConexion!.Entry<Peliculas>(this.entidadPeliculas);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Peliculas!.Remove(this.entidadPeliculas!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}