using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class CategoryProductService:ICategoryProductService
    {
        private readonly ICategoryProductRepository _categoryProductRepository; //Se llama al repository

        //inyeccion de dependencias
        public CategoryProductService(ICategoryProductRepository categoryProductRepository)
        {
            _categoryProductRepository = categoryProductRepository;
        }

        public async Task<string> createCategoryProduct(CategoriaProducto categoriaProducto)
        {
            return await _categoryProductRepository.createCategoryProduct(categoriaProducto); //se llama al metodo del repository
        }

        public async Task<List<CategoriaProducto>> listCategoryProduct()
        {
            return await _categoryProductRepository.listCategoryProduct(); //se llama al metodo del repository
        }

        public async Task<List<CategoriaProducto>> searchCategoryProduct(string search)
        { 
            return await _categoryProductRepository.searchCategoryProduct(search); //se llama al metodo del repository
        }

        public async Task<string> updateCategoryProduct(CategoriaProducto categoriaProducto)
        {
            return await _categoryProductRepository.updateCategoryProduct(categoriaProducto); //se llama al metodo del repository
        }
    }
}
