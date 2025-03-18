using Repository.Entities;

namespace Service.Interfaces
{
    public interface ICategoryProductService
    {
        Task<List<CategoriaProducto>> listCategoryProduct();
        Task<List<CategoriaProducto>> searchCategoryProduct(string search);
        Task<string> createCategoryProduct(CategoriaProducto categoriaProducto);
        Task<string> updateCategoryProduct(CategoriaProducto categoriaProducto);
    }
}
