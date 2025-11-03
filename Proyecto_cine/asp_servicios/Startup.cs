//using asp_servicios.Controllers;
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
            //services.AddSwaggerGen();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            //services.AddScoped<CineAplicacion, CineAplicacion>();
            services.AddScoped<SalasAplicacion, SalasAplicacion>();
            services.AddScoped<SucursalesAplicacion, SucursalesAplicacion>();
            services.AddScoped<TecnicosAplicacion, TecnicosAplicacion>();
            services.AddScoped<ProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<ProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<PeliculasAplicacion, PeliculasAplicacion>();
            services.AddScoped<MembresiasAplicacion, MembresiasAplicacion>();
            services.AddScoped<HorariosFuncionesAplicacion, HorariosFuncionesAplicacion>();
            services.AddScoped<HorariosEmpleadosAplicacion, HorariosEmpleadosAplicacion>();
            services.AddScoped<EquiposAplicacion, EquiposAplicacion>();
            services.AddScoped<EmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<ClientesProductosAplicacion, ClientesProductosAplicacion>();
            services.AddScoped<ClientesAplicacion, ClientesAplicacion>();
            services.AddScoped<ClasificacionesAplicacion, ClasificacionesAplicacion>();
            services.AddScoped<BoletosAplicacion, BoletosAplicacion>();
            // Controladores
            //services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}
