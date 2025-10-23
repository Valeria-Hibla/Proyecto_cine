using lib_dominio.Entidades;
namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Equipos? Equipos()
        {
            var entidadEquipos = new Equipos();
            entidadEquipos.Tipo = "Pruebas Equipos -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadEquipos.Marca = "Programacion de Software";
            entidadEquipos.Estado = false;
            entidadEquipos.IdSucursal = 3;
            return entidadEquipos;
        }
        public static Tecnicos? Tecnicos()
        {
            var entidadTecnicos = new Tecnicos();
            entidadTecnicos.Nombre = "Carlos Mendoza";
            entidadTecnicos.Cedula= "7735472";
            entidadTecnicos.Especialidad= "Programacion de Software";
            entidadTecnicos.IdEquipos = 6;
            return entidadTecnicos;
        }
        public static Sucursales? Sucursales()
        {
            var entidadSucursales = new Sucursales();
            entidadSucursales.Nombre = "Pruebas Sucursales -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadSucursales.Direccion = "Calle 5 #80-24";
            entidadSucursales.Ciudad = "Medellin";
            return entidadSucursales;
        }
        public static Salas? Salas()
        {
            var entidadSalas = new Salas();
            entidadSalas.NumeroSala = 102;
            entidadSalas.Capacidad = 80;
            entidadSalas.Estado = true;
            entidadSalas.IdSucursal = 4;
            return entidadSalas;
        }
        public static Productos? Productos()
        {
            var entidadProductos = new Productos();
            entidadProductos.Nombre = "Pruebas Productos";
            entidadProductos.Descripcion = "Programacion de Software";
            entidadProductos.Precio = 1500.00m;
            return entidadProductos;
        }
        public static Proveedores? Proveedores()
        {

            var entidadProveedores = new Proveedores();
            entidadProveedores.Nombre = "Pruebas Proveedores -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadProveedores.Cedula = "7735472";
            entidadProveedores.IdProducto = 1;
            return entidadProveedores;
        }
        public static Clasificaciones? Clasificaciones()
        {
            var entidadClasificacion = new Clasificaciones();
            entidadClasificacion.Categoria = "B15";
            entidadClasificacion.EdadMinima = 15;
            entidadClasificacion.Descripcion = "Para mayores de 15 años";
            return entidadClasificacion;
        }

        public static Peliculas? Peliculas()
        {
            var entidadPeliculas = new Peliculas();
            entidadPeliculas.Titulo = "Titanic";
            entidadPeliculas.Duracion = new TimeSpan(2,30,00);
            entidadPeliculas.Genero = "Romance";
            entidadPeliculas.IdClasificacion = 1;
            return entidadPeliculas;
        }
        public static Clientes? Clientes()
        {
            var entidadClientes = new Clientes();
            entidadClientes.Cedula = 9002939;
            entidadClientes.Nombre = "Valentina Tamayo";
            entidadClientes.Edad = 24;
            return entidadClientes;
        }
        public static Membresias? Membresias()
        {

            var entidadMembresias = new Membresias();
            entidadMembresias.Nombre = "Gold";
            entidadMembresias.FechaInicio =DateTime.Now;
            entidadMembresias.IdCliente = 1;
            return entidadMembresias;
        }
        public static HorariosFunciones? HorariosFunciones()
        {

            var entidadHorariosFunciones = new HorariosFunciones();
            entidadHorariosFunciones.Fecha =DateTime.Now;
            entidadHorariosFunciones.IdSala = 1;
            entidadHorariosFunciones.IdPelicula = 5;
            return entidadHorariosFunciones;
        }
        public static Empleados? Empleados()
        {
            var entidadEmpleados = new Empleados();
            entidadEmpleados.Cedula = "7735472";
            entidadEmpleados.Nombre = "Santiago Osorio";
            entidadEmpleados.FechaContratacion = DateTime.Now;
            entidadEmpleados.IdSucursal = 5;
            return entidadEmpleados;
        }
        public static HorariosEmpleados? HorariosEmpleados()
        {
;            var entidadHorariosEmpleados = new HorariosEmpleados();
            entidadHorariosEmpleados.Fecha = DateTime.Now;
            entidadHorariosEmpleados.HoraInicio = TimeOnly.FromDateTime(DateTime.Now);
            entidadHorariosEmpleados.HoraFin = TimeOnly.MaxValue;
            return entidadHorariosEmpleados;
        }

        public static ClientesProductos? ClientesProductos()
        {
            var entidadClientesProductos = new ClientesProductos();
            entidadClientesProductos.FechaCompra= DateTime.Now;
            entidadClientesProductos.Monto = 500.00m;
            entidadClientesProductos.IdProducto = 4;
            entidadClientesProductos.IdCliente = 3;
            return entidadClientesProductos;
        }

        public static Boletos? Boletos()
        {
            var entidadBoletos = new Boletos();
            entidadBoletos.Asiento = "32A";
            entidadBoletos.Precio = 200.00m;
            entidadBoletos.IdCliente = 1;
            entidadBoletos.IdSala = 1;
            return entidadBoletos;
        }
    }
    }

