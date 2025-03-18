
using Repository.Entities;

namespace Repository.Interfaces
{
    public interface ICategoryProductRepository
    {
        //se definen los metodos a usar
        //se encapsula en un Task<> para que se ejecute de manera asincrona.
        Task<List<CategoriaProducto>> listCategoryProduct();
        Task<List<CategoriaProducto>> searchCategoryProduct(string search);
        Task<string> createCategoryProduct(CategoriaProducto categoriaProducto);
        Task<string> updateCategoryProduct(CategoriaProducto categoriaProducto);
    }
}
