using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inlock_CodeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo obrigatorio")]
        public string Nome { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao do jogo obrogatoria")]
        public string Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lancamento obrigatorio")]
        public DateTime DataLancamento { get; set; }


        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "Preco do jogo obrigatorio")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "Obrigatorio informar o estudio que produziu o jogo")]
        public Guid IdEstudio { get; set; }


        [ForeignKey("IdEstudio")]
        public Estudio Estudio { get; set; }
    }
}
