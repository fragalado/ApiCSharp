using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly Contexto _context;

        public AccesoController(Contexto contexto)
        {
            _context = contexto;
        }

        // Select
        [HttpGet]
        public ActionResult<IEnumerable<Acceso>> GetAccesos()
        {
            return _context.Accesos.ToList();
        }

        // Select One Usuario
        [HttpGet("{codigo}")]
        public ActionResult<Acceso> GetAccesoByCodigo(String codigo)
        {
            Acceso acceso = _context.Accesos.FirstOrDefault(u => u.codigo_acceso == codigo);
            if (acceso == null)
                return BadRequest("Acceso no encontrado");
            return Ok(acceso);
        }

        // Insert
        [HttpPost]
        public ActionResult<Acceso> PostAcceso(Acceso acceso)
        {
            _context.Accesos.Add(acceso);
            _context.SaveChanges();
            return Ok(acceso);
        }

        // Update
        [HttpPut("{id}")]
        public ActionResult<Acceso> UpdateAcceso(long id, Acceso acceso)
        {
            Acceso acc = _context.Accesos.FirstOrDefault(u => u.id_acceso == id);
            if (acc == null)
                return BadRequest("Acceso no encontrado");

            acc.codigo_acceso = acceso.codigo_acceso;
            acc.descripcion_acceso = acceso.descripcion_acceso;

            _context.Update(acc);
            _context.SaveChanges();

            return Ok(acc);
        }

        // Delete
        [HttpDelete("{codigo}")]
        public ActionResult<Acceso> DeleteAcceso(String codigo)
        {
            Acceso acc = _context.Accesos.FirstOrDefault(u => u.codigo_acceso == codigo);
            if (acc == null)
                return BadRequest("Acceso no encontrado");

            _context.Remove(acc);
            _context.SaveChanges();

            return Ok(acc);
        }
    }
}
