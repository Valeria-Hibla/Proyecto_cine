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
            entidadTecnicos.Nombre = "Pruebas Tecnicos -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadTecnicos.Cedula= 000000;
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
            entidadProveedores.Cedula = 000000;
            entidadProveedores.IdProductos = 9;
            return entidadProveedores;
        }
        public static Clasificaciones? Clasificaciones()
        {
            var entidadClasificacion = new Clasificaciones();
            entidadClasificacion.Categoria = "Pruebas Cl";
            entidadClasificacion.EdadMinima = 0;
            entidadClasificacion.Descripcion = "Programacion de Software";
            return entidadClasificacion;
        }

        public static Peliculas? Peliculas()
        {
            var entidadPeliculas = new Peliculas();
            entidadPeliculas.Titulo = "Pruebas Peliculas -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadPeliculas.Duracion = new TimeSpan(2,30,00);
            entidadPeliculas.Genero = "Programacion de Software";
            entidadPeliculas.IdClasificacion = 1;
            return entidadPeliculas;
        }
        public static Clientes? Clientes()
        {
            var entidadClientes = new Clientes();
            entidadClientes.Cedula = 000000;
            entidadClientes.Nombre = "Pruebas Clientes -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadClientes.Edad = 24;
            return entidadClientes;
        }
        public static Membresias? Membresias()
        {

            var entidadMembresias = new Membresias();
            entidadMembresias.Nombre = "Pruebas Membresias -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadMembresias.FechaInicio =DateTime.Now;
            entidadMembresias.IdCliente = 1;
            return entidadMembresias;
        }
        public static HorariosFuncion? HorariosFuncion()
        {

            var entidadHorariosFuncion = new HorariosFuncion();
            entidadHorariosFuncion.Fecha =DateTime.Now;
            entidadHorariosFuncion.IdSalas = 1;
            entidadHorariosFuncion.IdPelicula = 5;
            return entidadHorariosFuncion;
        }
        public static Empleados? Empleados()
        {
            var entidadEmpleados = new Empleados();
            entidadEmpleados.Cedula = 000000;
            entidadEmpleados.Nombre = "Pruebas Empleados -" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidadEmpleados.FechaContratacion = DateTime.Now;
            entidadEmpleados.IdSucursal = 9;
            return entidadEmpleados;
        }
        public static HorariosEmpleados? HorariosEmpleados()
        {
;            var entidadHorariosEmpleados = new HorariosEmpleados();
            entidadHorariosEmpleados.Fecha = DateTime.Now;
            entidadHorariosEmpleados.HoraInicio = TimeOnly.MinValue;
            entidadHorariosEmpleados.HoraFin = TimeOnly.MaxValue;
            entidadHorariosEmpleados.IdEmpleados = 8;
            return entidadHorariosEmpleados;
        }

        public static ClienteProducto? ClienteProducto()
        {
            var entidadClienteProducto = new ClienteProducto();
            entidadClienteProducto.FechaCompra= DateTime.Now;
            entidadClienteProducto.Monto = 500.00m;
            entidadClienteProducto.IdProductos = 4;
            entidadClienteProducto.IdCliente = 3;
            return entidadClienteProducto;
        }

        public static Boletos? Boletos()
        {
            var entidadBoletos = new Boletos();
            entidadBoletos.Asiento = "Test";
            entidadBoletos.Precio = 200.00m;
            entidadBoletos.IdCliente = 3;
            entidadBoletos.IdSalas = 5;
            return entidadBoletos;
        }
    }
    }

