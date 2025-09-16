using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de Salas
    [TestClass]
    public class PruebaSalas
    {
        private readonly IConexion? iConexion;
        private List<Salas>? lista;
        private Salas? entidadSalas;

        public PruebaSalas()
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
            this.entidadSalas!.Capacidad = 78;
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
