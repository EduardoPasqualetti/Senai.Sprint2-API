using System.ComponentModel.DataAnnotations;

namespace Webapi.filmes.manha.Domains
{
    /// <summary>
    /// CLasse que representa a entidade Filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O titulo do filme é obrigatorio")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O filme deve possuir um genero")]
        public int IdGenero { get; set; }

        // Referenciar a classe Genero 
        public GeneroDomain? Genero { get; set; }
    }
}
