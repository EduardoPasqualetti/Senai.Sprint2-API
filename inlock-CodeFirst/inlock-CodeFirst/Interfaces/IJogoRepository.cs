using inlock_CodeFirst.Domains;

namespace inlock_CodeFirst.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();

        Jogo BuscarPorId(Guid id);

        void Cadastrar(Jogo jogo);

        void Atualizar(Guid id,Jogo jogo);

        void Deletar(Guid id);
    }
}
