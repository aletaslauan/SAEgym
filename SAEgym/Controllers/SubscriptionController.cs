using Microsoft.AspNetCore.Mvc;

namespace SAEgym.Controllers
{
    public class SubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
