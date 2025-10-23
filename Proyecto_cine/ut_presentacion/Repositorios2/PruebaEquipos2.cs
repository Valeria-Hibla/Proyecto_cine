using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
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
            iEquiposAplicacion = new EquiposAplicacion(iConexion);
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
            lista = iConexion!.Equipos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadEquipos = EntidadesNucleo.Equipos()!;
            iConexion!.Equipos!.Add(entidadEquipos);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadEquipos!.Marca="Samsung";
            var entry = iConexion!.Entry(entidadEquipos);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Equipos!.Remove(entidadEquipos!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}