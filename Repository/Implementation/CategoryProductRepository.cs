using Microsoft.Data.SqlClient;
using Repository.DataBase;
using Repository.Entities;
using Repository.Interfaces;
using System.Data;

namespace Repository.Implementation
{
    //se heredan los metodos de la interfaz ICategoryProductRepository
    public class CategoryProductRepository:ICategoryProductRepository
    {
        private readonly Connection _connection; //se colaca readonly porque solo se extraeran valores, no se cambiaran valores de Connection

        //constructor | inyeccion de dependencias
        public CategoryProductRepository(Connection connection) //para usar CategoryProductRepository siempre se necesitara depender de una conexion
        {
            _connection = connection;
        }

        public async Task<string> createCategoryProduct(CategoriaProducto categoriaProducto)
        {
            string response = ""; //respuesta al metodo por defecto

            using (var connect = _connection.getConnection()) //la conexion solo se usara en la logica que este dentro de las llaves
            {
                connect.Open(); //apertura de la cadena de conexion de la BD

                var query = new SqlCommand(
                    @"IF EXIST (SELECT 1 FROM CATEGORIA_PRODUCTO WHERE NOMBRE = @NOMBRE)
                        BEGIN
                            SET @RESPUESTA = 'La categoria ya existe';
                            RETURN;
                        END
                        INSERT INTO CATEGORIA_PRODUCTO(NOMBRE,ID_USER,FECHA_CMA)
                        VALUES(@NOMBRE,@ID_USER,GETDATE());
                        
                        SET @RESPUESTA = 'Categoria creada exitosamente';",
                connect); //se le pasa como parametros al SqlCommand la query sql y la conexion

                query.Parameters.AddWithValue("@NOMBRE", categoriaProducto.NOMBRE); //valores a insertar
                query.Parameters.AddWithValue("@ID_USER", categoriaProducto.ID_USER); //valores a insertar
                query.Parameters.Add("@RESPUESTA", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output; //se declara @Respuesta como varchar y como paramentro de salida

                //try catch para manejar los errores del insert
                try
                {
                    await query.ExecuteNonQueryAsync();
                    response = Convert.ToString(query.Parameters["@RESPUESTA"].Value)!;
                }
                catch
                {
                    response = "Error(Repository): No se pudo procesar la consulta";
                }
            }
            return response;
        }

        public async Task<List<CategoriaProducto>> listCategoryProduct()
        {
            List<CategoriaProducto> listCategories = new List<CategoriaProducto>();

            using (var connect = _connection.getConnection()) //la conexion solo se usara en la logica que este dentro de las llaves
            {
                connect.Open(); //apertura de la cadena de conexion de la BD

                var query = new SqlCommand("SELECT ID_CATEGORIA, NOMBRE FROM CATEGORIA_PRODUCTO", connect); //se le pasa como parametros al SqlCommand la query sql y la conexion

                using (var data = await query.ExecuteReaderAsync()) //Lectura de la data de manera asincrona
                {
                    while (await data.ReadAsync())
                    {
                        listCategories.Add(new CategoriaProducto
                        {
                            ID_CATEGORIA = Convert.ToInt32(data["ID_MARCA"]),
                            NOMBRE = data["NOMBRE"].ToString()
                        });
                    }
                }
            }
            return listCategories;
        }

        public async Task<List<CategoriaProducto>> searchCategoryProduct(string search)
        {
            List<CategoriaProducto> listCategories = new List<CategoriaProducto>();

            using (var connect = _connection.getConnection())
            {
                connect.Open();

                var query = new SqlCommand("SELECT ID_CATEGORIA, NOMBRE FROM CATEGORIA_PRODUCTO WHERE NOMBRE LIKE '%'+@SEARCH +'%'", connect);
                query.Parameters.AddWithValue("@SEARCH", search); // se le pasa el parametro de busqueda @SEARCH

                using (var data = await query.ExecuteReaderAsync()) //Lectura de la data de manera asincrona
                {
                    while (await data.ReadAsync())
                    {
                        listCategories.Add(new CategoriaProducto
                        {
                            ID_CATEGORIA = Convert.ToInt32(data["ID_MARCA"]),
                            NOMBRE = data["NOMBRE"].ToString()
                        });
                    }
                }
            }
            return listCategories;
        }

        public async Task<string> updateCategoryProduct(CategoriaProducto categoriaProducto)
        {
            string response = ""; //respuesta al metodo por defecto

            using (var connect = _connection.getConnection()) //la conexion solo se usara en la logica que este dentro de las llaves
            {
                connect.Open(); //apertura de la cadena de conexion de la BD

                var query = new SqlCommand(
                    @"IF EXIST (SELECT 1 FROM CATEGORIA_PRODUCTO WHERE NOMBRE = @NOMBRE AND ID_CATEGORIA != @ID_CATEGORIA)
                        BEGIN
                            SET @RESPUESTA = 'La categoria ya existe';
                            RETURN;
                        END
                        UPDATE CATEGORIA_PRODUCTO
                        SET 
                            NOMBRE = @NOMBRE,
                            ID_USER = @ID_USER,
                            FECHA_CMA = GETDATE()
                        WHERE ID_CATEGORIA = @ID_CATEGORIA;

                        SET @RESPUESTA = 'Categoria creada exitosamente';",
                connect); //se le pasa como parametros al SqlCommand la query sql y la conexion

                query.Parameters.AddWithValue("@ID_CATEGORIA", categoriaProducto.ID_CATEGORIA); //valores a insertar
                query.Parameters.AddWithValue("@NOMBRE", categoriaProducto.NOMBRE); //valores a insertar
                query.Parameters.AddWithValue("@ID_USER", categoriaProducto.ID_USER); //valores a insertar
                query.Parameters.Add("@RESPUESTA", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output; //se declara @Respuesta como varchar y como paramentro de salida

                //try catch para manejar los errores del insert
                try
                {
                    await query.ExecuteNonQueryAsync();
                    response = Convert.ToString(query.Parameters["@RESPUESTA"].Value)!;
                }
                catch
                {
                    response = "Error(Repository): No se pudo procesar la consulta";
                }
            }
            return response;
        }
    }
}
