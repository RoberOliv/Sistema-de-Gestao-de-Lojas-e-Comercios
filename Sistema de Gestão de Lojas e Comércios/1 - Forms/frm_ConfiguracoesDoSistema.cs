using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios._1___Forms
{
    public partial class frm_ConfiguracoesDoSistema : Form
    {
        public frm_ConfiguracoesDoSistema()
        {
            InitializeComponent();
        }

        private void btn_FercharJanela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}