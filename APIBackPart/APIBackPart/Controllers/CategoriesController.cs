using APIBackPart.DAL;
using APIBackPart.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace APIBackPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly BackPartContext _context;

        public CategoriesController(BackPartContext context)
        {
            _context = context;
        }
        public IActionResult Get()
        {
            return Ok(_context.Categories.Include(c => c.Products));
        }

        [HttpGet("{id}/{take}")]
        public async Task<IActionResult> Get(int id, int take)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound("Specified id not found");
            }

            return Ok(category.Products.Take(take));
        }
        //FromQuery
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Category is not valid");
            }

            if (_context.Categories.Any(c=>c.Name == category.Name))
            {
                return BadRequest("Category is duplicate");
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return Created($"api/categories/{category.Id}", category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound("Specified id not found");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok("Category successfully deleted");

        }
    }
}