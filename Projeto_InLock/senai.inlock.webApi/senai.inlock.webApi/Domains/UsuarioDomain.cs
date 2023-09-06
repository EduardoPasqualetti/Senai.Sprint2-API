using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo email e obrigatorio")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "A senha deve ter de 4 a 20 caracteres")]
        [Required(ErrorMessage = "O campo senha e obrigatorio")]
        public string Senha { get; set; }
        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
