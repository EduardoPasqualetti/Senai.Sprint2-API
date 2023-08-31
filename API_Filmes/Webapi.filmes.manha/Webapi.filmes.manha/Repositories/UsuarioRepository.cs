using System.Data.SqlClient;
using Webapi.filmes.manha.Domains;
using Webapi.filmes.manha.Interface;

namespace Webapi.filmes.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = NOTE16-S14 ; Initial Catalog = Filmes_Manha; User Id = sa; Pwd = Senai@134";


        UsuarioDomain IUsuarioRepository.Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryLogin = "SELECT Email, Senha, Permissao FROM Usuario WHERE Email = @email AND Senha = @senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain user = new UsuarioDomain()
                        {
                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            Permissao = rdr["Permissao"].ToString()
                        };
                        return user;
                    }
                    return null;
                }
            }
        }
    }
}
