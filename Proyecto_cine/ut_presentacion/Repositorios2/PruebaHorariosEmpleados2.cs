using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaHorariosEmpleados2
    {
        private readonly IHorariosEmpleadosAplicacion? iHorariosEmpleadosAplicacion;
        private List<HorariosEmpleados>? lista;
        private HorariosEmpleados? entidadHorariosEmpleados;
        private Conexion iConexion = new Conexion();

        public PruebaHorariosEmpleados2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iHorariosEmpleadosAplicacion = new HorariosEmpleadosAplicacion(iConexion);
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
            lista = iConexion!.HorariosEmpleados!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadHorariosEmpleados = EntidadesNucleo.HorariosEmpleados()!;
            iConexion!.HorariosEmpleados!.Add(entidadHorariosEmpleados);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadHorariosEmpleados!.Fecha =DateTime.Now;
            var entry = iConexion!.Entry(entidadHorariosEmpleados);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.HorariosEmpleados!.Remove(entidadHorariosEmpleados!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}