using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
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
            iEmpleadosAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Empleados!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadEmpleados = EntidadesNucleo.Empleados()!;
            this.iConexion!.Empleados!.Add(this.entidadEmpleados);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadEmpleados!.Nombre = "Test #2";
            var entry = this.iConexion!.Entry<Empleados>(this.entidadEmpleados);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Empleados!.Remove(this.entidadEmpleados!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}