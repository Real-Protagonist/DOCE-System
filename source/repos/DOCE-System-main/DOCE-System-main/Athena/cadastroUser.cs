using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Athena
{
    public partial class cadastroUser : Form
    {
        bridge cn = new bridge();
        public cadastroUser()
        {
            InitializeComponent();
        }

        private void cadastroUser_Load(object sender, EventArgs e)
        {
            this.cbFuncionario.Items.Add("SELECIONE UM FUNCIONÁRIO");
            int maxID = 0;

            if (cn.cn().State == ConnectionState.Closed)
                cn.cn().Open();
            MySqlCommand cm = new MySqlCommand("SELECT MAX(ID_FUNC) AS IDF FROM FUNCIONARIOS", cn.cn());
            MySqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
                maxID = int.Parse(dr["IDF"].ToString());
            dr.Close();

            if (maxID > 0)
            {
                for (int i = 1; i <= maxID; i++)
                {
                    cm = new MySqlCommand("SELECT * FROM FUNCIONARIOS WHERE ID_FUNC = '" + i +"'", cn.cn());
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                        this.cbFuncionario.Items.Add(dr["PRIMEIRO_NOME"].ToString() + " " + dr["ULTIMO_NOME"].ToString());
                    dr.Close();
                }
            }
            cn.cn().Close();
            this.cbFuncionario.SelectedIndex = 0;
        }
        public string getHash(string text)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] bt = sh.Hash;
            StringBuilder stb = new StringBuilder();
            foreach (byte btt in bt)
                stb.Append(btt.ToString("X2"));
            return stb.ToString();
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            int vf = 0;

            if (this.cbFuncionario.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione o funcionário.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }else if (String.IsNullOrEmpty(this.txtNome.Text))
            {
                MessageBox.Show("Introduza o Nome de Usuário.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            else if (String.IsNullOrEmpty(this.txtSenha.Text))
            {
                MessageBox.Show("Introduza uma senha para a conta.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            else if (String.IsNullOrEmpty(this.txtVSenha.Text))
            {
                MessageBox.Show("Verifique a senha introduzida anteriormente.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            else if (this.txtSenha.Text != this.txtVSenha.Text)
            {
                MessageBox.Show("As senha não coincidem.", "Verificação de Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vf = 1;
            }

            if (vf != 1)
                try
                {
                    if (cn.cn().State == ConnectionState.Closed)
                        cn.cn().Open();
                    MySqlCommand mc = new MySqlCommand("INSERT INTO USUARIOS VALUES (default,'" + this.txtNome.Text + "', '" + 
                        this.getHash(this.txtSenha.Text) + "', 1, 0, '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + this.cbFuncionario.SelectedIndex + "')", cn.cn());
                    if (mc.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Usuário Cadastrado com sucesso!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtNome.Clear();
                        this.txtSenha.Clear();
                        this.txtVSenha.Clear();
                        //this.lblSuccess.Visible = true;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Possível erro na conexao com o banco de dados." + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.cn().State == ConnectionState.Open)
                        cn.cn().Close();
                }
        }
    }
}
