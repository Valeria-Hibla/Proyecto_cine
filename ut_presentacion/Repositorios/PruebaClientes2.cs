using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
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
            iClientesAplicacion = new CineAplicacion(iConexion);
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
            this.lista = this.iConexion!.Clientes!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadClientes = EntidadesNucleo.Clientes()!;
            this.iConexion!.Clientes!.Add(this.entidadClientes);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadClientes!.Nombre = "Test #2";
            var entry = this.iConexion!.Entry<Clientes>(this.entidadClientes);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Clientes!.Remove(this.entidadClientes!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}