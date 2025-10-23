using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
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
            iMembresiasAplicacion = new MembresiasAplicacion(iConexion);
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
            lista = iConexion!.Membresias!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadMembresias = EntidadesNucleo.Membresias()!;
            iConexion!.Membresias!.Add(entidadMembresias);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadMembresias!.Nombre = "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = iConexion!.Entry(entidadMembresias);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Membresias!.Remove(entidadMembresias!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}