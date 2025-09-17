using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de Tecnicos
    [TestClass]
    public class PruebaTecnicos
    {
        private readonly IConexion? iConexion;
        private List<Tecnicos>? lista;
        private Tecnicos? entidadTecnicos;

        public PruebaTecnicos()
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
            this.entidadTecnicos!.Especialidad = "Prueba unitaria #1 -" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
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
