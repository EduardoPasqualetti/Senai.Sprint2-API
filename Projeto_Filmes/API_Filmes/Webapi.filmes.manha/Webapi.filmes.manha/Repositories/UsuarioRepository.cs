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
                string QueryLogin = "SELECT IdUsuario, Email, Permissao FROM Usuario WHERE Email = @email AND Senha = @senha";

                con.Open();       

                using (SqlCommand cmd = new SqlCommand(QueryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain user = new UsuarioDomain()
                        {
                            IdUsuario= Convert.ToInt32(rdr["IdUsuario"]),

                            Email = rdr["Email"].ToString(),

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
