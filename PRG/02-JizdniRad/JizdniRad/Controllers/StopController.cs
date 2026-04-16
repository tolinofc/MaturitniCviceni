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
            return View(this.context.Stops.OrderBy(s => s.Name).ToList());
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
                    if (stop.Id == stops[j].Id)
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
        public IActionResult Edit(int id)
        {
            Stop? stop = this.context.Stops.Find(id);
            if (stop == null)
            {
                return RedirectToAction("Index");
            }
            return View(stop);
        }

        [HttpPost]
        public IActionResult Edit(Stop stop)
        {
            if (ModelState.IsValid)
            {
                this.context.Entry(stop).State = EntityState.Modified;
                this.context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(stop);

        }
    }
}
