using Mini_PET_Proekt.Models;
using Mini_PET_Proekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mini_PET_Proekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(AddBook), new { id = book.Id }, book);
        }
    }
}
