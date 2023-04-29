using Microsoft.AspNetCore.Mvc;

namespace SAEgym.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
