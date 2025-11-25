using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Tecnicos>? Tecnicos { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Salas>? Salas { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Peliculas>? Peliculas { get; set; }
        DbSet<Membresias>? Membresias { get; set; }
        DbSet<HorariosFunciones>? HorariosFunciones { get; set; }
        DbSet<HorariosEmpleados>? HorariosEmpleados { get; set; }
        DbSet<Equipos>? Equipos { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<ClientesProductos>? ClientesProductos { get; set; }
        DbSet<Clasificaciones>? Clasificaciones { get; set; }
        DbSet<Boletos>? Boletos { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Auditorias>? Auditorias{ get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Permisos>? Permisos { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
