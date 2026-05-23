using Lab8_Contactos_C20051.Data;
using Lab8_Contactos_C20051.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab8_Contactos_C20051.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetTodos()
        {
            return Ok(await _context.Contactos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetPorId(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
                return NotFound(new { error = $"No se encontró el contacto con id {id}" });

            return Ok(contacto);
        }
    }
}