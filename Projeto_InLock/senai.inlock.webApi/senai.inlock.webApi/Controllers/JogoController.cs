using Microsoft.AspNetCore.Mvc;

namespace senai.inlock.webApi.Controllers
{
    public class JogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
