using System.Data.SqlClient;
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
        public void AtualizarIdCorpo(GeneroDomain Genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int Id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int Id)
        {
            throw new NotImplementedException();
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

        public void Deletar(int Id)
        {
            throw new NotImplementedException();
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
                using(SqlCommand cmd = new SqlCommand(QuerySelectAll, con)) 
                { 
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // se o rdr nao for nulo
                    while(rdr.Read()) 
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
