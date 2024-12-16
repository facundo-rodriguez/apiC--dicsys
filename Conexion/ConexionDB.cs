

using MySql.Data.MySqlClient;
using System.Data;


namespace api_dicsys.Controllers{

    public class ConexionDB{

        private readonly IConfiguration? _configuration;

        //"Server=bp78ntdxq8ntghigikh3-mysql.services.clever-cloud.com;port=3306;Database=bp78ntdxq8ntghigikh3;User=uyihsxgqemg9zbgp;Password=aCXPpxOvdl52lZyE3r1h" //;
        private  string? _connectionString;

        public ConexionDB(IConfiguration configuration){
            
            //Obténgo la cadena de conexión desde appsettings.json
           //_connectionString = configuration.GetConnectionString("DefaultConnection");
            
            _configuration= configuration;
        }


        public async Task<MySqlConnection> getConexion(){

            try{  
                //Accedo a las variables de entorno directamente desde IConfiguration
                string? host = _configuration["DB_HOST"];
                string? dbName = _configuration["DB_NAME"];
                string? user = _configuration["DB_USER"];
                string? password = _configuration["DB_PASSWORD"];

                //cadena de conexión usando las variables de entorno
                _connectionString = $"Server={host};Database={dbName};User={user};Password={password}";

                var connection = new MySqlConnection(_connectionString);
                
                await connection.OpenAsync(); // Abre la conexión
                return connection; // Devuelve la conexión abierta
            }
            catch (MySqlException ex){
                // Manejo de errores de conexión
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
                throw new Exception(ex.Message); //Re-lanzar la excepción para manejarla en capas superiores si es necesario
            }

        }
    
    }


}