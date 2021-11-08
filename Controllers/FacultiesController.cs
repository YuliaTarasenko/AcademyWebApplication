﻿using System;
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
    public class FacultiesController : Controller
    {
        private readonly IFacultiesRepository _repo;

        public FacultiesController(IFacultiesRepository repo)
        {
            _repo = repo;
        }

        // GET: Faculties
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetMany().ToListAsync());
        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _repo.GetAsync(m => m.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(faculty);
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _repo.GetAsync(f => f.Id == id);
            await _repo.UpdateAsync(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound($"Id is not equal with {nameof(Faculty)}.Id");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdateAsync(faculty);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FacultyExistsAsync(faculty.Id))
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
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _repo.GetAsync(f => f.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faculty = await _repo.GetAsync(f => f.Id == id);
            if (faculty == null) return NotFound($"Record with id: {id} is not found");
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> FacultyExistsAsync(int id)
        {
            return _repo.AnyAsync(e => e.Id == id);
        }
    }
}
