using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaBoletos2
    {
        private readonly IBoletosAplicacion? iBoletosAplicacion;
        private List<Boletos>? lista;
        private Boletos? entidadBoletos;
        private Conexion iConexion = new Conexion();

        public PruebaBoletos2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iBoletosAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Boletos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadBoletos = EntidadesNucleo.Boletos()!;
            this.iConexion!.Boletos!.Add(this.entidadBoletos);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadBoletos!.Asiento= "Test #2";
            var entry = this.iConexion!.Entry<Boletos>(this.entidadBoletos);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Boletos!.Remove(this.entidadBoletos!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
    
}