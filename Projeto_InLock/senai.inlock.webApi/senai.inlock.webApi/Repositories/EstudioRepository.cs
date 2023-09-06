using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string conexao = "Data Source = NOTE16-S14 ; Initial Catalog = InLock_Manha; User Id = sa; Pwd = Senai@134";


        public List<EstudioDomain> ListarTodos() 
        { 
            List<EstudioDomain> ListaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string QuerySelect = "SELECT * FROM Estudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        ListaEstudios.Add(estudio);
                    }
                    
                }
            }
            return ListaEstudios;
        }



        public void Cadastrar(EstudioDomain estudio)
        {
            using(SqlConnection con = new SqlConnection(conexao)) 
            {
                string QueryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

                using(SqlCommand cmd = new SqlCommand(QueryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
