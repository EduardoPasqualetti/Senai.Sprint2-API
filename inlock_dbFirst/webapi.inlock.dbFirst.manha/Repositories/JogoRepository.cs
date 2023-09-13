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
            Jogo JogoBuscado = ctx.Jogos.Find(id);

            if (JogoBuscado != null)
            {
                JogoBuscado.Nome = jogo.Nome;
            }

            ctx.Jogos.Update(JogoBuscado);
            ctx.SaveChanges();
        }

        public Jogo BuscarPorId(Guid id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id)!;
        }

        public void Cadastrar(Jogo jogo)
        {
            jogo.IdJogo = Guid.NewGuid();

            ctx.Jogos.Add(jogo);
            ctx.SaveChanges();
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
