using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        private string conexao = "Data Source = NOTE16-S14 ; Initial Catalog = InLock_Manha; User Id = sa; Pwd = Senai@134";

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> ListaTipo =  new List<TipoUsuarioDomain>();

            using(SqlConnection con = new SqlConnection(conexao))
            {
                string QuerySelect = "SELECT * FROM TiposUsuario";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        ListaTipo.Add(tipoUsuario);
                    }
                }
            }
            return ListaTipo;
        }
    }
}
