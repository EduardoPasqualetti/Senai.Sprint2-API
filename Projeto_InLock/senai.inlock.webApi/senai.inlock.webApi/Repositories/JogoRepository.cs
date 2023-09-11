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
                string QueryInsert = "INSERT INTO Jogo(IdEstudio,Titulo,Descricao,DataLancamento,Valor) VALUES(@IdEstudio,@Nome,@Descricao,@data,@valor)";

                
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Titulo);
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
                string QuerySelect = "SELECT Jogo.IdJogo, Jogo.IdEstudio, Jogo.Titulo, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor, Estudio.IdEstudio, Estudio.Nome  FROM Jogo INNER JOIN Estudio ON  Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            IdEstudio = Convert.ToInt32(rdr[1]),
                            Titulo = rdr["Titulo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = rdr["DataLancamento"].ToString(),
                            Valor = Convert.ToInt32(rdr["Valor"]),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr[0]),
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
