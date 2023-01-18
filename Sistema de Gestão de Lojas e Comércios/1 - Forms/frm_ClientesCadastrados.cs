using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios._1___Forms
{
    public partial class frm_LocalizarClientes : Form
    {
        public frm_LocalizarClientes()
        {
            InitializeComponent();
            CarregarTabelaClientes();
        }

        private void btn_FercharJanela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarTabelaClientes()
        {
            using (SqlConnection cn = new SqlConnection(@"Data Source=ROBIINHO\SQLEXPRESS;Initial Catalog=SistemaGestão_LC;Persist Security Info=True;User ID=sa;Password=12345"))
            {
                var sqlQuery = "SELECT cad_cl_nome AS NOME,cad_cl_Cpf_Cnpj AS [CPF/CNPJ],cad_cl_Whatsapp  AS  WHATSAPP " +
                               " FROM tb_cad_Clientes ORDER BY id_cad_Cliente DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, cn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gdv_ClientesCadastrados.DataSource = dt;
            }
        }
    }
}