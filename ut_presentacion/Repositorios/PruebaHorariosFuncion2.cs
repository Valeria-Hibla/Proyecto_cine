using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaHorariosFuncion2
    {
        private readonly IHorariosFuncionAplicacion? iHorariosFuncionAplicacion;
        private List<HorariosFuncion>? lista;
        private HorariosFuncion? entidadHorariosFuncion;
        private Conexion iConexion = new Conexion();

        public PruebaHorariosFuncion2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iHorariosFuncionAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.HorariosFuncion!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadHorariosFuncion = EntidadesNucleo.HorariosFuncion()!;
            this.iConexion!.HorariosFuncion!.Add(this.entidadHorariosFuncion);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadHorariosFuncion!.Fecha=DateTime.Now;
            var entry = this.iConexion!.Entry<HorariosFuncion>(this.entidadHorariosFuncion);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.HorariosFuncion!.Remove(this.entidadHorariosFuncion!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}