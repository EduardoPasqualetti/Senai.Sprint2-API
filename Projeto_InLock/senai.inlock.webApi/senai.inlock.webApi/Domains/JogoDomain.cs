namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string DataLancamento { get; set; }
        public float Valor { get; set; }    
        public EstudioDomain Estudio { get; set; }
    }
}
