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
using System.Security.Claims;
using System;
using System.Linq.Expressions;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ArticlesController : ControllerBase
    {
        private readonly backendContext _context;
        private readonly IMapper _mapper;

        public ArticlesController(backendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Articles
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetArticleDtoResponse>>> GetArticle ([FromQuery] GetArticleDtoRequest request)
        {
            var predicate = CreatePredicate(request);

            List<Article> articles = await _context.Articles
                .Include(article => article.Category)
                .Include(article => article.ArticleFile)
                .Include(article => article.Author)
                .Where(predicate)
                .ToListAsync();

            return _mapper.Map<List<GetArticleDtoResponse>>(articles);

        }
        // GET: api/Articles/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetArticleDtoResponse>> GetArticle(int id)
        {
            var article = await _context.Articles
                .Where(article => article.Id == id)
                .Include(article => article.Category)
                .Include(article => article.ArticleFile)
                .Select(article => _mapper.Map<GetArticleDtoResponse>(article))
                .SingleOrDefaultAsync();

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        [HttpGet("preview")]
        public async Task<ActionResult<IEnumerable<GetArticleDtoResponse>>> GetArticlePreview()
        {
            var rand = new Random();
            var lenght = 10;

            ClaimsIdentity name = this.HttpContext.User.Identities.FirstOrDefault();
            string userName = name.Name;
            User author = await _context.Users.Include(x => x.categoriesRange).Where(x => x.EmailAddress == userName).FirstOrDefaultAsync();
            List<Article> articleList = new List<Article>();
            HashSet<GetArticleDtoResponse> assignedToReviewer = new HashSet<GetArticleDtoResponse>(); 

            foreach (var i in author.categoriesRange)
            {
                var article = await _context.Articles
                    .Include(article => article.ArticleFile)                    
                    .Include(article => article.Author)
                    .Include(article => article.Category)
                    .Where(article => article.CategoryId == i.categoryId)
                    .Where(article=>article.Author!=author)
                    .Where(article=> article.Status.Equals(ArticleStatus.SentToReview))
                    .ToListAsync();

                articleList.AddRange(article);

            }
            if (articleList == null)
            {
                return NotFound();
            }
            if(articleList.Count<10)
            {
                lenght = articleList.Count;    
            }
            while(assignedToReviewer.Count!=lenght)
            {
                var itemId  = rand.Next(articleList.Count);
                assignedToReviewer.Add(_mapper.Map<GetArticleDtoResponse>(articleList.ElementAt(itemId)));
            }

            return assignedToReviewer;            
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int id, PutArticleDto putArticle)
        {
            var validator = new PutArticleValidator(_context);
            await validator.ValidateAndThrowAsync(putArticle);

            var article = await _context.Articles.FindAsync(id);

            if (article == null) return BadRequest("Article doesn't exist.");

            _context.Entry(_mapper.Map(putArticle, article)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Articles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GetArticleDtoResponse>> PostArticle(PostArticleDto postArticle)
        {
            var validator = new ArticleValidator(_context);
            await validator.ValidateAndThrowAsync(postArticle);

            var article = _mapper.Map<Article>(postArticle);

            ClaimsIdentity name = this.HttpContext.User.Identities.FirstOrDefault();
            string userName = name.Name;
            User author = _context.Users.FirstOrDefault(x => x.EmailAddress == userName);
            article.Author = author;

            article.Category = await _context.Categories.FindAsync(article.CategoryId);

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.Id }, _mapper.Map<GetArticleDtoResponse>(article));
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetArticleDtoResponse>> DeleteArticle(int id)
        {
            var article = await _context.Articles
                .Where(article => article.Id == id)
                .Include(article => article.Category)
                .SingleOrDefaultAsync();
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetArticleDtoResponse>(article);
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        private Expression<Func<Article, bool>> CreatePredicate(GetArticleDtoRequest request)
        {
            Expression<Func<Article, bool>> predicate = r =>
             (request.AuthorId == 0 || r.AuthorId == request.AuthorId) &&
             (request.CategoryId == 0 || r.CategoryId == request.CategoryId) &&
             (String.IsNullOrEmpty(request.Title) || r.Title.ToUpper().Contains(request.Title.ToUpper())) &&
             (request.Status == null || r.Status == request.Status);

             return predicate;

        }               
    }
}
