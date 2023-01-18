using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios._2___Classes
{
    internal class ComandoLogin
    {
        public bool dadosExistentemNoBanco = false;
        public string mensagem = "";
        private SqlCommand cmd = new SqlCommand();
        private ConexaoSQL con = new ConexaoSQL();
        private SqlDataReader dr; //a variavel dr está armazenando informação;

        public bool VerificarLogin(String login, String senha)
        {
            cmd.CommandText = "SELECT * FROM  tb_Login WHERE log_login = @log_login and log_senha = @log_senha";
            cmd.Parameters.AddWithValue("@log_login", login);
            cmd.Parameters.AddWithValue("@log_senha", senha);

            try
            {
                cmd.Connection = con.ConectarBancoDados();
                dr = cmd.ExecuteReader(); //ExecuteReader é pra quando pega a informação do banco de dados para ser guardada.

                if (dr.HasRows) // se foi encontrado.
                {
                    dadosExistentemNoBanco = true;
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com o Banco de Dados!";
            }

            return dadosExistentemNoBanco;
        }
    }
}