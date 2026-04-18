using JizdniRad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JizdniRad.Controllers
{
    public class LineController : Controller
    {
        private MyContext context = new MyContext();
        public IActionResult Index()
        {
            List<Line> lines = this.context.Lines.ToList();
            return View(lines);
        }

        public IActionResult Detail(int id)
        {
            Line? line = this.context.Lines.Find(id);

            if (line == null)
            {
                return RedirectToAction("Index");
            }

            List<LineStop> stops = this.context.LineStops
                                            .Where(s => s.LineId == line.Id)
                                            .Include(s => s.Stop)
                                            .Include(s => s.Line)
                                            .OrderBy(s => s.StopOrder)
                                            .ToList();

            List<Departure> departures = this.context.Departures
                                                    .Where(d => d.LineId == line.Id)
                                                    .ToList();

            this.ViewBag.stops = stops;

            return View(line);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Line line)
        {
            if (ModelState.IsValid)
            {
                context.Add(line);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(line);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Line? line = context.Lines.Find(id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        [HttpPost]
        public IActionResult Edit(int id, Line line)
        {

            if (id != line.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(line);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineExists(line.Id))
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
            return View(line);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = context.Lines
                .FirstOrDefault(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var line = context.Lines.Find(id);
            if (line != null)
            {
                context.Lines.Remove(line);
            }

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool LineExists(int id)
        {
            return context.Lines.Any(e => e.Id == id);
        }

        public IActionResult AddStops(int lineId)
        {
            LineStop lineStop = new LineStop()
            {
                LineId = lineId
            };

            List<int> existingStopIds = context.LineStops
                                        .Where(l => l.LineId == lineId)
                                        .Select(l => l.StopId)
                                        .ToList();

            List<Stop> availableStops = context.Stops
                                        .Where(s => !existingStopIds.Contains(s.Id))
                                        .ToList();

            SelectList stops = new SelectList(availableStops, "Id", "Name");
            this.ViewBag.stops = stops;

            return View(lineStop);
        }

        [HttpPost]
        public IActionResult AddStops(LineStop model)
        {
            ModelState.Remove("Line");
            ModelState.Remove("Stop");
            if (ModelState.IsValid)
            {
                this.context.LineStops.Add(model);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            List<int> existingStopIds = context.LineStops
                                        .Where(l => l.LineId == model.LineId)
                                        .Select(l => l.LineId)
                                        .ToList();

            List<Stop> availableStops = context.Stops
                                        .Where(s => !existingStopIds.Contains(s.Id))
                                        .ToList();

            SelectList stops = new SelectList(availableStops, "Id", "Name");
            this.ViewBag.stops = stops;

            return View(model);
        }
    }
}
