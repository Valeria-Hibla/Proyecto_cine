using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaProductos2
    {
        private readonly IProductosAplicacion? iProductosAplicacion;
        private List<Productos>? lista;
        private Productos? entidadProductos;
        private Conexion iConexion = new Conexion();

        public PruebaProductos2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iProductosAplicacion = new ProductosAplicacion(iConexion);
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
            lista = iConexion!.Productos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadProductos = EntidadesNucleo.Productos()!;
            iConexion!.Productos!.Add(entidadProductos);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadProductos!.Nombre = "Test";
            var entry = iConexion!.Entry(entidadProductos);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Productos!.Remove(entidadProductos!);
            iConexion!.SaveChanges();
            return true;
        }
        public void SacarExcepcion()
        {
            iProductosAplicacion!.Borrar(null);
        }
    }
}