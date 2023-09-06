using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interface
{
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Metodo de listar os tipos de usuario
        /// </summary>
        /// <returns>lista dos tipos de usuario</returns>
        List<TipoUsuarioDomain> ListarTodos();
    }
}
