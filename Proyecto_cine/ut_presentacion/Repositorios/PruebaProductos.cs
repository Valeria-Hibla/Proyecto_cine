using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de Productos
    [TestClass]
    public class PruebaProductos
    {
        private readonly IConexion? iConexion;
        private List<Productos>? lista;
        private Productos? entidadProductos;

        public PruebaProductos()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
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
            this.lista = this.iConexion!.Productos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadProductos = EntidadesNucleo.Productos()!;
            this.iConexion!.Productos!.Add(this.entidadProductos);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadProductos!.Nombre = "Test";
            var entry = this.iConexion!.Entry<Productos>(this.entidadProductos);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Productos!.Remove(this.entidadProductos!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
