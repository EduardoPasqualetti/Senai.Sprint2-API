using webapi.inlock.dbFirst.manha.Contexts;
using webapi.inlock.dbFirst.manha.Domains;
using webapi.inlock.dbFirst.manha.Interfaces;

namespace webapi.inlock.dbFirst.manha.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid id, Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Jogo BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
           Jogo jogoBuscado = ctx.Jogos.Find(id);

            ctx.Jogos.Remove(jogoBuscado);
            ctx.SaveChanges();
        }

        public List<Jogo> Listar()
        {
            return ctx.Jogos.ToList();
        }
    }
}
