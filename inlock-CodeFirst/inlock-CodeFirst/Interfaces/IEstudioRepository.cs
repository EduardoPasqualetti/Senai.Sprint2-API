using inlock_CodeFirst.Domains;

namespace inlock_CodeFirst.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();

        Estudio BuscarPorId(Guid id);

        void Cadastrar(Estudio estudio);

        void Atualizar(Guid id, Estudio estudio);

        void Deletar(Guid id);

        List<Estudio> ListarComJogos();
    }
}
