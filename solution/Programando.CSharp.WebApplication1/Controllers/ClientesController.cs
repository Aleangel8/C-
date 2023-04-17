using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programando.CSharp.WebApplication1.Model;

namespace Programando.CSharp.WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ModelNorthwind _context;
        private readonly HttpClient _http;

        public ClientesController(ModelNorthwind context, HttpClient http)
        {
            _context = context;
            _http = http;
        }
        // Consulta en la base de datos
        public IActionResult Index()
        {
            var clientes = _context.Customers.ToList()
                .OrderBy(r=>r.CompanyName)
                .ToList();

            return View(clientes);
        }
        // Consulta a traves de un API
        public IActionResult Index2()
        {

            var clientes = _http.GetFromJsonAsync<List<Customer>>("http://localhost:5117/api/customers").Result;
            return View();
        }
    }
}
