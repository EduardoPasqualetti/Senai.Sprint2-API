using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interface
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Metodo de cadastrar um novo jogo
        /// </summary>
        /// <param name="jogo">jogo que sera cadastrado</param>
        void Cadastrar(JogoDomain jogo);

        /// <summary>
        /// Metodo que lista todos os jogos
        /// </summary>
        /// <returns>lista dos jogos</returns>
        List<JogoDomain> ListarTodos();
    }
}
