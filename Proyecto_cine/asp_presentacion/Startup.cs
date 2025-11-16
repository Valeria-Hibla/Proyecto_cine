using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }
        
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones
            services.AddScoped<IBoletosPresentacion, BoletosPresentacion>();
            services.AddScoped<IClasificacionesPresentacion, ClasificacionesPresentacion>();
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<IClientesProductosPresentacion, ClientesProductosPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<IEquiposPresentacion, EquiposPresentacion>();
            services.AddScoped<IHorariosEmpleadosPresentacion, HorariosEmpleadosPresentacion>();
            services.AddScoped<IHorariosFuncionesPresentacion, HorariosFuncionesPresentacion>();
            services.AddScoped<IMembresiasPresentacion, MembresiasPresentacion>();
            services.AddScoped<IPeliculasPresentacion, PeliculasPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
            services.AddScoped<ISalasPresentacion, SalasPresentacion>();
            services.AddScoped<ISucursalesPresentacion, SucursalesPresentacion>();
            services.AddScoped<ITecnicosPresentacion, TecnicosPresentacion>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}