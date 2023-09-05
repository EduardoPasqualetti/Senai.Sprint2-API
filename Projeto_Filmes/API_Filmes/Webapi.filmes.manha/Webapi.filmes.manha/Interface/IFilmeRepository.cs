using Webapi.filmes.manha.Domains;

namespace Webapi.filmes.manha.Interface
{
    /// <summary>
    /// Interface responsavel pelo repositorio FilmeRepository
    /// Definir os metodos que serao implementados pelo FilmeRepository
    /// </summary>
    public interface IFilmeRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro, NomeParametro)

        /// <summary>
        /// Metodo para Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto que sera cadastrada</param>
        void Cadastrar(FilmeDomain novoFilme);


        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<FilmeDomain> ListarTodos();


        /// <summary>
        /// Atualizar um objeto inteiro existente passando o id pelo corpo da requisicao
        /// </summary>
        /// <param name="Filme">Objeto atualizado</param>
        void AtualizarIdCorpo(FilmeDomain filme);


        /// <summary>
        /// Atualizar uma parte de um objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="Id">Id do objeto que sera atualizado</param>
        /// <param name="filme">Objeto atualizado</param>
        void AtualizarIdUrl(int Id, FilmeDomain filme);


        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="Id">Id do objeto a ser deletado</param>
        void Deletar(int Id);


        /// <summary>
        /// Buscar um objeto atraves de seu id
        /// </summary>
        /// <param name="Id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        FilmeDomain BuscarPorId(int Id);


    }

}
