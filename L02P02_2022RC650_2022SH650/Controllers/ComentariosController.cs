using L02P02_2022RC650_2022SH650.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        //public IActionResult Prototipo3(int id_Libro)
        //{
        //    id_Libro = 1;
        //    var comentarios = _context.comentarios_libros
        //        .Where(c => c.id == id_Libro)
        //        .Select(c => new comentarios_libros
        //        {
        //            id = c.id,
        //            comentarios = c.comentarios,
        //            usuario = c.usuario,
        //            created_at = c.created_at
        //        })
        //        .ToList();

        //    return View("/Views/Prototipo3.cshtml", comentarios);
        //}


        public IActionResult Prototipo3(int id_Libro)
        {
            id_Libro = 1;
            var libro = (from libros in _context.libros
                         join autores in _context.autores on libros.id_autor equals autores.id
                         where libros.id == id_Libro
                         select new
                         {
                             libros.nombre,
                             Autor = autores.autor
                         }).FirstOrDefault();

            //Console.WriteLine("ID:"+ id_Libro);
            //if (libro == null)
            //{
            //    // Log or handle the case where no book is found
            //    return NotFound(); // Or return a view with an error message
            //}

            var comentarios = _context.comentarios_libros
              .Where(comentarios => comentarios.id_libro == id_Libro)
              .Select(comentarios => new comentarios_libros
              {
                  id = comentarios.id,
                  comentarios = comentarios.comentarios,
                  usuario = comentarios.usuario,
                  created_at = comentarios.created_at
              })
              .ToList();

            ViewBag.Comentarios = comentarios;
            ViewBag.Libro = libro.nombre;
            ViewBag.Autor = libro.Autor;
            ViewBag.IdLibro = id_Libro;

           

            return View("/Views/Prototipo3.cshtml");
        }



    }
}
