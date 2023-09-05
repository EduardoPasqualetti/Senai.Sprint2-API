using Webapi.filmes.manha.Domains;

namespace Webapi.filmes.manha.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
