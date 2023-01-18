using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios._2___Classes
{
    internal class ConexaoSQL
    {
        private SqlConnection con = new SqlConnection();

        public ConexaoSQL()
        {
            con.ConnectionString = @"Data Source=ROBIINHO\SQLEXPRESS;Initial Catalog=SistemaGestão_LC;Persist Security Info=True;User ID=sa;Password=12345";
        }

        public SqlConnection ConectarBancoDados()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void DesconectarBancoDados()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}