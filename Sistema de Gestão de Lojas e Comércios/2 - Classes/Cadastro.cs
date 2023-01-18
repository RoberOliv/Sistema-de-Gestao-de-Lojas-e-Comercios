using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.BunifuCheckBox.Transitions;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios._2___Classes
{
    internal class Cadastro
    {
        private ConexaoSQL conexao = new ConexaoSQL();
        public string mensagem;

        #region CadastroClientes

        public Cadastro(string cad_cl_Nome, string cad_cl_Cpf_Cnpj, string cad_cl_Cep, string cad_cl_RG, string cad_cl_Emissor, int cad_cl_Numero, string cad_cl_Endereco,
                           DateTime cad_cl_dat_Nascimento, string cad_cl_Complemento, string cad_cl_Bairro, string cad_cl_Cidade, string cad_cl_UF, string cad_cl_Profissao, string cad_cl_tel_Fixo, string cad_cl_Whatsapp,
                            string cad_cl_Celular, string cad_cl_Email, decimal cad_cl_lmt_Credito, bool cad_cl_compra_Prazo, Image fotoCliente)
        {
            //cmd.CommandText =
            try
            {
                using (SqlConnection conexaosql = conexao.ConectarBancoDados())
                {
                    string Query =
                        "insert into tb_Cad_Clientes(cad_cl_Nome, cad_cl_Cpf_Cnpj,cad_cl_Cep,cad_cl_RG,cad_cl_Emissor,cad_cl_Numero,cad_cl_Endereco,cad_cl_dat_Nascimento,cad_cl_Complemento,cad_cl_Bairro,cad_cl_Cidade,cad_cl_UF," +
                        "cad_cl_Profissao,cad_cl_tel_Fixo,cad_cl_Whatsapp,cad_cl_Celular,cad_cl_Email,cad_cl_compra_Prazo,cad_cl_lmt_Credito,fotoCliente)" +
                        " values (@cad_cl_Nome,@cad_cl_Cpf_Cnpj,@cad_cl_Cep,@cad_cl_RG,@cad_cl_Emissor,@cad_cl_Numero,@cad_cl_Endereco,@cad_cl_dat_Nascimento,@cad_cl_Complemento,@cad_cl_Bairro,@cad_cl_Cidade,@cad_cl_UF,@cad_cl_Profissao," +
                        "@cad_cl_tel_Fixo,@cad_cl_Whatsapp,@cad_cl_Celular,@cad_cl_Email,@cad_cl_compra_Prazo,@cad_cl_lmt_Credito,@fotoCliente)";

                    SqlDataAdapter adapter = new SqlDataAdapter(Query, conexaosql);

                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Nome", cad_cl_Nome);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Cpf_Cnpj", cad_cl_Cpf_Cnpj);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Cep", cad_cl_Cep);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_RG", cad_cl_RG);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Emissor", cad_cl_Emissor);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Numero", cad_cl_Numero);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Endereco", cad_cl_Endereco);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_dat_Nascimento", cad_cl_dat_Nascimento);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Complemento", cad_cl_Complemento);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Bairro", cad_cl_Bairro);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Cidade", cad_cl_Cidade);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_UF", cad_cl_UF);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Profissao", cad_cl_Profissao);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_tel_Fixo", cad_cl_tel_Fixo);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Whatsapp", cad_cl_Whatsapp);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Celular", cad_cl_Celular);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_Email", cad_cl_Email);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_lmt_Credito", cad_cl_lmt_Credito);
                    adapter.SelectCommand.Parameters.AddWithValue("@cad_cl_compra_Prazo", cad_cl_compra_Prazo);

                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(fotoCliente, typeof(byte[]));
                    adapter.SelectCommand.Parameters.AddWithValue("@fotoCliente", arr);

                    adapter.SelectCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                this.mensagem = $"{e}";
            }
        }

        #endregion CadastroClientes
    }
}