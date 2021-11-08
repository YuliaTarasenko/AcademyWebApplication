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
    public class TeachersController : Controller
    {
        private readonly ITeachersRepository _repo;

        public TeachersController(ITeachersRepository repo)
        {
            _repo = repo;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetMany().ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _repo.GetAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,EmploymentDate,Premium,Salary")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _repo.GetAsync(t=>t.Id==id);
            await _repo.UpdateAsync(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,EmploymentDate,Premium,Salary")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound($"Id is not equal with {nameof(Teacher)}.Id");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdateAsync(teacher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TeacherExistsAsync(teacher.Id))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _repo.GetAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _repo.GetAsync(t=>t.Id==id);
            if (teacher == null) return NotFound($"Record with id: {id} is not found");
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> TeacherExistsAsync(int id)
        {
            return _repo.AnyAsync(e => e.Id == id);
        }
    }
}
