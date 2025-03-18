using Microsoft.Extensions.DependencyInjection;
using Repository.DataBase;
using Repository.Implementation;
using Repository.Interfaces;

namespace Repository
{
    public static class DependencyInjection
    {
        //metodo para cargar los servicios de la capa repository
        //tienen que ser llamados en la capa de presentacion UI en program.cs
        public static void RepositoryDependencies(this IServiceCollection services)
        {
            services.AddSingleton<Connection>();
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<ICategoryProductRepository, CategoryProductRepository>();
        }
    }
}
