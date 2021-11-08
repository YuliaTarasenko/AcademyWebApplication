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
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsRepository _repo;

        public DepartmentsController(IDepartmentsRepository repo)
        {
            _repo = repo;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetMany().ToListAsync());
        }

        // GET: Department/Search
        public async Task<IActionResult> DepartmentsSearch()
        {
            return View();
        }

        // GET: Department/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm(string Search)
        {
            return View("Index", await _repo.GetMany().Where(d => d.Name.Contains(Search) || d.Financing == Convert.ToDecimal(Search) || d.Id.ToString() == Search).ToListAsync());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _repo.GetAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Financing,Name,FacultyId")] Department department)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _repo.GetAsync(d => d.Id == id);
            await _repo.UpdateAsync(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Financing,Name,FacultyId")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound($"Id is not equal with {nameof(Department)}.Id");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdateAsync(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DepartmentExistsAsync(department.Id))
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
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _repo.GetAsync(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _repo.GetAsync(d=>d.Id == id);
            if (department == null) return NotFound($"Record with id: {id} is not found");
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> DepartmentExistsAsync(int id)
        {
            return _repo.AnyAsync(e => e.Id == id);
        }
    }
}
