using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.filmes.manha.Domains;
using Webapi.filmes.manha.Interface;
using Webapi.filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Webapi.filmes.manha.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]

    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// EndPoint que aciona o metodo ListarTodos os filmes do repositorio 
        /// </summary>
        /// <returns>resposta para o usuario(front-end)</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador,Comum")]
        public IActionResult Get()
        {

            try
            {
                List<FilmeDomain> ListaFilmes = _filmeRepository.ListarTodos();
                if (ListaFilmes != null)
                {
                    return Ok(ListaFilmes);
                }

                return NotFound();

            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }

        }

        /// <summary>
        /// Endpoint que aciona o metodo Deletar um filme
        /// </summary>
        /// <param name="id">id do filme a ser deletado</param>
        /// <returns>status code 204</returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(204);

            }
            catch (Exception ERRO)
            {

                return BadRequest(ERRO.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo Cadastar um filme
        /// </summary>
        /// <param name="novoFilme">Filme que sera cadastrado</param>
        /// <returns>status code 201</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return StatusCode(201);
            }
            catch (Exception ERRO)
            {

                return BadRequest(ERRO.Message);
            }
        }


        /// <summary>
        /// Endpoint que aciona o metodo de buscar um objeto pelo id
        /// </summary>
        /// <param name="id">id do objeto a ser buscado</param>
        /// <returns>o filme buscado</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Comum")]
        public IActionResult Get(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum Genero Encontrado!");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception ERRO)
            {

                return BadRequest(ERRO.Message);
            }
        }


        /// <summary>
        /// Endpoint que aciona o metodo de atualizar por id
        /// </summary>
        /// <param name="id">id do filme a ser atualizado</param>
        /// <param name="Filme">filme atualizado</param>
        /// <returns>status code 204</returns>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(int id, FilmeDomain Filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(Filme.IdFilme);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUrl(id, Filme);
                        return StatusCode(204);
                    }
                    catch (Exception ERRO)
                    {
                        return BadRequest(ERRO.Message);
                    }
                }
                return NotFound("Filme nao encontrado");

            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de atualizar pelo corpo
        /// </summary>
        /// <param name="Filme">objeto que sera atualizado</param>
        /// <returns>status code 204</returns>
        [HttpPut("{Filme}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(FilmeDomain Filme)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(Filme.IdFilme);
            try
            {
                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(Filme);
                        return StatusCode(204);
                    }
                    catch (Exception ERRO)
                    {
                        return BadRequest(ERRO.Message);
                    }
                }
                return NotFound("Filme nao encontrado");

            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }
    }

}
