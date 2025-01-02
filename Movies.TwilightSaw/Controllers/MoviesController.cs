using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.TwilightSaw.Data;
using Movies.TwilightSaw.Models;

namespace Movies.TwilightSaw.Controllers
{
    public class MoviesController(AppDbContext context) : Controller
    {
        DbSet 
        // GET: Movies
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery)
        {
            return searchQuery == null
                ? View(await context.Movies.ToListAsync())
                : View(await context.Movies.Where(s => s.Name == searchQuery).ToListAsync());

        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Score")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                context.Add(movie);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var movie = await context.Movies.FindAsync(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Score")] Movie movie)
        {
            if (id != movie.Id) return NotFound();
        
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(movie);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await context.Movies.FindAsync(id);
            if (movie != null) context.Movies.Remove(movie);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return context.Movies.Any(e => e.Id == id);
        }
    }
}
