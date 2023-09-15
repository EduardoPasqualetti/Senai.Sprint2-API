using inlock_CodeFirst.Contexts;
using inlock_CodeFirst.Domains;
using inlock_CodeFirst.Interfaces;
using inlock_CodeFirst.Utils;

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
        public Usuario BuscarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Add(usuario);

               
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
