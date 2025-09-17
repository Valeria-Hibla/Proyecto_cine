using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaTecnicos2
    {
        private readonly ITecnicosAplicacion? iTecnicosAplicacion;
        private List<Tecnicos>? lista;
        private Tecnicos? entidadTecnicos;
        private Conexion iConexion = new Conexion();

        public PruebaTecnicos2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iTecnicosAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Tecnicos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadTecnicos = EntidadesNucleo.Tecnicos()!;
            this.iConexion!.Tecnicos!.Add(this.entidadTecnicos);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadTecnicos!.Nombre = "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = this.iConexion!.Entry<Tecnicos>(this.entidadTecnicos);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Tecnicos!.Remove(this.entidadTecnicos!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}