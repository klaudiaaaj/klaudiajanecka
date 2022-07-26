using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdTokensController : ControllerBase
    {
        private readonly kjaneckaContext _context;

        public IdTokensController(kjaneckaContext context)
        {
            _context = context;
        }

        // GET: api/IdTokens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdToken>>> GetIdTokens()
        {
            return await _context.IdTokens.AsQueryable().ToListAsync();
        }

        // GET: api/IdTokens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdToken>> GetIdToken(int id)
        {
            var idToken = await _context.IdTokens.FindAsync(id);

            if (idToken == null)
            {
                return NotFound();
            }

            return idToken;
        }

        // PUT: api/IdTokens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdToken(int id, IdToken idToken)
        {
            if (id != idToken.TokenId)
            {
                return BadRequest();
            }

            _context.Entry(idToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdTokenExists(id))
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

        // POST: api/IdTokens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdToken>> PostIdToken(PostIdTokenDto idToken)
        {
           var newidtoken = new IdToken()
           {
               Exp = idToken.Exp,
               Iat = idToken.Iat,
               Nickname = idToken.Nickname,
               PlatformId = idToken.PlatformId,
               PlatformUserId = idToken.PlatformUserId,
               UserId = idToken.UserId
           };
            _context.IdTokens.Add(newidtoken);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdToken", new { userId = newidtoken.TokenId }, newidtoken);
        }

        // DELETE: api/IdTokens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdToken(int id)
        {
            var idToken = await _context.IdTokens.FindAsync(id);
            if (idToken == null)
            {
                return NotFound();
            }

            _context.IdTokens.Remove(idToken);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdTokenExists(int id)
        {
            return _context.IdTokens.Any(e => e.TokenId == id);
        }
    }
}
