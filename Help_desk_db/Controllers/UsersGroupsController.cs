using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Help_desk_db;

namespace Help_desk_db.Controllers
{
    public class UsersGroupsController : Controller
    {
        private readonly ApplicationContext _context;

        public UsersGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: UsersGroups
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.UsersGroups.Include(u => u.Group).Include(u => u.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: UsersGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersGroup = await _context.UsersGroups
                .Include(u => u.Group)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersGroup == null)
            {
                return NotFound();
            }

            return View(usersGroup);
        }

        // GET: UsersGroups/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: UsersGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,GroupId")] UsersGroup usersGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", usersGroup.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", usersGroup.UserId);
            return View(usersGroup);
        }

        // GET: UsersGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersGroup = await _context.UsersGroups.FindAsync(id);
            if (usersGroup == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", usersGroup.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", usersGroup.UserId);
            return View(usersGroup);
        }

        // POST: UsersGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,GroupId")] UsersGroup usersGroup)
        {
            if (id != usersGroup.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersGroupExists(usersGroup.UserId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", usersGroup.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", usersGroup.UserId);
            return View(usersGroup);
        }

        // GET: UsersGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersGroup = await _context.UsersGroups
                .Include(u => u.Group)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usersGroup == null)
            {
                return NotFound();
            }

            return View(usersGroup);
        }

        // POST: UsersGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersGroup = await _context.UsersGroups.FindAsync(id);
            _context.UsersGroups.Remove(usersGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersGroupExists(int id)
        {
            return _context.UsersGroups.Any(e => e.UserId == id);
        }
    }
}
