using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System.IO;
using Microsoft.Net.Http.Headers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleFilesController : ControllerBase
    {
        private readonly backendContext _context;
        private readonly IMapper _mapper;

        public ArticleFilesController(backendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ArticleFiles
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetArticleFileDto>>> GetArticleFile()
        {
            return await _context.ArticleFile
                .Include(articleFile => articleFile.Article)
                .Include(articleFile => articleFile.Article.Category)
                .Select(articleFile => _mapper.Map<GetArticleFileDto>(articleFile))
                .ToListAsync();
        }

        // GET: api/ArticleFiles/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleFile(int id)
        {
            var articleFile = await _context.ArticleFile.FindAsync(id);

            if (articleFile == null)
            {
                return NotFound();
            }

            var memoryStream = new MemoryStream(articleFile.Data);  
            return File(memoryStream, "application/pdf", "Download.pdf");
        }

        // PUT: api/ArticleFiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleFile(int id, [FromForm]PutArticleFileDto putArticleFile)
        {
            if (!ArticleFileExists(id))
            {
                return BadRequest();
            }

            var articleFile = await _context.ArticleFile.FindAsync(id);

            using (var memoryStream = new MemoryStream())
            {
                await putArticleFile.File.CopyToAsync(memoryStream);

                if(memoryStream.Length < 2097152)
                {
                    articleFile.Data = memoryStream.ToArray();

                    _context.Entry(articleFile).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArticleFileExists(id))
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

                return BadRequest();
            }
        }

        // POST: api/ArticleFiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArticleFile>> PostArticleFile([FromForm]PostArticleFileDto postArticleFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await postArticleFile.File.CopyToAsync(memoryStream);

                if(memoryStream.Length < 2097152)
                {
                    var articleFile = new ArticleFile()
                    {
                        Data = memoryStream.ToArray(),
                        ArticleId = postArticleFile.ArticleId
                    };

                    _context.ArticleFile.Add(articleFile);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetArticleFile", new { id = articleFile.Id }, articleFile);
                }

                return BadRequest();
            }
        }

        // DELETE: api/ArticleFiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetArticleFileDto>> DeleteArticleFile(int id)
        {
            var articleFile = await _context.ArticleFile
                .Where(articleFile => articleFile.Id == id)
                .Include(articleFile => articleFile.Article)
                .Include(articleFile => articleFile.Article.Category)    
                .SingleOrDefaultAsync();
            if (articleFile == null)
            {
                return NotFound();
            }

            _context.ArticleFile.Remove(articleFile);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetArticleFileDto>(articleFile);
        }

        private bool ArticleFileExists(int id)
        {
            return _context.ArticleFile.Any(e => e.Id == id);
        }
    }
}
