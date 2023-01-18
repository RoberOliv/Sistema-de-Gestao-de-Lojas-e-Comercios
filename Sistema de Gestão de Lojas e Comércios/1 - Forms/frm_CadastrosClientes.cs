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
using Correios;
using DevExpress.DataAccess.ConnectionParameters;
using Sistema_de_Gestão_de_Lojas_e_Comércios._2___Classes;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios._1___Forms
{
    public partial class frm_CadastrosClientes : Form
    {
        public frm_CadastrosClientes()
        {
            InitializeComponent();
        }

        private void btn_AbrirWebcam_Click(object sender, EventArgs e)
        {
            frm_CapturarImagemWebcam abrirCapturarImagemWebcam = new frm_CapturarImagemWebcam();
            abrirCapturarImagemWebcam.ShowDialog();
        }

        private void btn_FercharJanela_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair da aplicação?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btn_ConsultarCep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CEP.Text))
            {
                MessageBox.Show("O campo de CEP está vazio", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    CorreiosApi correiosApi = new CorreiosApi();
                    var retornoDadosCep = correiosApi.consultaCEP(txt_CEP.Text);

                    if (retornoDadosCep is null)
                    {
                        MessageBox.Show("CEP não encontrado", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    txt_Bairro.Text = retornoDadosCep.bairro;
                    txt_Cidade.Text = retornoDadosCep.cidade;
                    txt_Endereco.Text = retornoDadosCep.end;
                    txt_Complemento.Text = retornoDadosCep.complemento;
                    cmb_UF.Text = retornoDadosCep.uf;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao consultar o CEP: " + erro.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_SelecionarFotoCliente_Click(object sender, EventArgs e)
        {
            OpenFileDialog newImage = new OpenFileDialog();
            newImage.Title = "Open Image";
            newImage.Filter = "Image Files (*.JPG;*.PNG;*.GIF) | *.JPG;*.PNG;*.GIF ";

            if (newImage.ShowDialog() == DialogResult.OK)
            {
                pct_ImagemCliente.Image = Image.FromFile(newImage.FileName);
            }
        }

        private void btn_NovoCadastro_Click(object sender, EventArgs e)
        {
            AtivarCamposCadastro();
        }

        private void AtivarCamposCadastro()
        {
            btn_AbrirWebcam.Enabled = true;
            btn_ConsultarCep.Enabled = true;
            btn_SelecionarFotoCliente.Enabled = true;
            pct_ImagemCliente.Enabled = true;
            btn_ExcluirCadastro.Enabled = true;
            btn_SalvarCadastro.Enabled = true;
            txt_TelefoneFixo.Enabled = true;
            cmb_UF.Enabled = true;
            dtp_DataNascimento.Enabled = true;
            txt_CodigoCadastro.Enabled = false;
        }

        private void btn_SalvarCadastro_Click(object sender, EventArgs e)
        {
            Cadastro cadClientes = new Cadastro(txt_NomeCliente.Text, txt_CPF.Text,
                txt_CEP.Text, txt_RG.Text, txt_OrgaoEmissor.Text, Convert.ToInt32(txt_NumeroResidencia.Text), txt_Endereco.Text,
               Convert.ToDateTime(dtp_DataNascimento.Text), txt_Complemento.Text, txt_Bairro.Text, txt_Cidade.Text, cmb_UF.Text,
                txt_Profissao.Text, txt_TelefoneFixo.Text, txt_Whatsapp.Text, txt_Celular.Text, txt_Email.Text, Convert.ToDecimal(txt_LimiteCredito.Text), chk_AutorizacaoCompraPrazo.Checked, pct_ImagemCliente.Image);
            MessageBox.Show(cadClientes.mensagem);
        }

        private void btn_ExcluirCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=ROBIINHO\SQLEXPRESS;Initial Catalog=SistemaGestão_LC;Persist Security Info=True;User ID=sa;Password=12345"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("delete from tb_cad_Clientes where id_cad_Cliente = ?", connection);
                    command.Parameters.Clear();
                    command.Parameters.Add("@id_cad_Cliente", SqlDbType.Int).Value = txt_CodigoCadastro.Text;

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Registro removido com sucesso");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel deletar:" + erro);
            }
        }

        private void btn_LocalizarClientesCadastrados_Click(object sender, EventArgs e)
        {
            frm_LocalizarClientes localizar = new frm_LocalizarClientes();
            localizar.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
    }
}