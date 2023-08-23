using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.filmes.manha.Domains;
using Webapi.filmes.manha.Interface;
using Webapi.filmes.manha.Repositories;

namespace Webapi.filmes.manha.Controllers
{
    // Define que a rota de uma requisicao sera no seguinte formato
    // Dominio/api/nomeController
    // Ex: http://localhost:5000/api/Genero
    [Route("api/[controller]")]

    //  Define que e um controlador de API
    [ApiController]

    // Define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    // Metodo controlador que herda da controller base
    // Onde sera craido os Endpoints (rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referencia ao metodos do repositorio
        /// </summary>
        /// 
        // Construtor do Controller
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint que aciona o metodo ListarTodos no repositorio 
        /// </summary>
        /// <returns>resposta para o usuario(front-end)</returns>
        [HttpGet]
        public IActionResult ListarGenero() 
        {

            try
            {
                // Cria uma lista que recebe os dados da requisicao
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                // Retorna a lista no formato JSON com o status code Ok(200)
                return Ok(ListaGeneros);
            }
            catch (Exception ERRO)
            {
                // Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(ERRO.Message);
            }

        }
    }
} 