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
    public class ReviewsController : ControllerBase
    {
        private readonly backendContext _context;
        private readonly IMapper _mapper;

        public ReviewsController(backendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetReviewDto>>> GetReview()
        {
            return await _context.Reviews
                .Select(review => _mapper.Map<GetReviewDto>(review))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetReviewDto>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetReviewDto>(review);
        }

        [HttpPost]
        public async Task<ActionResult<PtReviewDto>> PostReview(PtReviewDto postReview)
        {
            var review = _mapper.Map<Review>(postReview);

            ClaimsIdentity name = this.HttpContext.User.Identities.FirstOrDefault();
            string userName = name.Name;
            User reviewer = _context.Users.FirstOrDefault(x => x.EmailAddress == userName);
            if (!_context.ArticleReviewer.Where(ar => ar.ArticleId == review.ArticleId).Any(ar => ar.ReviewerId == reviewer.Id))
            {
                return StatusCode(403, "You are not assigned to article");
            }
            else if (_context.Reviews.Where(r => r.ReviewerId == reviewer.Id).Any())
            {
                return StatusCode(403, "You have already reviewed this article");
            }

            review.ReviewerId = reviewer.Id;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.Id }, _mapper.Map<GetReviewDto>(review));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, PtReviewDto putReview)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return BadRequest("Review doesn't exist.");
            }

            _context.Entry(_mapper.Map(putReview, review)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<GetReviewDto>> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetReviewDto>(review);
        }

        [HttpPost("Assign")]
        public async Task<ActionResult<GetArticleDtoResponse>> AssignReview(ArticleReviewerDto postAssignReviewer)
        {
            if (!ArticleExists(postAssignReviewer.ArticleId))
            {
                return NotFound();
            }


            var numberOfReviewers = await _context.ArticleReviewer
               .Where(articleReviewer => articleReviewer.ArticleId == postAssignReviewer.ArticleId)
               .CountAsync();

           

            if (numberOfReviewers >= 3)
            {
                return StatusCode(403,"Sufficient number of reviewers already assigned to article");
            }

            var articleReviewer = _mapper.Map<ArticleReviewer>(postAssignReviewer);


            ClaimsIdentity name = this.HttpContext.User.Identities.FirstOrDefault();
            string userName = name.Name;
            User reviewer = _context.Users.FirstOrDefault(x => x.EmailAddress == userName);
            if (!reviewer.isReviewer)
            {
                return Unauthorized("You are not a reviewer");
            }

            else if (_context.ArticleReviewer.Where(ar => ar.ArticleId == postAssignReviewer.ArticleId).Any(ar => ar.ReviewerId == reviewer.Id))
            {
                return StatusCode(403,"You are already assigned to this article");
            }

            articleReviewer.ReviewerId = reviewer.Id;

            _context.ArticleReviewer.Add(articleReviewer);
            await _context.SaveChangesAsync();

            if (numberOfReviewers+1 >= 3)
            {
                 var article = await _context.Articles
                    .Where(article => article.Id == articleReviewer.ArticleId)
                    .Include(article => article.Category)
                    .Include(article => article.ArticleFile)
                    .SingleOrDefaultAsync();
                article.Status = ArticleStatus.inReview;
                _context.Entry(article).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Ok(); 
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
