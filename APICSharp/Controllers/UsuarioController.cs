using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Contexto _context;

        public UsuarioController(Contexto contexto)
        {
            _context = contexto;
        }

        // Select
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        // Insert
        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.id_usuario }, usuario);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();

            return NoContent();
        }

        // Delete
    }
}
