using Lab8_Contactos_C20051.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_Contactos_C20051.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : ControllerBase
    {
        private static readonly List<Contacto> _contactos = new()
        {
            new Contacto { Id = 1, Nombre = "Ana Pérez",      Telefono = "8888-1111" },
            new Contacto { Id = 2, Nombre = "Carlos Mora",    Telefono = "8888-2222" },
            new Contacto { Id = 3, Nombre = "María Jiménez",  Telefono = "8888-3333" },
            new Contacto { Id = 4, Nombre = "Luis Rodríguez", Telefono = "8888-4444" },
            new Contacto { Id = 5, Nombre = "Sofía Castro",   Telefono = "8888-5555" },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Contacto>> GetTodos()
        {
            return Ok(_contactos);
        }

        [HttpGet("{id}")]
        public ActionResult<Contacto> GetPorId(int id)
        {
            var contacto = _contactos.FirstOrDefault(c => c.Id == id);
            if (contacto == null)
                return NotFound(new { error = $"No se encontró el contacto con id {id}" });

            return Ok(contacto);
        }
    }
}
