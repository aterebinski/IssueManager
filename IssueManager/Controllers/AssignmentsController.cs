using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IssueManager.Data;
using IssueManager.Models;
using IssueManager.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IssueManager.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AssignmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Assignments.ToListAsync());
            return View(await _context.Assignments.Where<Assignment>(i => i.Del != true).ToListAsync());   
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public async Task<IActionResult> Create()
        {
            AssignmentsViewModel assignmentsVM = new AssignmentsViewModel();

            assignmentsVM.entities = _context.Entities.Where(i => i.Del == false).ToList();
            assignmentsVM.entityGroups = _context.EntityGroups.Where(i => i.Del == false).ToList();
            foreach (var item in assignmentsVM.entities)
            {
                assignmentsVM.EntityCheck[item.Id] = false;
            }

            return View(assignmentsVM);
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AssignmentsViewModel assignmentVM)
        {
            if (assignmentVM == null)
            {
                throw new ArgumentNullException(nameof(assignmentVM));
            }

            Assignment assignment = new Assignment();

            if (ModelState.IsValid)
            {
                assignment.Name = assignmentVM.assignment.Name;
                assignment.CreateDateTime = DateTime.Now;
                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                assignment.CreateUserId = _userManager.GetUserId(HttpContext.User);
                //                assignment.CreateUserId = int.Parse(_userManager.GetUserId(User));
                //assignment.CreateUserId = int.Parse(userId);
                assignment.Del = false;
                assignment.Status = (int)AssignmentStatus.ToPlan;
                _context.Add(assignment);
                await _context.SaveChangesAsync();


                foreach (KeyValuePair<int, bool> item in assignmentVM.EntityCheck)
                {
                    if (item.Value==true)
                    {
                        Console.WriteLine("====================================>Dodanie do tabeli JOBS");
                        Job job = new Job();
                        job.Status = JobStatus.Added;
                        job.CreateDateTime = DateTime.Now;
                        job.CreateUserId = _userManager.GetUserId(HttpContext.User);
                        job.Del = false;
                        job.AssignmentId = assignment.Id;
                        job.EntityId = item.Key;

                        

                        //TODO: nie działa dodawanie do tabeli jobs. Tabela JOBS pozostaj pusta

                        _context.Add(job);
                        await   _context.SaveChangesAsync();
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Text,Del,Status,CreateDateTime,CreateUserId,ModifyDateTime,ModifyUserId,HistoryPreviousId,HistoryNextId")] Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Id))
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
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
