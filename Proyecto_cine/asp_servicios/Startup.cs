//using asp_servicios.Controllers;
using asp_servicios.Controllers;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection
       services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<ISalasAplicacion, SalasAplicacion>();
            services.AddScoped<ISucursalesAplicacion, SucursalesAplicacion>();
            services.AddScoped<ITecnicosAplicacion, TecnicosAplicacion>();
            services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<IPeliculasAplicacion, PeliculasAplicacion>();
            services.AddScoped<IMembresiasAplicacion, MembresiasAplicacion>();
            services.AddScoped<IHorariosFuncionesAplicacion, HorariosFuncionesAplicacion>();
            services.AddScoped<IHorariosEmpleadosAplicacion, HorariosEmpleadosAplicacion>();
            services.AddScoped<IEquiposAplicacion, EquiposAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<IClientesProductosAplicacion, ClientesProductosAplicacion>();
            services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
            services.AddScoped<IClasificacionesAplicacion, ClasificacionesAplicacion>();
            services.AddScoped<IBoletosAplicacion, BoletosAplicacion>();
            services.AddScoped<TokenAplicacion, TokenAplicacion>();

            // Controllers
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}
