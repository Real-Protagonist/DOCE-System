using MySql.Data.MySqlClient;
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

namespace Athena
{
    public partial class login : Form
    {
        bridge cn = new bridge();
        public login()
        {
            InitializeComponent();
        }

        public static int id;
        public static String usuario;

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
        private void btnEnter_Click(object sender, EventArgs e)
        {
            int vf = 0;
            if (String.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Introduza o nome de usuário.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }
            else if (String.IsNullOrEmpty(this.txtSenha.Text))
            {
                MessageBox.Show("Insira a senha de acesso.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vf = 1;
            }

            if (vf != 1)
                try
                {
                    if (cn.cn().State == ConnectionState.Closed)
                        cn.cn().Open();
                    MySqlCommand mc = new MySqlCommand("SELECT * FROM USUARIOS WHERE NOME_USUARIO LIKE '" + this.txtUsuario.Text + "' AND SENHA_USUARIO LIKE '" + this.getHash(this.txtSenha.Text) + "' AND ACTIVE = 1", cn.cn());
                    MySqlDataReader dr = mc.ExecuteReader();
                    if (dr.Read())
                    {
                        if (int.Parse(dr["ID_USER"].ToString()) != 0)
                        {
                            id = int.Parse(dr["ID_USER"].ToString());
                            usuario = dr["NOME_USUARIO"].ToString();
                            dr.Close();
                            mc = new MySqlCommand("UPDATE USUARIOS SET DATA_ATUALIZACAO = '"+DateTime.Now.ToString("yyyy-MM-dd")+"'", cn.cn());
                            mc.ExecuteNonQuery();
                            this.Hide();
                        }
                    }
                    else
                        MessageBox.Show("Nome ou Senha de usuário não existe.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dr.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Possível erro de conexão com o banco de dados." + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.cn().State == ConnectionState.Open)
                        cn.cn().Close();
                }
        }
        public void logout()
        {
            id = 0;
            usuario = "";
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Enter))
                this.btnEnter_Click(sender, e);
        }
    }
}
