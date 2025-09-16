using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias #2 de clasificaciones
    [TestClass]
    public class PruebaClasificacion2
    {
        private readonly IClasificacionesAplicacion? iClasificacionesAplicacion;
        private List<Clasificaciones>? lista;
        private Clasificaciones? entidadClasificaciones;
        private Conexion iConexion = new Conexion();

        public PruebaClasificacion2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iClasificacionesAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Clasificaciones!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadClasificaciones = EntidadesNucleo.Clasificaciones()!;
            this.iConexion!.Clasificaciones!.Add(this.entidadClasificaciones);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadClasificaciones!.Categoria= "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = this.iConexion!.Entry<Clasificaciones>(this.entidadClasificaciones);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Clasificaciones!.Remove(this.entidadClasificaciones!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}