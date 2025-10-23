using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de HorariosFunciones
    [TestClass]
    public class PruebaHorariosFunciones
    {
        private readonly IConexion? iConexion;
        private List<HorariosFunciones>? lista;
        private HorariosFunciones? entidadHorariosFunciones;

        public PruebaHorariosFunciones()
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
            this.lista = this.iConexion!.HorariosFunciones!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadHorariosFunciones = EntidadesNucleo.HorariosFunciones()!;
            this.iConexion!.HorariosFunciones!.Add(this.entidadHorariosFunciones);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadHorariosFunciones!.Fecha= DateTime.Now;
            var entry = this.iConexion!.Entry<HorariosFunciones>(this.entidadHorariosFunciones);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.HorariosFunciones!.Remove(this.entidadHorariosFunciones!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
