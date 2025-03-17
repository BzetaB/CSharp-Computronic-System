using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
            Application.Run(new Form1());
        }

        //Se tiene que instalar Microsoft.Extensions.Hosting en los paquetes NuGet
        static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            //context es la aplicacion y config la configuracion que se esta detallando abajo
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                //optional false = no puede ser opcional, se tiene que cargar si o si
                //reloadOnChange = que vuelva a cargarse cuando haya cambios
            });
    }
}