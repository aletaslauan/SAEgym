using Microsoft.AspNetCore.Mvc;

namespace SAEgym.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
