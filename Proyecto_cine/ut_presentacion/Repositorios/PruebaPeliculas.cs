using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de Peliculas
    [TestClass]
    public class PruebaPeliculas
    {
        private readonly IConexion? iConexion;
        private List<Peliculas>? lista;
        private Peliculas? entidadPeliculas;

        public PruebaPeliculas()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
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
            this.entidadPeliculas!.Titulo= "Prueba unitaria #1 -" + DateTime.Now.ToString("yyyy-MM-dd");
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
