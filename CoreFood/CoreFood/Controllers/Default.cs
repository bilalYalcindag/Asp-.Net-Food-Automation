using Microsoft.AspNetCore.Mvc;

namespace CoreFood.Controllers
{
    public class Default : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
