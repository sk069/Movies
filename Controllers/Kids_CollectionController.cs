using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Controllers
{
    public class Kids_CollectionController : Controller
    {
        private readonly MoviesDatabase _context;

        public Kids_CollectionController(MoviesDatabase context)
        {
            _context = context;
        }

        // GET: Kids_Collection
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kids_Collection.ToListAsync());
        }

        // GET: Kids_Collection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids_Collection = await _context.Kids_Collection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kids_Collection == null)
            {
                return NotFound();
            }

            return View(kids_Collection);
        }

        // GET: Kids_Collection/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kids_Collection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Director,Producer")] Kids_Collection kids_Collection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kids_Collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kids_Collection);
        }

        // GET: Kids_Collection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids_Collection = await _context.Kids_Collection.FindAsync(id);
            if (kids_Collection == null)
            {
                return NotFound();
            }
            return View(kids_Collection);
        }

        // POST: Kids_Collection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Director,Producer")] Kids_Collection kids_Collection)
        {
            if (id != kids_Collection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kids_Collection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Kids_CollectionExists(kids_Collection.Id))
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
            return View(kids_Collection);
        }

        // GET: Kids_Collection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids_Collection = await _context.Kids_Collection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kids_Collection == null)
            {
                return NotFound();
            }

            return View(kids_Collection);
        }

        // POST: Kids_Collection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kids_Collection = await _context.Kids_Collection.FindAsync(id);
            _context.Kids_Collection.Remove(kids_Collection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Kids_CollectionExists(int id)
        {
            return _context.Kids_Collection.Any(e => e.Id == id);
        }
    }
}
