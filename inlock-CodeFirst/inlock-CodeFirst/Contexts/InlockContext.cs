using inlock_CodeFirst.Domains;
using Microsoft.EntityFrameworkCore;

namespace inlock_CodeFirst.Contexts
{
    public class InlockContext : DbContext
    {
        //definir as entidades do banco de dados
        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        
        /// <summary>
        /// Definir as opcoes de construcao do banco de dados (String de Conexao)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configuracoes definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE16-S14; Database=inlock_games_CodeFirst_manha; User id=sa; pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
