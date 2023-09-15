namespace inlock_CodeFirst.Utils
{
    public static class Criptografia
    {

        /// <summary>
        /// Gerar uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">senha que recebera a Hash</param>
        /// <returns>Senha criptografada com a Hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }



        /// <summary>
        /// Verificar se a hash informada e igual a hash salva no banco de dados
        /// </summary>
        /// <param name="senhaForm">Senha informada pelo usuario para comparar</param>
        /// <param name="senhaBanco">Senha cadastrada no banco de dados</param>
        /// <returns>True or False(se a senha existe ou nao no banco)</returns>
        public static bool CompararHash(string senhaForm,string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
