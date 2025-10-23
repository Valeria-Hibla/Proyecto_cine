using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
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
            iBoletosAplicacion = new BoletosAplicacion(iConexion);
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
            lista = iConexion!.Boletos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadBoletos = EntidadesNucleo.Boletos()!;
            iConexion!.Boletos!.Add(entidadBoletos);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadBoletos!.Asiento= "Test #2";
            var entry = iConexion!.Entry(entidadBoletos);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Boletos!.Remove(entidadBoletos!);
            iConexion!.SaveChanges();
            return true;
        }
    }
    
}