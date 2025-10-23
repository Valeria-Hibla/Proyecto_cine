using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaSucursales2
    {
        private readonly ISucursalesAplicacion? iSucursalesAplicacion;
        private List<Sucursales>? lista;
        private Sucursales? entidadSucursales;
        private Conexion iConexion = new Conexion();

        public PruebaSucursales2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iSucursalesAplicacion = new SucursalesAplicacion(iConexion);
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
            lista = iConexion!.Sucursales!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadSucursales = EntidadesNucleo.Sucursales()!;
            iConexion!.Sucursales!.Add(entidadSucursales);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadSucursales!.Nombre= "Prueba unitaria #2 -"+DateTime.Now.ToString("yyyy-MM-dd");
            var entry = iConexion!.Entry(entidadSucursales);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Sucursales!.Remove(entidadSucursales!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}