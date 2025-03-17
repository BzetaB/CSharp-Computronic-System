
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Repository.DataBase
{
    public class Connection
    {
        private readonly IConfiguration _configuration; //se comunicara con appsettings.json
        private readonly string _stringSql; //variable de cadena de la conexion de sql

        //instanciando variables
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringSql = _configuration.GetConnectionString("StringConnectionSQL")!; //se pasa como parametro el nombre de la cadena de conexion del appjson
        }

        public SqlConnection getConnection()
        {
            //se crea una objeto SqlConnection que lee _stringsql que esta recibiendo la cadena de conexion del appsettings.json
            return new SqlConnection(_stringSql);
        }
    }
}
