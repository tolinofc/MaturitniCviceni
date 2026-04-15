using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            this.ViewBag.Message = "Hello";
            this.ViewData["message"] = "hello";

            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Index(LoginModel login)
        {
            if (login.Username == "Foo")
            {
                ModelState.AddModelError("Username", "spatne jmeno");
            }

            if (ModelState.IsValid)
            {
                if (login.Username == "Pepa" && login.Password == "123456")
                {
                    //this.HttpContext.Session.SetString("login", login.Username);
                    this.HttpContext.Session.SetString("login", JsonConvert.SerializeObject(login));


                    return RedirectToAction("Index");
                }

            }
            
            return View(login);
        }
    }
}
