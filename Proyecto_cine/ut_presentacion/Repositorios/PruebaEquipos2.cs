using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaEquipos2
    {
        private readonly IEquiposAplicacion? iEquiposAplicacion;
        private List<Equipos>? lista;
        private Equipos? entidadEquipos;
        private Conexion iConexion = new Conexion();

        public PruebaEquipos2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iEquiposAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Equipos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadEquipos = EntidadesNucleo.Equipos()!;
            this.iConexion!.Equipos!.Add(this.entidadEquipos);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadEquipos!.Marca="Samsung";
            var entry = this.iConexion!.Entry<Equipos>(this.entidadEquipos);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Equipos!.Remove(this.entidadEquipos!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}