using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    
    //Para hacer las pruebas unitarias de Boletos
    [TestClass]
    public class PruebaBoletos
    {
        private readonly IConexion? iConexion;
        private List<Boletos>? lista;
        private Boletos? entidadBoletos;

        public PruebaBoletos()
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
            this.entidadBoletos!.Asiento = "Test #1";
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
