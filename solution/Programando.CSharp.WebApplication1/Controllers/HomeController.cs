using Microsoft.AspNetCore.Mvc;
using Programando.CSharp.WebApplication1.Model;
using Programando.CSharp.WebApplication1.Models;
using System.Diagnostics;

namespace Programando.CSharp.WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly ModelNorthwind _context;

        public HomeController(ModelNorthwind context)
        {
            _context = context;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var clientes = _context.Customers.ToList();          
            return View(clientes);
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