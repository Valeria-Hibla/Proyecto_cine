using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaSalas2
    {
        private readonly ISalasAplicacion? iSalasAplicacion;
        private List<Salas>? lista;
        private Salas? entidadSalas;
        private Conexion iConexion = new Conexion();

        public PruebaSalas2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iSalasAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Salas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadSalas = EntidadesNucleo.Salas()!;
            this.iConexion!.Salas!.Add(this.entidadSalas);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadSalas!.Capacidad = 43;
            var entry = this.iConexion!.Entry<Salas>(this.entidadSalas);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Salas!.Remove(this.entidadSalas!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}