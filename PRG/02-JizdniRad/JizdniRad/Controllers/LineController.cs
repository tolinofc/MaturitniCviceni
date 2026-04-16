using JizdniRad.Models;
using Microsoft.AspNetCore.Mvc;
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
            List<Stop> stops = this.context.Stops.ToList();
            this.ViewBag.stops = stops;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Line line)
        {
            if (ModelState.IsValid)
            {
                Line newLine = line;

                this.context.Lines.Add(newLine);
                this.context.SaveChanges();

                return RedirectToAction("Index");
            }

            List<Stop> stops = this.context.Stops.ToList();
            this.ViewBag.stops = stops;

            return View(line);
        }
    }
}
