namespace Webapi.filmes.manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string? Email { get; set; }  

        public string? Senha { get; set; }

        public string? Permissao { get; set; }
    }
}
