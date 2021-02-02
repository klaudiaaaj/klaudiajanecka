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
    public class GroupsController : Controller
    {
        public readonly mydbContext _context;

        public GroupsController(mydbContext context)
        {
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {

            var name = _context.Dancers.ToList();
            ViewBag.Dancer = name;
            return View(await _context.Groups.ToListAsync());
        }

        public async Task<IActionResult> IndexFindName(int? id)
        {
            var name = _context.Dancers.Where(d => d.DancerId == id).FirstOrDefault();
            ViewData["Supervisor_name"] = name;

            return View();
        }


        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FirstOrDefaultAsync(m => m.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        private object Dancestyle(Group arg)
        {
            throw new NotImplementedException();
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["DancestyleId"] = new SelectList(_context.DanceStyles, "DancestyleId", "DancestyleName");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,SupervisorId,GroupName,DancestyleId")] Group @group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DancestyleId"] = new SelectList(_context.DanceStyles, "DancestyleId", "DancestyleName", @group.DancestyleId);
            return View(@group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["DancestyleId"] = new SelectList(_context.DanceStyles, "DancestyleId", "DancestyleName", @group.DancestyleId);
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,SupervisorId,GroupName,DancestyleId")] Group @group)
        {
            if (id != @group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.GroupId))
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
            ViewData["DancestyleId"] = new SelectList(_context.DanceStyles, "DancestyleId", "DancestyleName", @group.DancestyleId);
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FirstOrDefaultAsync(m => m.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }

        public IActionResult Display(int? id)
        {

            var Dance = _context.GroupHasDancers.Where(group => group.GroupGroupId == id).ToList();
            List<Dancer> dancersl = new List<Dancer>();
            var gr = _context.Groups.Where(g => g.GroupId == id).First();
            foreach (var item in Dance)
            {
                var dancersc = _context.Dancers.Where(d => d.DancerId == item.DancerDancerId).Where(d=> d.DancerId != gr.SupervisorId).    First();
                dancersl.Add(dancersc);

            }
            var supervisor = _context.Dancers.Where(ss => ss.DancerId == gr.SupervisorId).First();
                var st = _context.DanceStyles.Where(s => s.DancestyleId == gr.DancestyleId).First(); 
            var tup = Tuple.Create(dancersl, gr,st, supervisor);
            return View(tup);

        }
    }
}

