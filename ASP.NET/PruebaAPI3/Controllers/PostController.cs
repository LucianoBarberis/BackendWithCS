using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI3.DTOs;
using PruebaAPI3.Services;
using System.Threading.Tasks;

namespace PruebaAPI3.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await _postService.GetAll());
        }

        [HttpPost]
        public IActionResult Validar(Post posteo) 
        {
            if(posteo.Title == null)
            {
                return BadRequest("titulo debe ser =! null");
            }
            if (!_postService.ValidarTitle(posteo.Title)) 
            {
                return BadRequest("Titulo muy largo");
            }
            return Ok(posteo);
        }
    }
}
