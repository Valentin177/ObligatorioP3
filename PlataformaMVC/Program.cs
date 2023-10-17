using LogicaAccesoDatos;
using LogicaAplicacion;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace PlataformaMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioEspecies, RepositorioEspecies>();
            builder.Services.AddScoped<IRepositorioEcosistemas, RepositorioEcosistemas>();
            builder.Services.AddScoped<IRepositorioPaises, RepositorioPaises>();
            builder.Services.AddScoped<IRepositorioEstadosConservacion, RepositorioEstadosConservacion>();
            builder.Services.AddScoped<IRepositorioAmenazas, RepositorioAmenazas>();


            builder.Services.AddScoped<IAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ILoginUsuario, CULogin>();
            builder.Services.AddScoped<IBuscarPaises, CUBuscarPaises>();
            builder.Services.AddScoped<IBuscarEstadosConservacion, CUTraerEstados>();
            builder.Services.AddScoped<IBuscarAmenazas, CUTraerAmenzas>();
            builder.Services.AddScoped<ICrearEcosistema, CUAltaEcosistema>();
            builder.Services.AddScoped<IBuscarPais, CUBuscarPais>();
            builder.Services.AddScoped<IBuscarEstadoConservacion, CUBuscarEstadoC>();
            builder.Services.AddScoped<IListarEcosistemas, CUListarEcosistemas>();
            builder.Services.AddScoped<IBorrarEcosistema, CUBorrarEcosistema>();
            builder.Services.AddScoped<IBuscarEcosistemaPorId, CUBuscarEcoPorId>();
            builder.Services.AddScoped<ITraerEcosistemas, CUTraerEcosistemas>();
            builder.Services.AddScoped<IAltaEspecie, CUAltaEspecie>();




            ConfigurationBuilder confBuilder = new ConfigurationBuilder();

            confBuilder.AddJsonFile("appsettings.json", false, true);

            var config = confBuilder.Build();

            string conexion = config.GetConnectionString("MiConexion");
            builder.Services.AddDbContextPool<PlataformaContext>(options => options.UseSqlServer(conexion));

            

            DbContextOptionsBuilder<PlataformaContext> p = new DbContextOptionsBuilder<PlataformaContext>();
            p.UseSqlServer(conexion);
            var opciones = p.Options;
            PlataformaContext ctx = new PlataformaContext( opciones );
            RepositorioParametros repo = new RepositorioParametros(ctx);

            Descripcion.topeMaxDesc = int.Parse(repo.buscarValorPorNombre("MaxCharDesc"));
            Descripcion.topeMinDesc = int.Parse(repo.buscarValorPorNombre("MinCharDesc"));

            DescripcionEcosistema.topeMaxDesc = int.Parse(repo.buscarValorPorNombre("MaxCharDesc"));
            DescripcionEcosistema.topeMinDesc = int.Parse(repo.buscarValorPorNombre("MinCharDesc"));

            DescripcionEspecie.topeMaxDesc = int.Parse(repo.buscarValorPorNombre("MaxCharDesc"));
            DescripcionEspecie.topeMinDesc = int.Parse(repo.buscarValorPorNombre("MinCharDesc"));


            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Inicio}/{action=Login}/{id?}");

            app.Run();
        }
    }
}