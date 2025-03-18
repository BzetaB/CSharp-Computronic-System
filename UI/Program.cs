using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Implementation;
using Repository.Interfaces;
using Service;
using Service.Implementation;
using Service.Interfaces;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build(); //Llamado al metodo de configuracion del host

            var formService = host.Services.GetRequiredService<Form1>();
            //Application.Run(new Form1());
            Application.Run(formService);
        }

        //Se tiene que instalar Microsoft.Extensions.Hosting en los paquetes NuGet
        static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            //context es la aplicacion y config la configuracion que se esta detallando abajo
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                //optional false = no puede ser opcional, se tiene que cargar si o si
                //reloadOnChange = que vuelva a cargarse cuando haya cambios
            })
            .ConfigureServices((context, services) => //configuracion del service | contexto = aplicacion | services = variable para los servicios
            {
                services.RepositoryDependencies(); //llamado de los servicios de la capa repository
                services.ServicesDependencies(); //llamado de los servicios de la capa service

                services.AddSingleton<Form1>();
            });
    }
}