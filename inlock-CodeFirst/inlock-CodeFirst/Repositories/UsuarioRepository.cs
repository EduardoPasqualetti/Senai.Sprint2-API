using inlock_CodeFirst.Contexts;
using inlock_CodeFirst.Domains;
using inlock_CodeFirst.Interfaces;
using inlock_CodeFirst.Utils;
using Microsoft.AspNetCore.Http.HttpResults;

namespace inlock_CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        /// <summary>
        /// Variavel privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositorio
        /// Toda vez que o repositorio for instanciado, 
        /// ele tera acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        //public Usuario BuscarUsuario(string email, string senha)
       // {
        //    return BuscarUsuario(email, senha);
       // }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                Usuario user = new Usuario();
                user.Email = email;
                user.Senha = senha;

                return user;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Add(usuario);

               ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
