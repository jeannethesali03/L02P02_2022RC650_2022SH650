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


        public IActionResult SeleccionarLibro(int id)
        {
            var libro = (from libros in _context.libros
                         join autores in _context.autores on libros.id_autor equals autores.id
                         where libros.id == id
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
              .Where(comentarios => comentarios.id_libro == id)
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
            ViewBag.IdLibro = id;

           

            return View("/Views/Prototipo3.cshtml");
        }


        public IActionResult AgregarComentario(int idLibro, string comentario)
        {
            // Verifica que los parámetros sean válidos
            if (idLibro <= 0 || string.IsNullOrEmpty(comentario))
            {
                return BadRequest("Datos inválidos.");
            }

            // Crear una nueva instancia de ComentariosLibros
            var nuevoComentario = new comentarios_libros
            {
                id = idLibro,
                comentarios = comentario,
                usuario = "user", // Asumiendo que todos los comentarios son de un usuario genérico
                created_at = DateTime.Now // Fecha y hora actual
            };

            // Agregar el nuevo comentario a la tabla de comentarios
            _context.comentarios_libros.Add(nuevoComentario);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Redirigir a la vista de detalles del libro o cualquier otra vista según lo que desees hacer
            return View("/Views/Prototipo3.cshtml");
        }


    }
}
