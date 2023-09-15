using inlock_CodeFirst.Interfaces;
using inlock_CodeFirst.Repositories;
using inlock_CodeFirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha);
            return Ok();
        }

    }
}
