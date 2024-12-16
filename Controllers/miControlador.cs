
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_dicsys.Controllers
{
    [Route("probando/")] //[controller]
    [ApiController]
    public class miControlador : ControllerBase{


        [HttpGet("hola",Name = "hola")]
        public string Get(){
           return "hola facu";
        }
    }
}
