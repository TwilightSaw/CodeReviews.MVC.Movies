using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.TwilightSaw.Data;
using Movies.TwilightSaw.Models;

namespace Movies.TwilightSaw.Controllers
{
    public class SeriesController(AppDbContext context) : Controller
    {
        // GET: Movies
        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery)
        {
            return searchQuery == null
                ? View(await context.Series.ToListAsync())
                : View(await context.Series.Where(s => s.Name.ToLower().Contains(searchQuery.ToLower())).ToListAsync());

        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var series = await context.Series.FirstOrDefaultAsync(m => m.Id == id);
            if (series == null) return NotFound();

            return View(series);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Score,Episodes,Image")] Series series)
        {
            if (ModelState.IsValid)
            {
                context.Add(series);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(series);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var series = await context.Series.FindAsync(id);
            if (series == null) return NotFound();

            return View(series);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Score,Episodes,Image")] Series series)
        {
            if (id != series.Id) return NotFound();
        
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(series);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(series.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(series);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var series = await context.Series.FirstOrDefaultAsync(m => m.Id == id);
            if (series == null) return NotFound();

            return View(series);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var series = await context.Series.FindAsync(id);
            if (series != null) context.Series.Remove(series);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return context.Series.Any(e => e.Id == id);
        }
    }
}
