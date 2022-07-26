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
    public class UserInfoController : ControllerBase
    {
        private readonly backendContext _context;
        private readonly IMapper _mapper;

        public UserInfoController(backendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo()
        {
            ClaimsIdentity name = this.HttpContext.User.Identities.FirstOrDefault();
            string userName = name.Name;
            User user = await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress == userName);
            
            return _mapper.Map<UserInfoDto>(user);
        }
    }
}
