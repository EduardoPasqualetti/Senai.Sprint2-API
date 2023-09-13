using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.manha.Contexts;
using webapi.inlock.dbFirst.manha.Domains;
using webapi.inlock.dbFirst.manha.Interfaces;

namespace webapi.inlock.dbFirst.manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio EstudioBuscado = ctx.Estudios.Find(id);

            if (EstudioBuscado != null)
            {
                EstudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(EstudioBuscado);
            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(Estudio estudio)
        {
            estudio.IdEstudio = Guid.NewGuid();

            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudio = ctx.Estudios.Find(id);
            ctx.Estudios.Remove(estudio);
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
