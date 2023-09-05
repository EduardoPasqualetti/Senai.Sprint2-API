using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Webapi.filmes.manha.Domains;
using Webapi.filmes.manha.Interface;
using Webapi.filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Authorize(Roles = "Administrador,Comum")]
        public IActionResult Get()
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

        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                // Chamando o metodo cadastrar passando o objeto como parametro
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201);
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }


        }

        /// <summary>
        /// Endpoint que aciona o metodo de deletar genero
        /// </summary>
        /// <param name="id">Objeto recebido na requisicao</param>
        /// <returns>Status code 200</returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ERRO)
            {

                return BadRequest(ERRO.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de buscar um genero por id
        /// </summary>
        /// <param name="id">Objeto usado como parametro</param>
        /// <returns>o genero buscado</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Comum")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("Nenhum Genero Encontrado!");
                }

                return Ok(generoBuscado);
            }
            catch (Exception ERRO)
            {

                return BadRequest(ERRO.Message);
            }
        }


        /// <summary>
        /// Endpoint que  aciona o metodo de atualizar um objeto por id
        /// </summary>
        /// <param name="id">Id do objeto a ser modificado</param>
        /// <param name="genero">Nome que substituira o nome antigo</param>
        /// <returns>code 200</returns>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(int id, GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrl(id, genero);
                        return StatusCode(204);
                    }
                    catch (Exception ERRO)
                    {
                        return NotFound("Genero nao encontrado");
                    }
                }
                throw new Exception();
                
            }
            catch (Exception erro)
            {
                return NotFound("Genero nao encontrado");
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de atualizar um objeto pelo corpo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>

        [HttpPut("{Genero}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult AtualizarCorpo(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);
                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);
                        return StatusCode(204);
                    }
                    catch (Exception ERRO)
                    {
                        return BadRequest(ERRO.Message);
                    }
                }
                throw new Exception();
            }
            catch (Exception ERRO)
            {
                return NotFound("Genero nao Encontrado");
            }
        }
    }
}