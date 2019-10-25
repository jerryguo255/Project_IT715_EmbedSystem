using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherRecordServer.Models;

namespace WeatherRecordServer.Controllers
{
    public class WeatherRecordsController : Controller
    {
        private readonly WeatherRecordDBContext _context;

        public WeatherRecordsController(WeatherRecordDBContext context)
        {
            _context = context;
        }

        // GET: WeatherRecords
        public async Task<IActionResult> Index()
        {
            var sss = 2;
            return View(await _context.WeatherRecords.ToListAsync());
        }

        // GET: WeatherRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherRecords = await _context.WeatherRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherRecords == null)
            {
                return NotFound();
            }

            return View(weatherRecords);
        }

        // GET: WeatherRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCollection,TempOutside,TempIndoor,HumOutside,HumIndoor")] WeatherRecords weatherRecords)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherRecords);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherRecords);
        }

        // GET: WeatherRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherRecords = await _context.WeatherRecords.FindAsync(id);
            if (weatherRecords == null)
            {
                return NotFound();
            }
            return View(weatherRecords);
        }

        // POST: WeatherRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCollection,TempOutside,TempIndoor,HumOutside,HumIndoor")] WeatherRecords weatherRecords)
        {
            if (id != weatherRecords.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherRecordsExists(weatherRecords.Id))
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
            return View(weatherRecords);
        }

        // GET: WeatherRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherRecords = await _context.WeatherRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherRecords == null)
            {
                return NotFound();
            }

            return View(weatherRecords);
        }

        // POST: WeatherRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherRecords = await _context.WeatherRecords.FindAsync(id);
            _context.WeatherRecords.Remove(weatherRecords);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherRecordsExists(int id)
        {
            return _context.WeatherRecords.Any(e => e.Id == id);
        }
    }
}
