using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PitonProject.Models;
using Microsoft.EntityFrameworkCore;

namespace PitonProject.Controllers
{
    
    [Route("api/Tasks")]
    [Tags("Kemal Kaan Kirca Tasks")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _dbContext;

        public BrandController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetBrands()
        {
            if (_dbContext.Tasks == null)
            {
                return NotFound();
            }
            return await _dbContext.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetBrand(int id)
        {
            if (_dbContext.Tasks == null)
            {
                return NotFound();
            }

            var brand = await _dbContext.Tasks.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Task>> PostBrand(Tasks brand)
        {
            _dbContext.Tasks.Add(brand);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBrand), new { id = brand.TaskId}, brand);
        }

        [HttpPut]


        public async Task<IActionResult> PutBrand(int id, Tasks brand)
        {
            if (id != brand.TaskId)
            { 
                return BadRequest();
            }
            _dbContext.Entry(brand).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandAvailable(id))
                {
                    return NotFound();
                }
                else 
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool BrandAvailable(int id)
        { 
            return(_dbContext.Tasks?.Any(x => x.TaskId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (_dbContext.Tasks == null)
            { 
                return NotFound();
            
            }

            var brand = await _dbContext.Tasks.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _dbContext.Tasks.Remove(brand);
            await _dbContext.SaveChangesAsync();

            return Ok();

        }
    }

}
