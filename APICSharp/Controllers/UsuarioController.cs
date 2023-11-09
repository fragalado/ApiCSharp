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

        // Select One Usuario
        [HttpGet("{dni}")]
        public ActionResult<Usuario> GetUsuarioByDni(String dni)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.dni_usuario == dni);
            if (usuario == null)
                return BadRequest("Usuario no encontrado");
            return Ok(usuario);
        }

        // Insert
        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }

        // Update
        [HttpPut]
        public ActionResult<Usuario> UpdateUsuario(Usuario usuario)
        {
            Usuario usu = _context.Usuarios.FirstOrDefault(u => u.dni_usuario == usuario.dni_usuario);
            if (usu == null)
                return BadRequest("Usuario no encontrado");

            usu.nombre_usuario = usuario.nombre_usuario;
            usu.apellidos_usuario = usuario.apellidos_usuario;
            usu.tlf_usuario = usuario.tlf_usuario;
            usu.email_usuario = usuario.email_usuario;
            usu.clave_usuario = usuario.clave_usuario;
            usu.dni_usuario = usuario.dni_usuario;
            usu.estaBloqueado_usuario = usuario.estaBloqueado_usuario;
            usu.fch_fin_bloqueo_usuario = usuario.fch_fin_bloqueo_usuario;
            usu.fch_baja_usuario = usuario.fch_baja_usuario;
            usu.fch_alta_usuario = usuario.fch_alta_usuario;
            usu.AccesoId = usuario.AccesoId;
            usu.Acceso = usuario.Acceso;

            _context.Update(usu);
            _context.SaveChanges();

            return Ok(usu);
        }

        // Delete
        [HttpDelete("{dni}")]
        public ActionResult<Usuario> DeleteUsuario(String dni)
        {
            Usuario usu = _context.Usuarios.FirstOrDefault(u => u.dni_usuario == dni);
            if (usu == null)
                return BadRequest("Usuario no encontrado");

            _context.Remove(usu);
            _context.SaveChanges();

            return Ok(usu);
        }

    }
}
