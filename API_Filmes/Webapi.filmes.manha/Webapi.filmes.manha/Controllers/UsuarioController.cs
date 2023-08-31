using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Webapi.filmes.manha.Domains;
using Webapi.filmes.manha.Interface;
using Webapi.filmes.manha.Repositories;

namespace Webapi.filmes.manha.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();

        }

        /// <summary>
        /// Endpoint que aciona o metodo de login
        /// </summary>
        /// <param name="Email">email de login</param>
        /// <param name="Senha">senha de login</param>
        /// <returns>usuario</returns>
        [HttpGet]
        public IActionResult Get(string email, string senha)
        { 
            UsuarioDomain usuario = _usuarioRepository.Login(email, senha); 

            try
            {
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return NotFound("Nenhum Usuario Encontrado!");
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }


        }
    }
}
