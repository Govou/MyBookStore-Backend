using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.Application.Author;

namespace MyBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
           _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _authorService.GetAllAuthors());
        }

        
    }
}
