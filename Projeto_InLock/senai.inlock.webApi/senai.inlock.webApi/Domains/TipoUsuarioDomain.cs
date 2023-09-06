using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O Titulo do Tipo de Usuario e obrigatorio")]
        public string Titulo { get; set; }
    }
}
