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

        void Cadastrar(GeneroDomain novoGenero);
        List<GeneroDomain> ListarTodos();

        void AtualizarIdCorpo(GeneroDomain Genero);

        void Deletar(int Id);
    }
}
