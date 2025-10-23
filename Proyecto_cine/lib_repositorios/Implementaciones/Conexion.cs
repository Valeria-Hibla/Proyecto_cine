using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Tecnicos>? Tecnicos{ get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Salas>? Salas { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Peliculas>? Peliculas { get; set; }
        public DbSet<Membresias>? Membresias { get; set; }
        public DbSet<HorariosFunciones>? HorariosFunciones { get; set; }
        public DbSet<HorariosEmpleados>? HorariosEmpleados { get; set; }
        public DbSet<Equipos>? Equipos { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<ClientesProductos>? ClientesProductos { get; set; }
        public DbSet<Clasificaciones>? Clasificaciones { get; set; }
        public DbSet<Boletos>? Boletos { get; set; }
    }
}
