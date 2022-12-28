using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // GET api/books/
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {

            _context.Books.Add(book);
            
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetBook),new{ Id = book.Id},book);
        }
    }
}
