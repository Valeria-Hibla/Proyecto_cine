using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaMembresias2
    {
        private readonly IMembresiasAplicacion? iMembresiasAplicacion;
        private List<Membresias>? lista;
        private Membresias? entidadMembresias;
        private Conexion iConexion = new Conexion();

        public PruebaMembresias2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iMembresiasAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Membresias!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadMembresias = EntidadesNucleo.Membresias()!;
            this.iConexion!.Membresias!.Add(this.entidadMembresias);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadMembresias!.Nombre = "Test #2";
            var entry = this.iConexion!.Entry<Membresias>(this.entidadMembresias);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Membresias!.Remove(this.entidadMembresias!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}