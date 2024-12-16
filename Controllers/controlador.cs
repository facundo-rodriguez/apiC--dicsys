using api_dicsys.dao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace api_dicsys.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Controlador : ControllerBase
    {

        private readonly ProductosDAO _productosDAO;

        public Controlador(ProductosDAO productosDAO){
           
            _productosDAO=productosDAO;
        }

        [HttpGet("productos", Name="controlador")]
        public async Task<IActionResult> Get()
        {
            try{

                var resultado = await _productosDAO.Get();
                return Ok(resultado);

            }catch(Exception ex){
                
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al recuperar los productos", error = ex.Message });
            }
          
        }

    }
}

