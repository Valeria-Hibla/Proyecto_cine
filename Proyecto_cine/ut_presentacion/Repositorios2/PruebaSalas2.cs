using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaSalas2
    {
        private readonly ISalasAplicacion? iSalasAplicacion;
        private List<Salas>? lista;
        private Salas? entidadSalas;
        private Conexion iConexion = new Conexion();

        public PruebaSalas2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iSalasAplicacion = new SalasAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
            Assert.ThrowsException<Exception>(() => SacarExcepcion());
        }
        public bool Listar()
        {
            lista = iConexion!.Salas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadSalas = EntidadesNucleo.Salas()!;
            iConexion!.Salas!.Add(entidadSalas);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadSalas!.Capacidad = 43;
            var entry = iConexion!.Entry(entidadSalas);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Salas!.Remove(entidadSalas!);
            iConexion!.SaveChanges();
            return true;
        }
        public void SacarExcepcion()
        {
            iSalasAplicacion!.Borrar(null);
        }
    }
}