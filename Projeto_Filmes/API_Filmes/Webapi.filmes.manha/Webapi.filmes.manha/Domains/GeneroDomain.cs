using System.ComponentModel.DataAnnotations;

namespace Webapi.filmes.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade Genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do genero é obrigatorio")]
        public string Nome { get; set; } 

    }
}
