using Microsoft.AspNetCore.Mvc;

namespace Robo.Controllers
{
    public class IAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
