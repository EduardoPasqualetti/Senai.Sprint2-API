using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string conexao = "Data Source = NOTE16-S14 ; Initial Catalog = InLock_Manha; User Id = sa; Pwd = Senai@134";

        public void Cadastrar(JogoDomain jogo)
        {
            using(SqlConnection con = new SqlConnection(conexao))
            {
                string QueryInsert = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor) VALUES(@IdEstudio,@Nome,@Descricao,@data,@valor)";

                
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@data", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogo = new List<JogoDomain>();

            using(SqlConnection con = new SqlConnection(conexao))
            {
                string QuerySelect = "SELECT IdJogo, Jogo.IdEstudio, Jogo.Nome, Estudio.Nome as Estudio, Descricao, DataLancamento, Valor FROM Jogo JOIN Estudio ON Estudio.IdEstudio = Jogo.IdEstudio ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = rdr["DataLancamento"].ToString(),
                            Valor = Convert.ToInt32(rdr["Valor"]),

                            Estudio = new EstudioDomain()
                            {
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                        ListaJogo.Add(jogo);
                    }
                }
            }
            return ListaJogo;
        }
    }
}
