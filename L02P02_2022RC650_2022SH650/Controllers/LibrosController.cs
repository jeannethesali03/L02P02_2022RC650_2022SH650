using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022RC650_2022SH650.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
