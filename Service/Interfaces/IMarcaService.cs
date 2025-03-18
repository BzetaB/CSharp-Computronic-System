using Repository.Entities;

namespace Service.Interfaces
{
    public interface IMarcaService
    {
        Task<List<MarcaProducto>> listMarcaProducts();
    }
}
