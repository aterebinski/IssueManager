using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IssueManager.Data;
using IssueManager.Models;

namespace IssueManager.Controllers
{
    public class EntityGroupColorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntityGroupColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EntityGroupColors
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityGroupColor.ToListAsync());
        }

        // GET: EntityGroupColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityGroupColor = await _context.EntityGroupColor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityGroupColor == null)
            {
                return NotFound();
            }

            return View(entityGroupColor);
        }

        // GET: EntityGroupColors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityGroupColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HEX,Order")] EntityGroupColor entityGroupColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityGroupColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entityGroupColor);
        }

        // GET: EntityGroupColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityGroupColor = await _context.EntityGroupColor.FindAsync(id);
            if (entityGroupColor == null)
            {
                return NotFound();
            }
            return View(entityGroupColor);
        }

        // POST: EntityGroupColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HEX,Order")] EntityGroupColor entityGroupColor)
        {
            if (id != entityGroupColor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityGroupColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityGroupColorExists(entityGroupColor.Id))
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
            return View(entityGroupColor);
        }

        // GET: EntityGroupColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityGroupColor = await _context.EntityGroupColor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityGroupColor == null)
            {
                return NotFound();
            }

            return View(entityGroupColor);
        }

        // POST: EntityGroupColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityGroupColor = await _context.EntityGroupColor.FindAsync(id);
            _context.EntityGroupColor.Remove(entityGroupColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityGroupColorExists(int id)
        {
            return _context.EntityGroupColor.Any(e => e.Id == id);
        }
    }
}
