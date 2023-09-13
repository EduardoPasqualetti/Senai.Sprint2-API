using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();

        }

        [HttpPost]
        public IActionResult Get(UsuarioDomain User)
        {


            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(User.Email, User.Senha);

                if (usuario == null)
                {
                    return NotFound("Nenhum Usuario Encontrado!");
                }


                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString()),

                    // existe a possibilidade de criar uma clain personalizada
                    new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                // 2 parte - definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                // 3 parte - definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 parte - gerar token
                var token = new JwtSecurityToken
                (
                    // emissor do token
                    issuer: "senai.inlock.webApi",

                    //destinatario
                    audience: "senai.inlock.webApi",

                    // dados definidos nas claims(informacoes)
                    claims: claims,

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
