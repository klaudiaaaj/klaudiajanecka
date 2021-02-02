using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanceSchool_10._05_ASP.NET_MVC.Models;

namespace DanceSchool_10._05_ASP.NET_MVC.controllers
{
    public class DancersController : Controller
    {
        private readonly mydbContext _context;

        public DancersController(mydbContext context)
        {
            _context = context;
        }

        // GET: Dancers
        public async Task<IActionResult> Index()
        {
            var mydbContext = _context.Dancers.Include(d => d.Function).AsNoTracking(); // Returns a new query where the entities returned will not be cached in the DbContext or ObjectContext.


            return View(await mydbContext.ToListAsync());
        }

        // GET: Dancers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dancer = await _context.Dancers
                .Include(d => d.Function)
                .FirstOrDefaultAsync(m => m.DancerId == id);
            if (dancer == null)
            {
                return NotFound();
            }

            return View(dancer);
        }

        // GET: Dancers/Create
        public IActionResult Create()
        {
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionId");
            return View();
        }

        // POST: Dancers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DancerId,FunctionId,Name,Surname,Status")] Dancer dancer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dancer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionId", dancer.FunctionId);
            return View(dancer);
        }

        // GET: Dancers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dancer = await _context.Dancers.FindAsync(id);
            if (dancer == null)
            {
                return NotFound();
            }
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionId", dancer.FunctionId);
            return View(dancer);
        }

        // POST: Dancers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DancerId,FunctionId,Name,Surname,Status")] Dancer dancer)
        {
            if (id != dancer.DancerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dancer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DancerExists(dancer.DancerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunctionId"] = new SelectList(_context.Functions, "FunctionId", "FunctionId", dancer.FunctionId);
            return View(dancer);
        }

        // GET: Dancers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dancer = await _context.Dancers
                .Include(d => d.Function)
                .FirstOrDefaultAsync(m => m.DancerId == id);
            if (dancer == null)
            {
                return NotFound();
            }

            return View(dancer);
        }

        // POST: Dancers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dancer = await _context.Dancers.FindAsync(id);
            _context.Dancers.Remove(dancer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DancerExists(int id)
        {
            return _context.Dancers.Any(e => e.DancerId == id);
        }

        public async Task<IActionResult> Search(Dancer dancer, string searchString)
        {
            var s_dancer = from d  in _context.Dancers
                         select d;
      
            if (!String.IsNullOrEmpty(searchString))
            {
                s_dancer =s_dancer.Where(s => s.Name.Contains(searchString));
               
            }
                                                                             
            return View(await s_dancer.ToListAsync());
        }
    }
}
