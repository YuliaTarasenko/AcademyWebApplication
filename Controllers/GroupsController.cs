using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademyWebApplication.Data;
using AcademyWebApplication.Models;
using AcademyWebApplication.Data.Repositories;

namespace AcademyWebApplication.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupsRepository _repo;

        public GroupsController(IGroupsRepository repo)
        {
            _repo = repo;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetMany().ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _repo.GetAsync(m => m.Id == id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rating,Year")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(group);
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _repo.GetAsync(g=>g.Id == id);
            await _repo.UpdateAsync(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rating,Year")] Group group)
        {
            if (id != group.Id)
            {
                return NotFound($"Id is not equal with {nameof(Group)}.Id");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdateAsync(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await GroupExistsAsync(group.Id))
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
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _repo.GetAsync(m => m.Id == id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await _repo.GetAsync(g=>g.Id == id);
            if (group == null) return NotFound($"Record with id: {id} is not found");
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> GroupExistsAsync(int id)
        {
            return _repo.AnyAsync(e => e.Id == id);
        }
    }
}
