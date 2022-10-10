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
using Dapper;

namespace Athena
{
    public partial class cadastroFuncionarios : Form
    {
        bridge cn = new bridge();
        public cadastroFuncionarios()
        {
            InitializeComponent();
        }

        private void cadastroFuncionarios_Load(object sender, EventArgs e)
        {
            this.dtCadastro.Value = DateTime.Now;
            this.dtNascimento.Value = DateTime.Now;

            this.cbSexo.SelectedIndex = 0;

            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                string str = "SELECT primeiro_nome, ultimo_nome, sexo, bairro, rua, casa, tel1, tel2, email, funcao, data_nascimento, data_registo as data_cadastro FROM FUNCIONARIOS";
                this.funcionariosBindingSource.DataSource = cn.cn().Query<funcionarios>(str, commandType: CommandType.Text);
                this.dgFuncionarios.Refresh();
            }
            finally
            {
                cn.cn().Close();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int vf = 0, tel2 = 0;
            if (String.IsNullOrEmpty(this.txtPNome.Text))
            {
                this.txtPNome.BackColor = Color.Maroon;
                vf = 1;
            }

            if (String.IsNullOrEmpty(this.txtUNome.Text))
            {
                this.txtUNome.BackColor = Color.Maroon;
                vf = 1;
            }

            if (String.IsNullOrEmpty(this.txtTel1.Text))
            {
                this.txtTel1.BackColor = Color.Maroon;
                vf = 1;
            }

            if (String.IsNullOrEmpty(this.txtFuncao.Text))
            {
                this.txtFuncao.BackColor = Color.Maroon;
                vf = 1;
            }

            if (!String.IsNullOrEmpty(this.txtTel2.Text))
            {
                if (int.TryParse(this.txtTel2.Text, out tel2))
                    tel2 = int.Parse(this.txtTel2.Text);
                else
                {
                    vf = 1;
                    this.txtTel2.BackColor = Color.Maroon;
                }
            }

            if (vf != 1)
            {
                try
                {
                    if (cn.cn().State == ConnectionState.Closed)
                        cn.cn().Open();
                    MySqlCommand cm = new MySqlCommand("INSERT INTO FUNCIONARIOS VALUES (DEFAULT, '" + this.txtPNome.Text + "', '" + this.txtUNome.Text + "','" +
                        this.cbSexo.SelectedItem.ToString() + "', '" + this.txtDoc.Text + "', '" + this.dtNascimento.Value.ToString("yyyy-MM-dd") + "', '" + this.txtTel1.Text + "', '" +
                        tel2 + "', '" + this.txtEmail.Text + "', '" + this.txtBairro.Text + "', '" + this.txtRua.Text + "', '" + this.ndCasa.Value + "', '" + 
                        this.txtFuncao.Text + "', '"+ dtCadastro.Value.ToString("yyyy-MM-dd") +"')", cn.cn());
                    if (cm.ExecuteNonQuery() != 0)
                        MessageBox.Show("Funcionário Cadastrado!");
                }
                catch
                {
                    MessageBox.Show("Possível erro na conexão com o servidor!", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    string str = "SELECT primeiro_nome, ultimo_nome, sexo, bairro, rua, casa, tel1, tel2, email, funcao, data_nascimento, data_registo as data_cadastro FROM FUNCIONARIOS";
                    this.funcionariosBindingSource.DataSource = cn.cn().Query<funcionarios>(str, commandType: CommandType.Text);
                    this.dgFuncionarios.Refresh();
                    cn.cn().Close();
                }
            }
        }

        private void txtPNome_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPNome_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtPNome.Text))
                this.txtPNome.BackColor = Color.White;
        }

        private void txtUNome_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtUNome.Text))
                this.txtUNome.BackColor = Color.White;
        }

        private void txtTel1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtTel1.Text))
                this.txtTel1.BackColor = Color.White;
        }

        private void txtFuncao_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtFuncao.Text))
                this.txtFuncao.BackColor = Color.White;
        }
    }
}
