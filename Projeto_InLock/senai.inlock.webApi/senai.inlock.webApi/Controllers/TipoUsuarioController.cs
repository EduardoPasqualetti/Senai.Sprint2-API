using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class TipoUsuarioController : Controller
    {
        private ITipoUsuarioRepository _tipoRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de listar todos os Tipos de Usuario
        /// </summary>
        /// <returns>Lista dos estudios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuarioDomain> ListaTipo = _tipoRepository.ListarTodos();
                if (ListaTipo != null)
                {
                    return Ok(ListaTipo);
                }
                return NotFound();
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }
    }
}
