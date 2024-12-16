


using System.ComponentModel;
using System.Data;
using api_dicsys.Controllers;
using MySql.Data.MySqlClient;

namespace api_dicsys.dao{

   public class ProductosDAO{

        private readonly ConexionDB _conexionDB;

        public ProductosDAO(ConexionDB conexionDB){
            
            _conexionDB= conexionDB;
        }
    
        public async Task<List< Producto > > Get()
        {

            try{

                List<Producto> lista = new List<Producto>();
            
                using (var conexion= await _conexionDB.getConexion() ){

                    var consulta= "SELECT p.id_producto as id_producto, p.nombre_producto as nombre_producto, p.precio as precio, p.stock as stock, p.fecha_alta as fecha_alta, c.id_categoria as id_categoria, c.nombre_categoria as categoria FROM productos p inner join categorias c on c.id_categoria = p.fk_categoria";

                    using (var solicitudDB = new MySqlCommand(consulta, conexion))
                    {
                        using (var respuesta = await solicitudDB.ExecuteReaderAsync())
                        {
                            while (await respuesta.ReadAsync())
                            {
                                // Dictionary<string, object> dic = new Dictionary<string, object>(); ;
                                
                                Producto producto = new Producto();
                                
                                //Obtengo el indice de la columna por su nombre y leo el valor
                                producto.id_producto=respuesta.GetInt32(respuesta.GetOrdinal("id_producto"));
                                producto.nombre_producto=respuesta.GetString(respuesta.GetOrdinal("nombre_producto"));
                                producto.precio=respuesta.GetDecimal(respuesta.GetOrdinal("precio"));
                                producto.stock=respuesta.GetInt32(respuesta.GetOrdinal("stock"));
                                producto.fecha_alta=respuesta.GetDateTime(respuesta.GetOrdinal("fecha_alta")).ToString("dd-MM-yyyy");
                                producto.fk_categoria=respuesta.GetInt32(respuesta.GetOrdinal("id_categoria"));
                                producto.categoria=respuesta.GetString(respuesta.GetOrdinal("categoria"));
                                
                                // dic.Add("nombre_producto", respuesta.GetString(respuesta.GetOrdinal("nombre_producto"))); 
                                // dic.Add("precio", respuesta.GetDecimal(respuesta.GetOrdinal("precio"))); 
                                // dic.Add("stock", respuesta.GetInt32(respuesta.GetOrdinal("stock"))); 
                                // dic.Add("fecha_alta", respuesta.GetDateTime(respuesta.GetOrdinal("fecha_alta")).ToString("dd-MM-yyyy") ); 
                                // dic.Add("categoria", respuesta.GetString(respuesta.GetOrdinal("categoria"))); 
                                
                                lista.Add(producto);
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

        }
    
    }


}
