using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class NumbersController : Controller
    {
        public IActionResult Index(int start, int count = 10)
        {
            this.ViewBag.Start = start;
            this.ViewBag.Count = count;
            this.ViewBag.End = start + count;
            return View();
        }
    }
}
