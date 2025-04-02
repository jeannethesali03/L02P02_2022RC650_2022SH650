using L02P02_2022RC650_2022SH650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022RC650_2022SH650.Controllers
{
    public class AutoresController : Controller
    {
        public readonly libreriaDbContext _context;
        public AutoresController(libreriaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerAutores()
        {
            List<autores> autoresList = _context.autores.ToList();
            return View("/Views/Prototipo1.cshtml", autoresList);
        }

        public IActionResult SeleccionarAutor(int id)
        {
            autores autor = _context.autores.Where(x => x.id == id).FirstOrDefault();
            ViewBag.Autor = autor;
            List<libros> librosList = _context.libros.Where(x => x.id_autor == id).ToList();
            return View("/Views/Prototipo2.cshtml", librosList);
        }
    }
}
