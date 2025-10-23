using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaProveedores2
    {
        private readonly IProveedoresAplicacion? iProveedoresAplicacion;
        private List<Proveedores>? lista;
        private Proveedores? entidadProveedores;
        private Conexion iConexion = new Conexion();

        public PruebaProveedores2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iProveedoresAplicacion = new ProveedoresAplicacion(iConexion);
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
            lista = iConexion!.Proveedores!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadProveedores = EntidadesNucleo.Proveedores()!;
            iConexion!.Proveedores!.Add(entidadProveedores);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadProveedores!.Nombre= "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = iConexion!.Entry(entidadProveedores);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Proveedores!.Remove(entidadProveedores!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}