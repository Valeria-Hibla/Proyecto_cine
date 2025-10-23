using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaClientes2
    {
        private readonly IClientesAplicacion? iClientesAplicacion;
        private List<Clientes>? lista;
        private Clientes? entidadClientes;
        private Conexion iConexion = new Conexion();

        public PruebaClientes2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iClientesAplicacion = new ClientesAplicacion(iConexion);
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
            lista = iConexion!.Clientes!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadClientes = EntidadesNucleo.Clientes()!;
            iConexion!.Clientes!.Add(entidadClientes);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadClientes!.Nombre = "Prueba unitaria #2 -" + DateTime.Now.ToString("yyyy-MM-dd");
            var entry = iConexion!.Entry(entidadClientes);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Clientes!.Remove(entidadClientes!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}