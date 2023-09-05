using Webapi.filmes.manha.Domains;

namespace Webapi.filmes.manha.Interface
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro, NomeParametro)

        /// <summary>
        /// Metodo para Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que sera cadastrada</param>
        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Atualizar um objeto inteiro existente passando o id pelo corpo da requisicao
        /// </summary>
        /// <param name="Genero">Objeto  atualizado</param>
        void AtualizarIdCorpo(GeneroDomain Genero);


        /// <summary>
        /// Atualizar uma parte de um objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="Id">Id do objeto que sera atualizado</param>
        /// <param name="genero">Objeto atualizado</param>
        void AtualizarIdUrl(int Id, GeneroDomain genero);


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
        GeneroDomain BuscarPorId(int Id);


    }
}
