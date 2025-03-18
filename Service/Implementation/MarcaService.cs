
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementation
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository; //Se llama al repository

        //inyeccion de dependencias
        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        public async Task<List<MarcaProducto>> listMarcaProducts()
        {
            return await _marcaRepository.listMarcaProducts(); //se llama al metodo del repository
        }
    }
}
