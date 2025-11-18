using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion? IConexion = null;

        public ProductosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Productos? Borrar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProductos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Productos!.Remove(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Productos",
                Accion = "Borrar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Productos> Listar()
        {

            // FALTA LA LISTA DE CLIENTES_PRODUCTOS
            var lista = this.IConexion!.Productos!
                .Take(50).ToList();

            foreach (var elemento in lista)
            {
                // Proveedores
                elemento.Proveedores = this.IConexion!.Proveedores!
                    .Where(x => x.IdProducto == elemento.IdProductos)
                    .ToList();

                // ClientesProductos
                elemento.ClientesProductos = this.IConexion!.ClientesProductos!
                    .Where(x => x.IdProducto == elemento.IdProductos)
                    .ToList();

            }
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Productos",
                Accion = "Listar",
                Fecha = DateTime.Now
            });
            return lista;
        }

        public List<Productos> PorNombre(Productos? entidad)
        {
            var lista = this.IConexion!.Productos!
                            .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                            .Take(50)
                            .ToList();

            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Productos",
                Accion = "PorNombre",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return lista;
        }
        public Productos? Modificar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProductos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Productos",
                Accion = "Modificar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Productos? Guardar(Productos? entidad)//logica de negocio
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("lbNombreRequerido");

            if ((entidad.Precio) < 0)
                throw new Exception("lbPrecioInvalido");

            if (entidad.IdProductos != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Productos!.Add(entidad);
            this.IConexion!.Auditorias!.Add(new Auditorias()
            {
                Controlador = "Productos",
                Accion = "Guardar",
                Fecha = DateTime.Now
            });
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
