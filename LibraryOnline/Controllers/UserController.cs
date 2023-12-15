using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
