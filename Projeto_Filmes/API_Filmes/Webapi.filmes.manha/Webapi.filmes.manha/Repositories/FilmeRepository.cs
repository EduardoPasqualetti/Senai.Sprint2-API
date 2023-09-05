using System.Data.SqlClient;
using Webapi.filmes.manha.Domains;
using Webapi.filmes.manha.Interface;

namespace Webapi.filmes.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        /// <summary>
        /// string de conexao com o banco de dados que recebe os seguintes parametros:
        /// Data Source : Nome do Servidor
        /// Initial Catalog : Nome do Banco de Dados
        /// Autenticacao:
        ///     - Windows : Integrated Security = True
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>

        private string stringConexao = "Data Source = NOTE16-S14 ; Initial Catalog = Filmes_Manha; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpdate = "UPDATE Filmes SET Titulo = @novoNome, IdGenero = @novoGenero WHERE IdFilme = @IdFilme;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", filme.Titulo);
                    cmd.Parameters.AddWithValue("@novoGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpdate = "UPDATE Filmes SET Titulo = @novoNome, IdGenero = @novoGenero WHERE IdFilme = @IdFilme;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", filme.Titulo);
                    cmd.Parameters.AddWithValue("@novoGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@Idfilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string QueryBuscar = "SELECT Filmes.IdFilme, Filmes.IdGenero, Filmes.Titulo, Genero.Nome FROM Filmes LEFT JOIN Genero ON Genero.IdGenero = Filmes.IdGenero AND IdFilme =  @Idfilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@Idfilme", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                        return filmeBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryInsert = "INSERT INTO Filmes(IdGenero, Titulo) VALUES (@IdGenero,@Nome)";

                using(SqlCommand cmd = new SqlCommand(QueryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", novoFilme.Titulo); ;

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                  
            }

        }
    


        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryDelete = "DELETE FROM Filmes WHERE IdFilme = @id";

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QuerySelect = "SELECT IdFilme, Filmes.IdGenero, Filmes.Titulo, Genero.Nome from Filmes INNER JOIN Genero ON Filmes.IdGenero = Genero.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        ListaFilmes.Add(filme); 
                    }
                }
            }
            return ListaFilmes;
        
        }








    }
}

