using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de HorariosEmpleados
    [TestClass]
    public class PruebaHorariosEmpleados
    {
        private readonly IConexion? iConexion;
        private List<HorariosEmpleados>? lista;
        private HorariosEmpleados? entidadHorariosEmpleados;

        public PruebaHorariosEmpleados()
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
            this.lista = this.iConexion!.HorariosEmpleados!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadHorariosEmpleados = EntidadesNucleo.HorariosEmpleados()!;
            this.iConexion!.HorariosEmpleados!.Add(this.entidadHorariosEmpleados);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadHorariosEmpleados!.IdEmpleados=1;
            var entry = this.iConexion!.Entry<HorariosEmpleados>(this.entidadHorariosEmpleados);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.HorariosEmpleados!.Remove(this.entidadHorariosEmpleados!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
