using Microsoft.AspNetCore.Mvc;

namespace ControlePortaria.Controllers
{
    public class CarrosController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Create() 
        {
            return View();
        }

    }
}
