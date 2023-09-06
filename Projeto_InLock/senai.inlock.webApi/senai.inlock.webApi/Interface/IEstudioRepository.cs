using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interface
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Metodo de Listar todos os estudios
        /// </summary>
        /// <returns>Lista dos Estudios</returns>
        List<EstudioDomain> ListarTodos();


        /// <summary>
        /// Metodo de Cadastrar um novo estudio
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(EstudioDomain novoEstudio);
    }
}
