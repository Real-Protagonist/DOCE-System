using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Athena
{
    public partial class dadosEmpresa : Form
    {
        bridge cn = new bridge();
        public dadosEmpresa()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int vf = 0, tel1 = 0, tel2 = 0;
            if (String.IsNullOrEmpty(this.txtNome.Text))
            {
                MessageBox.Show("Introduza o nome da emprea.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            else if (String.IsNullOrEmpty(this.txtNif.Text))
            {
                MessageBox.Show("Informe o NIF da empresa.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            else if (String.IsNullOrEmpty(this.txtTel1.Text))
            {
                MessageBox.Show("Informe o contacto principal da empresa.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            else if (int.TryParse(this.txtTel1.Text, out tel1))
                tel1 = int.Parse(this.txtTel1.Text);
            else
            {
                MessageBox.Show("O número introduzido não é válido.", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            if (!String.IsNullOrEmpty(this.txtTel2.Text))
                if (int.TryParse(this.txtTel2.Text, out tel2))
                    tel2 = int.Parse(this.txtTel2.Text);
                else
                {
                    MessageBox.Show("O número introduzido não é válido (Tel2).", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    vf = 1;
                }

            if (vf != 1)
                try
                {
                    if (cn.cn().State == ConnectionState.Closed)
                        cn.cn().Open();
                    MySqlCommand cm = new MySqlCommand("UPDATE EMPRESA SET NOME = '" + this.txtNome.Text + "', NIF = '" + this.txtNif.Text + "', ENDERCO = '" + 
                        this.txtEndereco.Text + "', TEL1 = '" + tel1 + "', TEL2 = '" + tel2 + "', EMAIL = '" + this.txtEmail.Text + "'", cn.cn());
                    if (cm.ExecuteNonQuery() != 0)
                        MessageBox.Show("Os dados foram atualizados com sucesso!", "Atualização de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Possível erro na conexão com o Servidor de Banco de Dados", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.cn().Close();
                }
        }

        private void dadosEmpresa_Load(object sender, EventArgs e)
        {
            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                MySqlCommand cm = new MySqlCommand("SELECT * FROM EMPRESA", cn.cn());
                MySqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    this.txtNome.Text       = dr["NOME"].ToString();
                    this.txtNif.Text        = dr["NIF"].ToString();
                    this.txtEndereco.Text   = dr["ENDERCO"].ToString();
                    this.txtEmail.Text      = dr["EMAIL"].ToString();
                    this.txtTel1.Text       = dr["TEL1"].ToString();
                    this.txtTel2.Text       = dr["TEL2"].ToString();
                }
                dr.Close();
            }
            finally
            {
                cn.cn().Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
