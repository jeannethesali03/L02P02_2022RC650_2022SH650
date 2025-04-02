using L02P02_2022RC650_2022SH650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022RC650_2022SH650.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly libreriaDbContext _context;
        public ComentariosController(libreriaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prototipo3(int id_Libro)
        {
            id_Libro = 1;
            var comentarios = _context.comentarios_libros
                .Where(c => c.id == id_Libro)
                .Select(c => new comentarios_libros
                {
                    id = c.id,
                    comentarios = c.comentarios,
                    usuario = c.usuario,
                    created_at = c.created_at
                })
                .ToList();

            return View("/Views/Prototipo3.cshtml", comentarios);
        }
    }
}
