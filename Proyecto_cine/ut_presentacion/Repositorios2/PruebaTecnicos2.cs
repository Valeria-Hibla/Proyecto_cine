using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaTecnicos2
    {
        private readonly ITecnicosAplicacion? iTecnicosAplicacion;
        private List<Tecnicos>? lista;
        private Tecnicos? entidadTecnicos;
        private Conexion iConexion = new Conexion();

        public PruebaTecnicos2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iTecnicosAplicacion = new TecnicosAplicacion(iConexion);
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
            lista = iConexion!.Tecnicos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadTecnicos = EntidadesNucleo.Tecnicos()!;
            iConexion!.Tecnicos!.Add(entidadTecnicos);
            iConexion!.SaveChanges();
            return true;
        }
        
        public bool Modificar()
        {
            entidadTecnicos!.Nombre = "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = iConexion!.Entry(entidadTecnicos);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Tecnicos!.Remove(entidadTecnicos!);
            iConexion!.SaveChanges();
            return true;
        }

        public void SacarExcepcion()
        {
            iTecnicosAplicacion!.Borrar(null);
        }
    }
}