using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inlock_CodeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)] // cria um indice unico para o email, nao pode se repetir
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string? Email { get; set; }


        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Senha obrigatoria")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "A senha deve conter de 6 a 20 caracteres")]
        public string? Senha { get; set; }


        [Required(ErrorMessage = "Tipo do usuario obrigatorio")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
