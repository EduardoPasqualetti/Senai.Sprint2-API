using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Get(UsuarioDomain user)
        { 
            UsuarioDomain usuario = _usuarioRepository.Login(user.Email, user.Senha); 

            try
            {
                if (usuario == null)
                {
                    return NotFound("Nenhum Usuario Encontrado!");
                }
                // caso encontre o usuario, prossegue para a criacao do token

                // 1 parte, definir as informacoes(Claims) que serao fornecidas no token (PAYLOAD)
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Permissao),

                    // existe a possibilidade de criar uma clain personalizada
                    new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                // 2 parte - definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                // 3 parte - definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 parte - gerar token
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "webapi.filmes.manha", 

                    //destinatario
                    audience: "webapi.filmes.manha",

                    // dados definidos nas claims(informacoes)
                    claims : claims,

                    // tempo de expiracao do token
                    expires: DateTime.Now.AddMinutes(5),

                    // credenciais do token
                    signingCredentials: creds
                );


                // 5 parte - retornar o token criado
                return Ok(new
                {
                token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }


        }
    }
}
