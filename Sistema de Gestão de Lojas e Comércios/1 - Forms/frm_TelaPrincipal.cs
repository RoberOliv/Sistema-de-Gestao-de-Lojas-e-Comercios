using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Gestão_de_Lojas_e_Comércios._1___Forms;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios
{
    public partial class frm_TelaPrincipal : Form
    {
        public frm_TelaPrincipal()
        {
            InitializeComponent();
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ConfiguracoesDoSistema abrirConfiguracoesDoSistema = new frm_ConfiguracoesDoSistema();
            abrirConfiguracoesDoSistema.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CadastrosClientes abrirCadastrosClientes = new frm_CadastrosClientes();
            abrirCadastrosClientes.ShowDialog();
        }
    }
}