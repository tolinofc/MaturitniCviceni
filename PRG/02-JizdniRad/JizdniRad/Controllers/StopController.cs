using JizdniRad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JizdniRad.Controllers
{
    public class StopController : Controller
    {
        private MyContext context = new MyContext();

        public IActionResult Index()
        {
            return View(context.Stops.OrderBy(s => s.Name).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stop? stop = context.Stops.FirstOrDefault(m => m.Id == id);

            if (stop == null)
            {
                return NotFound();
            }

            return View(stop);
        }

        public IActionResult Detail(int id, int stopId)
        {
            Line? line = this.context.Lines.Find(id);

            if (line == null)
            {
                return RedirectToAction("Index");
            }

            Stop? stop = this.context.Stops.Find(stopId);

            this.ViewBag.currentStop = stop;

            List<LineStop> stops = this.context.LineStops
                                            .Where(s => s.LineId == line.Id)
                                            .Include(s => s.Stop)
                                            .Include(s => s.Line)
                                            .OrderBy(s => s.StopOrder)
                                            .ToList();

            List<Departure> departures = this.context.Departures
                                                    .Where(d => d.LineId == line.Id)
                                                    .OrderBy(d => d.DepartureTime)
                                                    .ToList();

            this.ViewBag.stops = stops;

            List<int> workingHours = new List<int>();
            int startHour = 6;
            int endHour = 23;

            for (int i = startHour; i < endHour; i++)
            {
                workingHours.Add(i);
            }

            this.ViewBag.workingHours = workingHours;

            List<DateTime> minutes = new List<DateTime>();
            for (int i = 0; i < departures.Count; i++)
            {
                DateTime currentTime = departures[i].DepartureTime;
                int timeToAdd = 0;
                for (int j = 0; j < stops.Count; j++)
                {
                    timeToAdd += stops[j].TimeFromPrevious;
                    if (stop.Id == stops[j].StopId)
                    {
                        break;
                    }
                }
                minutes.Add(currentTime.AddMinutes(timeToAdd));
                
            }

            this.ViewBag.minutes = minutes;

            return View(line);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stop stop)
        {
            if (ModelState.IsValid)
            {
                context.Add(stop);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stop);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stop = context.Stops.Find(id);
            if (stop == null)
            {
                return NotFound();
            }
            return View(stop);
        }

        [HttpPost]
        public IActionResult Edit(int id, Stop stop)
        {
            if (id != stop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(stop);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StopExists(stop.Id))
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
            return View(stop);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stop = context.Stops
                .FirstOrDefault(m => m.Id == id);
            if (stop == null)
            {
                return NotFound();
            }

            return View(stop);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var stop = context.Stops.Find(id);
            if (stop != null)
            {
                context.Stops.Remove(stop);
            }

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool StopExists(int id)
        {
            return context.Stops.Any(e => e.Id == id);
        }
    }
}
