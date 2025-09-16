using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    //Para hacer las pruebas unitarias de Tecnicos
    [TestClass]
    public class PruebaClienteProducto
    {
        private readonly IConexion? iConexion;
        private List<ClienteProducto>? lista;
        private ClienteProducto? entidadClienteProducto;

        public PruebaClienteProducto()
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
            this.lista = this.iConexion!.ClienteProducto!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidadClienteProducto = EntidadesNucleo.ClienteProducto()!;
            this.iConexion!.ClienteProducto!.Add(this.entidadClienteProducto);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidadClienteProducto!.Monto= 120.00m;
            var entry = this.iConexion!.Entry<ClienteProducto>(this.entidadClienteProducto);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.ClienteProducto!.Remove(this.entidadClienteProducto!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
