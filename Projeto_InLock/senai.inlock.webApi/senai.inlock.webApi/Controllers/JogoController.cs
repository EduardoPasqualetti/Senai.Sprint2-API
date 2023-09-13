using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : Controller
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult Get() 
        {
            try
            {
                List<JogoDomain> ListaJogos = _jogoRepository.ListarTodos();
                if (ListaJogos != null)
                {
                    return Ok(ListaJogos);
                }
                return NotFound("Nenhuma lista de jogos foi encontrada");
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
          
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(JogoDomain jogo)
        {
            try
            {
                _jogoRepository.Cadastrar(jogo);
                return StatusCode(201);
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }
      
    }
}
