using Microsoft.Extensions.DependencyInjection;
using Service.Implementation;
using Service.Interfaces;

namespace Service
{
    public static class DependencyInjection
    {
        //metodo para cargar los servicios de la capa Service
        //tienen que ser llamados en la capa de presentacion UI en program.cs
        public static void ServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IMarcaService, MarcaService>();
            services.AddTransient<ICategoryProductService, CategoryProductService>();
        }
    }
}
