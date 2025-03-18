
using Repository.Entities;

namespace Repository.Interfaces
{
    public interface IMarcaRepository
    {
        //se definen los metodos a usar
        //se encapsula en un Task<> para que se ejecute de manera asincrona.
        Task<List<MarcaProducto>> listMarcaProducts();

    }
}
