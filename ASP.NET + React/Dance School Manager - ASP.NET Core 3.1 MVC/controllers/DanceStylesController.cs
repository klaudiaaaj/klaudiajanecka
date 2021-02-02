using DanceSchool_10._05_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DanceSchool_10._05_ASP.NET_MVC.controllers
{
    public class DanceStylesController : Controller
    {
        private readonly mydbContext _context;

        public DanceStylesController(mydbContext context)
        {
            _context = context;
        }

        // GET: DanceStyles
        // GET: DanceStylese
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanceStyles.ToListAsync());
        }

        // GET: DanceStyles/Details/5
   

        // GET: DanceStyles/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("DancestyleId,DancestyleName")] DanceStyle danceStyle)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _context.Add(danceStyle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(danceStyle);

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes" + " Try again");
            }
            return View(danceStyle);
        }
        // GET: DanceStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceStyle = await _context.DanceStyles.FindAsync(id);
            if (danceStyle == null)
            {
                return NotFound();
            }
            return View(danceStyle);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DancestyleId,DancestyleName")] DanceStyle danceStyle)
        {
            if (id != danceStyle.DancestyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danceStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanceStyleExists(danceStyle.DancestyleId))
                        return NotFound();

                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(danceStyle);
        }

       
        // GET: DanceStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danceStyle = await _context.DanceStyles
                .FirstOrDefaultAsync(m => m.DancestyleId == id);
            if (danceStyle == null)
            {
                return NotFound();
            }

            return View(danceStyle);
        }

        // POST: DanceStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danceStyle = await _context.DanceStyles.FindAsync(id);
            _context.DanceStyles.Remove(danceStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanceStyleExists(int id)
        {
            return _context.DanceStyles.Any(e => e.DancestyleId == id);
        }
        public IActionResult Display(int? id)
        {
            var groups = _context.Groups.Where(d => d.DancestyleId == id).ToList();

            return View(groups);
        }
    }
}

    