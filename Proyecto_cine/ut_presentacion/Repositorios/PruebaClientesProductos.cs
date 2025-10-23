using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de Tecnicos
    [TestClass]
    public class PruebaClientesProductos
    {
        private readonly IConexion? iConexion;
        private List<ClientesProductos>? lista;
        private ClientesProductos? entidadClientesProductos;

        public PruebaClientesProductos()
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
            this.lista = this.iConexion!.ClientesProductos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadClientesProductos = EntidadesNucleo.ClientesProductos()!;
            this.iConexion!.ClientesProductos!.Add(this.entidadClientesProductos);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadClientesProductos!.Monto= 120.00m;
            var entry = this.iConexion!.Entry<ClientesProductos>(this.entidadClientesProductos);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.ClientesProductos!.Remove(this.entidadClientesProductos!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
