using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publishing_House.Model;
using Publishing_House.Model.DatabaseModels;
using Publishing_House.Services.Contracts;

namespace Publishing_House.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService) =>_bookService = bookService;
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book) =>
            _bookService.Create(book) ? Ok("Book has been created") : BadRequest("Book not created");
        
        [HttpPut]
        public IActionResult Put(Book book) =>
            _bookService.Update(book) ? Ok("Book has been updated") : BadRequest("Book not updated");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            _bookService.Delete(id) ? Ok("Book has been removed") : BadRequest("Book not deleted");
    }
}