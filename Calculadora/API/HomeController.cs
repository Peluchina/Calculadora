using Microsoft.AspNetCore.Mvc;
using Calculadora;

namespace Calculadora.API
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
