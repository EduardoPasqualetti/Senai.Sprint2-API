using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repositories;
using senai.inlock.webApi.Domains;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class EstudioController : Controller
    {
        private IEstudioRepository _estudioRepository { get; set; }
        
        public EstudioController() 
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult Get() 
        {
            try
            {
                List<EstudioDomain> ListaEstudios = _estudioRepository.ListarTodos();
                if (ListaEstudios != null)
                {
                    return Ok(ListaEstudios);
                }
                return NotFound("Nenhuma lista de estudios foi encontrada");
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(EstudioDomain estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);
                return StatusCode(201);
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }

    }
}