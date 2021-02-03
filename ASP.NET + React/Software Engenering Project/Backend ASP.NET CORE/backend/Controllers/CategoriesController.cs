using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Validators;
using backend.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly backendContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(backendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categories
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetCategories()
        {
            return await _context.Categories
                .Select(category => _mapper.Map<GetCategoryDto>(category))
                .ToListAsync();
        }

        // GET: api/Categories/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetCategoryDto>(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, PtCategoryDto putCategory)
        {

            var validator = new CategoryValidator(_context);
            await validator.ValidateAndThrowAsync(putCategory);

            var category = await _context.Categories.FindAsync(id);

            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(_mapper.Map(putCategory, category)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GetCategoryDto>> PostCategory(PtCategoryDto postCategory)
        {
            var validator = new CategoryValidator(_context);
            await validator.ValidateAndThrowAsync(postCategory);

            var category = _mapper.Map<Category>(postCategory);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, _mapper.Map<GetCategoryDto>(category));
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetCategoryDto>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCategoryDto>(category);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
