using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
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
            iProveedoresAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Proveedores!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadProveedores = EntidadesNucleo.Proveedores()!;
            this.iConexion!.Proveedores!.Add(this.entidadProveedores);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadProveedores!.Cedula = 456738;
            var entry = this.iConexion!.Entry<Proveedores>(this.entidadProveedores);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Proveedores!.Remove(this.entidadProveedores!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}