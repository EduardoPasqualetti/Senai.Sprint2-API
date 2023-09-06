using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string conexao = "Data Source = NOTE16-S14 ; Initial Catalog = InLock_Manha; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string QueryLogin = "SELECT Usuario.IdUsuario, Usuario.Email, TiposUsuario.Titulo FROM Usuario JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Usuario.Email = @email and Usuario.Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(QueryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain user = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = rdr["Email"].ToString(),

                            TipoUsuario = new TipoUsuarioDomain
                            {
                                Titulo = rdr["Titulo"].ToString()
                            }

                        };
                        return user;
                    }
                    return null;
                }
            }
        }
    }
}
