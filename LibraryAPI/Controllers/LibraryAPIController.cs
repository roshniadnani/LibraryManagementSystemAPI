using System.Runtime.CompilerServices;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryAPIController : ControllerBase
    {

        private readonly MyDbContext context;
        public LibraryAPIController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var data = await context.Books.ToListAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooksByID(int id)

        {
            var Book = await context.Books.FindAsync(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book Book)
        {
            await context.Books.AddAsync(Book);
            await context.SaveChangesAsync();
            return Ok(Book);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Book>> UpgradeBook(int id, Book Book)
        { if (id  != Book.BookId)
            {  
                return BadRequest();
            }
            context.Entry(Book).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(Book);
        }
    }

    
}
