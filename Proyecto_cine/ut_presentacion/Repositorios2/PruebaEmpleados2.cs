using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaEmpleados2
    {
        private readonly IEmpleadosAplicacion? iEmpleadosAplicacion;
        private List<Empleados>? lista;
        private Empleados? entidadEmpleados;
        private Conexion iConexion = new Conexion();

        public PruebaEmpleados2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iEmpleadosAplicacion = new EmpleadosAplicacion(iConexion);
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
            lista = iConexion!.Empleados!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadEmpleados = EntidadesNucleo.Empleados()!;
            iConexion!.Empleados!.Add(entidadEmpleados);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadEmpleados!.Nombre = "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = iConexion!.Entry(entidadEmpleados);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Empleados!.Remove(entidadEmpleados!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}