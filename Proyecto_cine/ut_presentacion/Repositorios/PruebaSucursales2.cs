using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
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
            iSucursalesAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Sucursales!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadSucursales = EntidadesNucleo.Sucursales()!;
            this.iConexion!.Sucursales!.Add(this.entidadSucursales);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadSucursales!.Nombre= "Prueba unitaria #2 -"+DateTime.Now.ToString("yyyy-MM-dd");
            var entry = this.iConexion!.Entry<Sucursales>(this.entidadSucursales);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Sucursales!.Remove(this.entidadSucursales!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}