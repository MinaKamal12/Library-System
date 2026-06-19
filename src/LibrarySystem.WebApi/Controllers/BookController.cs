using LibrarySystem.Domain.Dtos;
using LibrarySystem.Domain.Services;
using LibrarySystem.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookDto bookDto)
        {
            var addBook = await _bookService.AddAsync(bookDto);
            return Ok(addBook);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, BookDto bookDto)
        {
            var UpdateBook = await _bookService.UpdateAsync(id, bookDto);

            if (UpdateBook == null)
            {
                return NotFound();
            }
            return Ok(UpdateBook);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }


        // get add edit delete (controller , service , repository)
        //for user copy borrowing

    }
}
