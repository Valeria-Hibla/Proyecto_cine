using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public class CineAplicacion: ITecnicosAplicacion, 
        ISucursalesAplicacion, ISalasAplicacion, IProveedoresAplicacion, 
        IProductosAplicacion, IPeliculasAplicacion, IMembresiasAplicacion,
        IHorariosFuncionAplicacion, IHorariosEmpleadosAplicacion,
        IEquiposAplicacion, IEmpleadosAplicacion, IClientesAplicacion,
        IClienteProductoAplicacion, IClasificacionesAplicacion, IBoletosAplicacion
    {
        public IConexion? IConexion = null;

        public CineAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }



        //Tecnicos
        public Tecnicos? Borrar(Tecnicos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdTecnicos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Tecnicos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Tecnicos? Guardar(Tecnicos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdTecnicos != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Tecnicos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Tecnicos> ListarTecnicos()
        {
            return this.IConexion!.Tecnicos!.Take(20).ToList();
        }
        public Tecnicos? Modificar(Tecnicos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdTecnicos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Tecnicos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Sucursales
        public Sucursales? Borrar(Sucursales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSucursal == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Sucursales!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Sucursales? Guardar(Sucursales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdSucursal != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Sucursales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Sucursales> ListarSucursales()
        {
            return this.IConexion!.Sucursales!.Take(20).ToList();
        }
        public Sucursales? Modificar(Sucursales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSucursal == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Sucursales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }




        //Salas
        public Salas? Borrar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSalas == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Salas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Salas? Guardar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdSalas != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Salas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Salas> ListarSalas()
        {
            return this.IConexion!.Salas!.Take(20).ToList();
        }
        public Salas? Modificar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdSalas == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Salas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Proveedores
        public Proveedores? Borrar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProveedores == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Proveedores!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Proveedores? Guardar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdProveedores != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Proveedores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Proveedores> ListarProveedores()
        {
            return this.IConexion!.Proveedores!.Take(20).ToList();
        }
        public Proveedores? Modificar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProveedores == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Productos
        public Productos? Borrar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProductos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Productos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Productos? Guardar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdProductos != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Productos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Productos> ListarProductos()
        {
            return this.IConexion!.Productos!.Take(20).ToList();
        }
        public Productos? Modificar(Productos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdProductos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Peliculas
        public Peliculas? Borrar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdPelicula== 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Peliculas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Peliculas? Guardar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdPelicula != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Peliculas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Peliculas> ListarPeliculas()
        {
            return this.IConexion!.Peliculas!.Take(20).ToList();
        }
        public Peliculas? Modificar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdPelicula == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Peliculas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }


        //Membresias
        public Membresias? Borrar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMembresias == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Membresias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Membresias? Guardar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdMembresias != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Membresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Membresias> ListarMembresias()
        {
            return this.IConexion!.Membresias!.Take(20).ToList();
        }
        public Membresias? Modificar(Membresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMembresias == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Membresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //HorariosFuncion
        public HorariosFuncion? Borrar(HorariosFuncion? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosFuncion == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.HorariosFuncion!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public HorariosFuncion? Guardar(HorariosFuncion? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdHorariosFuncion != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.HorariosFuncion!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<HorariosFuncion> ListarHorariosFuncion()
        {
            return this.IConexion!.HorariosFuncion!.Take(20).ToList();
        }
        public HorariosFuncion? Modificar(HorariosFuncion? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosFuncion == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<HorariosFuncion>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //HorariosEmpleados
        public HorariosEmpleados? Borrar(HorariosEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosEmpleados == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.HorariosEmpleados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public HorariosEmpleados? Guardar(HorariosEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdHorariosEmpleados != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.HorariosEmpleados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<HorariosEmpleados> ListarHorariosEmpleados()
        {
            return this.IConexion!.HorariosEmpleados!.Take(20).ToList();
        }
        public HorariosEmpleados? Modificar(HorariosEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorariosEmpleados == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<HorariosEmpleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Equipos
        public Equipos? Borrar(Equipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEquipos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Equipos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Equipos? Guardar(Equipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdEquipos != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Equipos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Equipos> ListarEquipos()
        {
            return this.IConexion!.Equipos!.Take(20).ToList();
        }
        public Equipos? Modificar(Equipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEquipos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Equipos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Empleados
        public Empleados? Borrar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEmpleados == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Empleados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados? Guardar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdEmpleados != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Empleados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Empleados> ListarEmpleados()
        {
            return this.IConexion!.Empleados!.Take(20).ToList();
        }
        public Empleados? Modificar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEmpleados == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Clientes
        public Clientes? Borrar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCliente== 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Clientes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdCliente != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Clientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Clientes> ListarClientes()
        {
            return this.IConexion!.Clientes!.Take(20).ToList();
        }
        public Clientes? Modificar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCliente == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //ClienteProducto
        public ClienteProducto? Borrar(ClienteProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClienteProducto == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.ClienteProducto!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ClienteProducto? Guardar(ClienteProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdClienteProducto != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.ClienteProducto!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClienteProducto> ListarClienteProducto()
        {
            return this.IConexion!.ClienteProducto!.Take(20).ToList();
        }
        public ClienteProducto? Modificar(ClienteProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClienteProducto == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<ClienteProducto>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



        //Clasificaciones
        public Clasificaciones? Borrar(Clasificaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClasificacion == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Clasificaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clasificaciones? Guardar(Clasificaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdClasificacion != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Clasificaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Clasificaciones> ListarClasificaciones()
        {
            return this.IConexion!.Clasificaciones!.Take(20).ToList();
        }
        public Clasificaciones? Modificar(Clasificaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClasificacion == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Clasificaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        

        //Boletos
        public Boletos? Borrar(Boletos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdBoletos == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Boletos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Boletos? Guardar(Boletos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdBoletos != 0)
                throw new Exception("lbYaSeGuardo");
            this.IConexion!.Boletos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Boletos> ListarBoletos()
        {
            return this.IConexion!.Boletos!.Take(20).ToList();
        }
        public Boletos? Modificar(Boletos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdBoletos == 0)
                throw new Exception("lbNoSeGuardo");
            var entry = this.IConexion!.Entry<Boletos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        
    }
}
    

