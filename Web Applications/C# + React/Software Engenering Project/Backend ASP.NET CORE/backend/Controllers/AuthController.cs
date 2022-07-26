using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly backendContext _context;

        public AuthController(IAuthRepository authRepository, backendContext context)
        {
            _authRepo = authRepository;
            _context = context; 
        }

       
        // POST: api/Auth
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDto request )
        {          
           
            if (request.isAuthor || request.isReviewer)
            {
                ServiceResponse<int> response = await _authRepo.Register(
                new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EmailAddress = request.EmailAddress,
                    OrcId = request.OrcId,
                    isAuthor = request.isAuthor,
                    isReviewer = request.isReviewer,

                }, request.Password);

                if (!response.Success)
                {
                    return BadRequest(response);
                }

                User user = _context.Users.Where(x => x.EmailAddress == request.EmailAddress).FirstOrDefault();
                user.categoriesRange = await AddRangeCategoryReviewer(request.categoriesId, user.Id);
                 _context.Update(user);
                await _context.SaveChangesAsync();


                return Ok(response);
            }
            return BadRequest(new ServiceResponse<int>() { Data = 0, Message = "No user role was chosen", Success = false });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                request.EmailAddress, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

       private ICollection<CategoryReviewer> getUserCategories(ICollection<int>ids)
        {
            ICollection<CategoryReviewer> categories = new List<CategoryReviewer>();
            foreach (var item in ids)
            {
                categories.Add(_context.CategoryReviewers.Where(x => x.categoryId == item).FirstOrDefault());
            }
            return categories;

        }

        private async Task<ICollection<CategoryReviewer>> AddRangeCategoryReviewer(ICollection<int>categoryIds, int userId)
        {
            var categoryReviewerList = new List<CategoryReviewer>(); 
            foreach( int id in categoryIds)
            {
                var categoryReviewer = new CategoryReviewer { categoryId = id, userId = userId };
                categoryReviewerList.Add(categoryReviewer);
                _context.CategoryReviewers.Add(categoryReviewer);
             }

            return categoryReviewerList;
        }



    }
}
