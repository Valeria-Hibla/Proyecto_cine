using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaHorariosFunciones2
    {
        private readonly IHorariosFuncionesAplicacion? iHorariosFuncionesAplicacion;
        private List<HorariosFunciones>? lista;
        private HorariosFunciones? entidadHorariosFunciones;
        private Conexion iConexion = new Conexion();

        public PruebaHorariosFunciones2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iHorariosFuncionesAplicacion = new HorariosFuncionesAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
            Assert.ThrowsException<Exception>(() => SacarExcepcion());
        }
        public bool Listar()
        {
            lista = iConexion!.HorariosFunciones!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadHorariosFunciones = EntidadesNucleo.HorariosFunciones()!;
            iConexion!.HorariosFunciones!.Add(entidadHorariosFunciones);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadHorariosFunciones!.Fecha=DateTime.Now;
            var entry = iConexion!.Entry(entidadHorariosFunciones);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.HorariosFunciones!.Remove(entidadHorariosFunciones!);
            iConexion!.SaveChanges();
            return true;
        }

        public void SacarExcepcion()
        {
            iHorariosFuncionesAplicacion!.Borrar(null);
        }
    }
}