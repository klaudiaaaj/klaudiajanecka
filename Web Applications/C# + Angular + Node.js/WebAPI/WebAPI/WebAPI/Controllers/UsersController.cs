using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Extensions;
using WebAPI.Models;
using WebAPI.Interfaces;
using WebAPI.Dto;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public readonly kjaneckaContext _context;

        public UsersController(kjaneckaContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          return  await _context.Users.AsQueryable().ToListAsync();          
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("nick/{UserNickName}")]
        public async Task<ActionResult<User>> GetUserByNickname(string nick)
        {
            var user = await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.AppNickname == nick); 

            if (user == null)
            {
                return NotFound();
            }

            return user;

        }

        //GET: api/Users/discord
        [HttpGet("discord/{id}")]
        public async Task<ActionResult<bool>> ValidateUserDiscord(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (user.DiscordTokenId == null)
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        [HttpGet("github/{id}")]
        public async Task<ActionResult<bool>> ValidateUserGithub(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (user.GithubTokenId == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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


        // PUT: api/Users/5/10
        [HttpPut("platformTokenId/{id}/{platformId}/{tokenId}")]
        public async Task<IActionResult> UpdateUserToken(int id, int platformId, int tokenId)
        {
            try
            {
                var user = _context.Users.AsQueryable().Where(user => user.UserId == id).FirstOrDefault();                   
                if (platformId == 0)
                {
                    user.DiscordTokenId = tokenId;
                }
                if (platformId == 1)
                {
                    user.GithubTokenId = tokenId;
                }
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException )
                {
                    return NotFound();
                }
                if (ex is DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(PostUserDto user)
        {
            if (_context.Users.AsQueryable().Any(x => x.AppNickname == user.AppNickname))
            {
                return StatusCode(400, "Nickname is not free");
            }
            _context.Users.Add(new User { GithubTokenId = user.GithubTokenId, DiscordTokenId = user.DiscordTokenId, AppNickname = user.AppNickname, Password = user.Password });
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostUser", new { id = user.AppNickname }, user);
        }

        //Post: Api/Users/Nickname
        [HttpPost("Register/{AppNickname}")]
        public async Task<ActionResult<User>> CreateNewUserByNickname(string AppNickname)
        {
            if (_context.Users.AsQueryable().Any(x => x.AppNickname == AppNickname))
            {
                return StatusCode(400, "Nickname is not free");
            }

            var Password = await GetRequestBody.ReadRequestBodyAsync(this.HttpContext.Request);
            Password = JsonConvert.DeserializeObject<JObject>(Password)["password"].ToString();

            _context.Users.Add(new Models.User { AppNickname = AppNickname, Password = Password });
            await _context.SaveChangesAsync();

            var createdUser = _context.Users.AsQueryable().Where(user => user.AppNickname == AppNickname).FirstOrDefault();

            return CreatedAtAction("CreateNewUserByNickname", new { id = createdUser.UserId }, createdUser);
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

    }
}
