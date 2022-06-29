using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IssueManager.Data;
using IssueManager.Models;
using Microsoft.AspNetCore.Identity;

namespace IssueManager.Controllers
{
    public class EntityGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EntityGroupsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;  
        }

        // GET: EntityGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityGroups.Where(i=>i.Del == false).Where(i=>i.HistoryNextId==0).OrderBy(i=>i.Name).ToListAsync());
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

            EntityGroupElementsViewModel entityGroupElementsVM = new EntityGroupElementsViewModel();
            entityGroupElementsVM.Name = entityGroup.Name;
            entityGroupElementsVM.Id = entityGroup.Id;

            var entities = _context.Entities.Where(i => i.Del == false).ToList();

            /*var query = from entity in _context.Entities
                        join entityGroupElement in _context.EntityGroupElements on entity.Id equals entityGroupElement.EntityId into entityGroupElements
                        from i in entityGroupElements.DefaultIfEmpty()
                        select new { entity,
                            GroupId = i.EntityGroupId
                        
                        };*/

            foreach (var item in entities)
            {
                entityGroupElementsVM.Entities.Add(item);
                EntityGroupElement entityGroupElement = await _context.EntityGroupElements.Where(i => i.Del == false).Where(i => i.EntityGroupId == entityGroup.Id).Where(i => i.EntityId == item.Id).FirstOrDefaultAsync();
                if (entityGroupElement != null)
                {
                    entityGroupElementsVM.IsChecked[item.Id] = true;
                }
                else
                {
                    entityGroupElementsVM.IsChecked[item.Id] = false;
                }
            }

            //return View(entityGroup);
            return View(entityGroupElementsVM);
        }

        // GET: EntityGroups/Create
        public IActionResult Create()
        {
            List<Entity> entities = _context.Entities.Where(i=>i.Del == false).ToList();
            EntityGroupElementsViewModel EntityGroupElementsVM = new EntityGroupElementsViewModel();
            EntityGroupElementsVM.Entities = entities;
            foreach (Entity item in EntityGroupElementsVM.Entities)
            {
                EntityGroupElementsVM.IsChecked[item.Id] = false;
            }


            //ViewBag.Entities = entities;   
            return View(EntityGroupElementsVM);
        }

        // POST: EntityGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Del")] EntityGroupElementsViewModel entityGroupElementsVM)
        public async Task<IActionResult> Create(EntityGroupElementsViewModel entityGroupElementsVM)
        {
            if (entityGroupElementsVM is null)
            {
                throw new ArgumentNullException(nameof(entityGroupElementsVM));
            }

            EntityGroup entityGroup = new EntityGroup();    

            if (ModelState.IsValid)
            {
                entityGroup.Del = false;
                entityGroup.CreateDateTime = DateTime.Now;
                entityGroup.CreateUserId = _userManager.GetUserId(HttpContext.User);
                entityGroup.Name = entityGroupElementsVM.Name;
                _context.Add(entityGroup);
                await _context.SaveChangesAsync();

                foreach (KeyValuePair<int, bool> item in entityGroupElementsVM.IsChecked)
                {
                    if (item.Value==true)
                    {

                        EntityGroupElement entityGroupElement = new EntityGroupElement();
                        entityGroupElement.CreateDateTime = DateTime.Now;
                        entityGroupElement.CreateUserId = _userManager.GetUserId(User);
                        entityGroupElement.EntityGroupId = entityGroup.Id;
                        entityGroupElement.EntityId = item.Key;
                        _context.Add(entityGroupElement);
                        await _context.SaveChangesAsync();
                    }
                    
                }





                //await _context.SaveChangesAsync();
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

            EntityGroupElementsViewModel entityGroupElementsVM = new EntityGroupElementsViewModel();
            entityGroupElementsVM.Name = entityGroup.Name;
            entityGroupElementsVM.Id = entityGroup.Id;

            List<Entity> Entities = _context.Entities.Where(e => e.Del == false).ToList();

            bool match;
            foreach (var item in Entities)
            {
                entityGroupElementsVM.Entities.Add(item);

                match = _context.EntityGroupElements.Where(i => i.EntityGroupId == entityGroup.Id).Where(i => i.EntityId == item.Id).Where(i => i.Del == false).Count() > 0;
                entityGroupElementsVM.IsChecked[item.Id] = match;
            }


            return View(entityGroupElementsVM);
        }

        // POST: EntityGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntityGroupElementsViewModel entityGroupElementsVM)
        {
            if (id != entityGroupElementsVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    EntityGroup entityGroup = _context.EntityGroups.SingleOrDefault(i => i.Id == id);
                    entityGroup.ModifyDateTime = DateTime.Now; 
                    entityGroup.ModifyUserId = _userManager.GetUserId(HttpContext.User);   
                    entityGroup.Name = entityGroupElementsVM.Name;
                    _context.Update(entityGroup);
                    await _context.SaveChangesAsync();

                    EntityGroupElement entityGroupElement;

                    var Entities = _context.Entities.Where(i => i.Del == false).ToList();

                    foreach (var item in Entities)
                    {
                        entityGroupElement = _context.EntityGroupElements.Where(i => i.EntityGroupId == entityGroup.Id).Where(i => i.EntityId == item.Id).SingleOrDefault();
                        if (entityGroupElement != null) //istnieje
                        {
                            entityGroupElement.ModifyDateTime = DateTime.Now;
                            entityGroupElement.ModifyUserId = _userManager.GetUserId(HttpContext.User);
                            entityGroupElement.Del = !entityGroupElementsVM.IsChecked[item.Id];
                            _context.Update(entityGroupElement);
                            _context.SaveChanges();
                        }
                        else
                        {
                            
                            if (entityGroupElementsVM.IsChecked[item.Id] == true)
                            {
                                entityGroupElement = new EntityGroupElement();
                                entityGroupElement.CreateDateTime = DateTime.Now;
                                entityGroupElement.CreateUserId = _userManager.GetUserId(HttpContext.User);
                                entityGroupElement.Del = false;
                                entityGroupElement.EntityGroupId = entityGroup.Id;
                                entityGroupElement.EntityId = item.Id;

                                _context.Update(entityGroupElement);
                                _context.SaveChanges();
                            }

                        }
                    }

                        
                        
                        
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityGroupExists(entityGroupElementsVM.Id))
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
            return View(entityGroupElementsVM);
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
            //_context.EntityGroups.Remove(entityGroup);
            entityGroup.Del = true;
            entityGroup.ModifyDateTime = DateTime.Now;
            entityGroup.ModifyUserId = _userManager.GetUserId(HttpContext.User);
            _context.Update(entityGroup);   
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityGroupExists(int id)
        {
            return _context.EntityGroups.Any(e => e.Id == id);
        }
    }
}
