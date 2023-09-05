using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using Webapi.filmes.manha.Domains;
using Webapi.filmes.manha.Interface;

namespace Webapi.filmes.manha.Repositories
{
    public class GeneroRepository : IGeneroRepository
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

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpdate = "UPDATE Genero SET Nome = @novoGenero WHERE IdGenero = @IdGenero;";

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@novoGenero", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string QueryUpdate = "UPDATE Genero SET Nome = @novoGenero WHERE IdGenero = @Idgenero;";

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Idgenero", id);
                    cmd.Parameters.AddWithValue("@novoGenero", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery(); 
                }
            }
        }


        /// <summary>
        /// Buscar um genero atraves do seu Id
        /// </summary>
        /// <param name="Id">Id do Genero</param>
        /// <returns>Objeto buscado ou null caso nao seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        { 

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string QueryBuscar = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero =  @IdGenero";
                
                con.Open();
                
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                     rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado  = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]) ,
                            Nome = rdr["Nome"].ToString(),
                        };
                        return generoBuscado;
                    }
                    return null;
                }
            }
            
        }


        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes que serao cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string QueryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";

                // Declara o SQlCommand passando a query que sera executada e a conexao
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    //Passa o valor do parametro @Nome 
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    // Abre a conexao com o banco de dados
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar um determinado Genero
        /// </summary>
        /// <param name="Id"> Id do genero a ser excluido</param>
        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string QueryDelete = "DELETE FROM Genero WHERE IdGenero =  @id ";

                // Declara o SQlCommand passando a query que sera executada e a conexao
                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    //Passa o valor do parametro @id
                    cmd.Parameters.AddWithValue("@id", Id);

                    // Abre a conexao com o banco de dados
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Listar todos os objetos Generos
        /// </summary>
        /// <returns> Lista de objetos(Generos) </returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista de objetos(ListaGeneros) do tipo genero 
            // Instancia
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrucao a ser executada 
                string QuerySelectAll = "SELECT IdGenero, Nome FROM Genero";

                // Abre a conexao com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                // essa variavel le as informacoes do banco de dados 
                SqlDataReader rdr;

                // Declara o SqlCommand passando a query que sera executado(QuerySelectAll) e a conexao com o banco(con)
                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // se o rdr nao for nulo
                    while (rdr.Read())
                    {
                        // instanciando
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),

                            // Atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()

                        };
                        // Adiciona cada objeto dentro da lista
                        ListaGeneros.Add(genero);
                    }
                }
            }
            // Retorna a lista concluida
            return ListaGeneros;
        }

    }
}