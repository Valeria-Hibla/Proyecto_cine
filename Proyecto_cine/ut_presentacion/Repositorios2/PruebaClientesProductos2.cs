using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios2
{
    //Para hacer las pruebas unitarias
    [TestClass]
    public class PruebaClientesProductos2
    {
        private readonly IClientesProductosAplicacion? iClientesProductosAplicacion;
        private List<ClientesProductos>? lista;
        private ClientesProductos? entidadClientesProductos;
        private Conexion iConexion = new Conexion();

        public PruebaClientesProductos2()
        {
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iClientesProductosAplicacion = new ClientesProductosAplicacion(iConexion);
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
            lista = iConexion!.ClientesProductos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidadClientesProductos = EntidadesNucleo.ClientesProductos()!;
            iConexion!.ClientesProductos!.Add(entidadClientesProductos);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidadClientesProductos!.Monto = 89.99m;
            var entry = iConexion!.Entry(entidadClientesProductos);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.ClientesProductos!.Remove(entidadClientesProductos!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}