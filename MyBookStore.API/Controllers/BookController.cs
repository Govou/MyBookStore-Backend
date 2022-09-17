using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookStore.Application.Book;
using MyBookStore.Application.DTOs.Book;

namespace MyBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetAllBooks());
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _bookService.GetBookById(id));
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> Post(CreateBookDTO request)
        {
            return Ok(await _bookService.CreateBook(request));
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> Put(UpdateBookDTO request)
        {
            return Ok(await _bookService.UpdateBook(request));
        }

        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _bookService.DeleteBook(id));
        }
    }
}
