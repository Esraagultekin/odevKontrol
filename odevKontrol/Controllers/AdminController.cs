using Microsoft.AspNetCore.Mvc;

namespace odevKontrol.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
