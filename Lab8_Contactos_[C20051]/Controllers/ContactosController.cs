using Microsoft.AspNetCore.Mvc;

namespace Lab8_Contactos__C20051_.Controllers
{
    public class ContactosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
