using Microsoft.AspNetCore.Mvc;
using SessionExam.Filter;
using SessionExam.Models;
using System.Diagnostics;
using System.Text.Json;

namespace SessionExam.Controllers
{
    public class HomeController : AController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Auth]
        public IActionResult Index()
        {
            var sessionUser = HttpContext.Session.GetString("user");

            if (string.IsNullOrWhiteSpace(sessionUser)) { return RedirectToAction("Login", "Login"); }

            //model olarak elimizde 
            var girisYapanKullanici = JsonSerializer.Deserialize<User>(sessionUser);

            ViewBag.girisYapanKullanici = girisYapanKullanici.Name;
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}