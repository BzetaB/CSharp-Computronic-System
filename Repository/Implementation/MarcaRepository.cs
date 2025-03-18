using Microsoft.Data.SqlClient;
using Repository.DataBase;
using Repository.Entities;
using Repository.Interfaces;

namespace Repository.Implementation
{
    //se heredan los metodos de IMarcaInterface
    public class MarcaRepository : IMarcaRepository
    {
        private readonly Connection _connection; //se colaca readonly porque solo se extraeran valores, no se cambiaran valores de Connection

        //constructor | inyeccion de dependencias
        public MarcaRepository(Connection connection) //para usar MarcaRepository siempre se necesitara depender de una conexion
        {
            _connection = connection;
        }

        public async Task<List<MarcaProducto>> listMarcaProducts()
        {
            List<MarcaProducto> listMarca = new List<MarcaProducto>();

            using(var connect = _connection.getConnection()) //la conexion solo se usara en la logica que este dentro de las llaves
            {
                connect.Open(); //apertura de la cadena de conexion de la BD

                var query = new SqlCommand("SELECT ID_MARCA, NOMBRE FROM MARCA_PRODUCTO", connect); //se le pasa como parametros al SqlCommand la query sql y la conexion
                
                using(var data = await query.ExecuteReaderAsync()) //Lectura de la data de manera asincrona
                {
                    while(await data.ReadAsync())
                    {
                        listMarca.Add(new MarcaProducto
                        {
                            ID_MARCA = Convert.ToInt32(data["ID_MARCA"]),
                            NOMBRE = data["NOMBRE"].ToString()
                        });
                    }
                }
            }
            return listMarca;
        }
    }
}
