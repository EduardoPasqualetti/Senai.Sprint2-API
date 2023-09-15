using inlock_CodeFirst.Domains;

namespace inlock_CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
