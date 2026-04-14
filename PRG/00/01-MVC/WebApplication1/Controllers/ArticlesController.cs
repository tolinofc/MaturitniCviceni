using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ArticlesController : Controller
    {
        private MyContext context = new MyContext();
        public IActionResult Index()
        {
            return View(context.Articles);
        }

        public IActionResult Detail(int id)
        {
            return View(context.Articles.Find(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                this.context.Articles.Add(article);
                this.context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(this.context.Articles.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if(ModelState.IsValid)
            {
                this.context.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(article);
        }

        public IActionResult Delete(int id)
        {
            Article db = this.context.Articles.Find(id);
            this.context.Articles.Remove(db);
            this.context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
