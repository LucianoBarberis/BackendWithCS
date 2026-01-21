using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaAPI1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        [HttpGet]
        public string Get([FromHeader] string Host) 
        {
            Console.WriteLine(Host);
            return "Este texto vino del backend con C#";
        }
    }
}
