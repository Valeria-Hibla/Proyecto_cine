using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias #2 de clasificaciones
    [TestClass]
    public class PruebaClasificaciones2
    {
        private readonly IClasificacionesAplicacion? iClasificacionesAplicacion;
        private List<Clasificaciones>? lista;
        private Clasificaciones? entidadClasificaciones;
        private Conexion iConexion = new Conexion();

        public PruebaClasificaciones2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iClasificacionesAplicacion = new ClasificacionesAplicacion(iConexion);
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
            lista = iConexion!.Clasificaciones!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadClasificaciones = EntidadesNucleo.Clasificaciones()!;
            iConexion!.Clasificaciones!.Add(entidadClasificaciones);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadClasificaciones!.Categoria= "Prueba" ;
            var entry = iConexion!.Entry(entidadClasificaciones);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Clasificaciones!.Remove(entidadClasificaciones!);
            iConexion!.SaveChanges();
            return true;
        }

        public void SacarExcepcion()
        {
            iClasificacionesAplicacion!.Borrar(null);
        }
    }
}