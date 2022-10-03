using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace Athena
{
    public partial class cadastrarCliente : Form
    {
        bridge cn = new bridge();
        public cadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrarC_Click(object sender, EventArgs e)
        {
            int vf = 0, tel2 = 0;

            if (String.IsNullOrEmpty(this.txtPNomeC.Text))
            {
                this.txtPNomeC.BackColor = Color.Maroon;
                vf = 1;
            }

            if (String.IsNullOrEmpty(this.txtUNomeC.Text))
            {
                this.txtUNomeC.BackColor = Color.Maroon;
                vf = 1;
            }

            if (String.IsNullOrEmpty(this.txtTel1C.Text))
            {
                this.txtTel1C.BackColor = Color.Maroon;
                vf = 1;
            }
            if (String.IsNullOrEmpty(this.txtContrato.Text))
            {
                this.txtContrato.BackColor = Color.Maroon;
                vf = 1;
            }

            if (!String.IsNullOrEmpty(this.txtTel2C.Text))
            {
                if (int.TryParse(this.txtTel2C.Text, out tel2))
                    tel2 = int.Parse(this.txtTel2C.Text);
                else
                {
                    vf = 1;
                    this.txtTel2C.BackColor = Color.Maroon;
                }
            }

            if (vf != 1)
                try
                {
                    if (cn.cn().State == ConnectionState.Closed)
                        cn.cn().Open();
                    MySqlCommand cm = new MySqlCommand("INSERT INTO CLIENTES VALUES (DEFAULT, '" + this.txtPNomeC.Text + "', '" + this.txtUNomeC.Text + "','" +
                        this.cbSexoC.SelectedItem.ToString() + "', '" + this.txtDocumento.Text + "', '" + this.txtTel1C.Text + "', '" +
                        tel2 + "', '" + this.txtEmailC.Text + "', '" + this.txtBairro.Text + "', '" + this.txtRua.Text + "', '" + this.ndCasa.Value + "', '" + dtContrato.Value.ToString("yyyy-MM-dd") + "')", cn.cn());
                    if (cm.ExecuteNonQuery() != 0)
                    {
                        int id_cl = 0;
                        cm = new MySqlCommand("SELECT * FROM CLIENTES WHERE PRIMEIRO_NOME LIKE '" + this.txtPNomeC.Text + "' AND ULTIMO_NOME LIKE '" + this.txtUNomeC.Text + "'", cn.cn());
                        MySqlDataReader dr = cm.ExecuteReader();
                        if (dr.Read())
                            id_cl = int.Parse(dr["ID_CL"].ToString());
                        dr.Close();
                        if (id_cl != 0)
                        {
                            cm = new MySqlCommand("INSERT INTO CONTRATOS VALUES(DEFAULT, '" + this.txtContrato.Text + "', '" + this.dtContrato.Value.ToString("yyyy-MM-dd") + "', '" + id_cl +"')", cn.cn());
                            if (cm.ExecuteNonQuery() != 0)
                                MessageBox.Show("Contrato Salvo!", "Abertura de Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Possível erro na conexão com o servidor!", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.cadastrarCliente_Load(sender, e);
                    cn.cn().Close();
                }
        }

        private void txtPNomeC_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtPNomeC.Text))
                this.txtPNomeC.BackColor = Color.White;
        }

        private void txtUNomeC_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtUNomeC.Text))
                this.txtUNomeC.BackColor = Color.White;
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtDocumento.Text))
                this.txtDocumento.BackColor = Color.White;
        }

        private void txtTel1C_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtTel1C.Text))
                this.txtTel1C.BackColor = Color.White;
        }

        private void txtContrato_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtContrato.Text))
                this.txtContrato.BackColor = Color.White;
        }

        private void cadastrarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                MySqlCommand cm = new MySqlCommand("SELECT MAX(ID_CONT) AS MXC FROM CONTRATOS", cn.cn());
                MySqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                    this.txtContrato.Text = DateTime.Now.ToString("yyyy") + "" + DateTime.Now.ToString("MM") + "/" + ((int.Parse(dr["MXC"].ToString())) + 1).ToString();
                dr.Close();
                string str = "SELECT primeiro_nome, ultimo_nome, sexo, bairro, rua, casa, tel1, tel2, email, data_registo as cadastro, documento, contrato_numero as contrato FROM CLIENTES AS CL INNER JOIN CONTRATOS AS CT ON CT.CLIENTE = CL.ID_CL";
                this.clientesBindingSource.DataSource = cn.cn().Query<clientes>(str, commandType: CommandType.Text);
                this.dgCliente.Refresh();
            }
            finally
            {
                cn.cn().Close();
            }
        }
    }
}
