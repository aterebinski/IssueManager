﻿using System;
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
    public class EntityGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntityGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EntityGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityGroups.ToListAsync());
        }

        // GET: EntityGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityGroup = await _context.EntityGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityGroup == null)
            {
                return NotFound();
            }

            return View(entityGroup);
        }

        // GET: EntityGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Del")] EntityGroup entityGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entityGroup);
        }

        // GET: EntityGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityGroup = await _context.EntityGroups.FindAsync(id);
            if (entityGroup == null)
            {
                return NotFound();
            }
            return View(entityGroup);
        }

        // POST: EntityGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Del")] EntityGroup entityGroup)
        {
            if (id != entityGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityGroupExists(entityGroup.Id))
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
            return View(entityGroup);
        }

        // GET: EntityGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityGroup = await _context.EntityGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityGroup == null)
            {
                return NotFound();
            }

            return View(entityGroup);
        }

        // POST: EntityGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityGroup = await _context.EntityGroups.FindAsync(id);
            _context.EntityGroups.Remove(entityGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityGroupExists(int id)
        {
            return _context.EntityGroups.Any(e => e.Id == id);
        }
    }
}