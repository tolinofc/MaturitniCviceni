using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JizdniRad.Models;

namespace JizdniRad.Controllers
{
    public class DepartureController : Controller
    {
        private MyContext context = new MyContext();

        public IActionResult Index()
        {
            var myContext = context.Departures.Include(d => d.Line);
            return View(myContext.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departure = context.Departures
                .Include(d => d.Line)
                .FirstOrDefault(m => m.Id == id);
            if (departure == null)
            {
                return NotFound();
            }

            return View(departure);
        }

        [HttpGet]
        public IActionResult Create(int lineId)
        {
            Departure departure = new Departure()
            {
                Id = lineId,
            };
            return View(departure);
        }

        [HttpPost]
        public IActionResult Create(Departure departure)
        {
            ModelState.Remove("Line");
            if (ModelState.IsValid)
            {
                context.Add(departure);
                context.SaveChanges();
                return RedirectToAction("Index", "Line");
            }

            ViewData["LineId"] = departure.LineId;
            return View(departure);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departure = context.Departures.Find(id);
            if (departure == null)
            {
                return NotFound();
            }
            ViewData["LineId"] = new SelectList(context.Lines, "Id", "Name", departure.LineId);
            return View(departure);
        }

        [HttpPost]
        public IActionResult Edit(int id, Departure departure)
        {
            if (id != departure.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Line");

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(departure);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartureExists(departure.Id))
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
            ViewData["LineId"] = new SelectList(context.Lines, "Id", "Name", departure.LineId);
            return View(departure);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departure = await context.Departures
                .Include(d => d.Line)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departure == null)
            {
                return NotFound();
            }

            return View(departure);
        }

        // POST: Departure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departure = await context.Departures.FindAsync(id);
            if (departure != null)
            {
                context.Departures.Remove(departure);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartureExists(int id)
        {
            return context.Departures.Any(e => e.Id == id);
        }
    }
}
