﻿using System;
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
    public class ShowsController : Controller
    {
        private readonly MoviesDatabase _context;

        public ShowsController(MoviesDatabase context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var moviesDatabase = _context.Show.Include(s => s.Cinema).Include(s => s.Kids_Collection).Include(s => s.Movie);
            return View(await moviesDatabase.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.Cinema)
                .Include(s => s.Kids_Collection)
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "Id", "Address");
            ViewData["Kids_CollectionId"] = new SelectList(_context.Kids_Collection, "Id", "Director");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Director");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Shows,CinemaId,MovieId,Kids_CollectionId,Available_Shows,Ticket_Price")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "Id", "Address", show.CinemaId);
            ViewData["Kids_CollectionId"] = new SelectList(_context.Kids_Collection, "Id", "Director", show.Kids_CollectionId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Director", show.MovieId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "Id", "Address", show.CinemaId);
            ViewData["Kids_CollectionId"] = new SelectList(_context.Kids_Collection, "Id", "Director", show.Kids_CollectionId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Director", show.MovieId);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Shows,CinemaId,MovieId,Kids_CollectionId,Available_Shows,Ticket_Price")] Show show)
        {
            if (id != show.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.Id))
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
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "Id", "Address", show.CinemaId);
            ViewData["Kids_CollectionId"] = new SelectList(_context.Kids_Collection, "Id", "Director", show.Kids_CollectionId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Director", show.MovieId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.Cinema)
                .Include(s => s.Kids_Collection)
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Show.FindAsync(id);
            _context.Show.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.Id == id);
        }
    }
}
