using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using modelwalakam.Data;
using modelwalakam.Models;
using System.Diagnostics;

namespace modelwalakam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly connectionContext db;

        public HomeController(ILogger<HomeController> logger, connectionContext db)
        {
            _logger = logger;

            this.db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User abrsh)
        {

            db.Users.Add(abrsh);
            db.SaveChanges();

            return View();
        }
        public IActionResult studentlist()
        {


            return View(db.Users.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}