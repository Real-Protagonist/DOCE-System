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
using System.Globalization;

namespace Athena
{
    public partial class pagamentosServicos : Form
    {
        bridge cn = new bridge();
        public pagamentosServicos()
        {
            InitializeComponent();
        }

        NumberFormatInfo m = new CultureInfo("en-US").NumberFormat;
        CultureInfo df = new CultureInfo("en-US");

        private void pagamentosServicos_Load(object sender, EventArgs e)
        {
            df.NumberFormat.NumberGroupSeparator = "";
            this.txtSubtotal.Text = "0,00";
            this.txtMulta.Text = "0,00";
            this.txtDesconto.Text = "0,00";
            this.txtTroco.Text = "0,00";

            //MessageBox.Show(double.Parse(this.txtSubtotal.Text).ToString("N2", df));

            this.txtTotal.Text = "0,00";
            this.dtPagamento.Value = DateTime.Now;
            this.dtRegisto.Value = DateTime.Now;

            this.cbFPagamento.SelectedIndex = 3;
            this.cbMes.SelectedIndex = 0;
            this.cbServico.SelectedIndex = 0;
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCliente.Text))
                try
                {
                    if (cn.cn().State == ConnectionState.Closed)
                        cn.cn().Open();
                    string str = "SELECT primeiro_nome, ultimo_nome, contrato_numero as contrato, documento, bairro, rua, casa FROM CLIENTES AS CL INNER JOIN CONTRATOS AS CT ON CT.CLIENTE = CL.ID_CL WHERE CL.PRIMEIRO_NOME LIKE '%" + this.txtCliente.Text + "%' OR CL.ULTIMO_NOME LIKE '%" + this.txtCliente.Text + "%' OR CT.CONTRATO_NUMERO LIKE '" + this.txtCliente.Text + "%'";
                    this.clientesBindingSource.DataSource = cn.cn().Query<clientes>(str, commandType: CommandType.Text);
                    this.dgCliente.Refresh();
                }
                catch
                {
                    MessageBox.Show("Possível erro na conexão com o banco de dados.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    cn.cn().Close();
                }
            else
            {
                this.dgCliente.Rows.Clear();
                this.txtContrato.Clear();
            }
        }

        private void dgCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtContrato.Text = (this.dgCliente.CurrentRow.Cells[0].Value.ToString());

            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                string str = "SELECT mes, descricao as servico, observacao, data_pagamento, data_registo FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON CT.ID_CONT = PG.CONTRATO WHERE CT.CONTRATO_NUMERO = '" + this.txtContrato.Text + "'";
                this.clientesBindingSource.DataSource = cn.cn().Query<clientes>(str, commandType: CommandType.Text);
                this.dgSPagos.Refresh();
            }
            finally
            {
                cn.cn().Close();
            }
        }

        private void cbServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbServico.SelectedIndex == 1)
            {
                this.txtMulta.Enabled = true;
                this.cbMes.Enabled = true;
            }
            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                MySqlCommand cm = new MySqlCommand("SELECT * FROM SERVICOS_PAGAMENTO WHERE ID_SERVICO = '" + (this.cbServico.SelectedIndex + 1) + "'", cn.cn());
                MySqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                    this.txtValorPagar.Text = dr["VALOR_PAGAR"].ToString();
                dr.Close();
            }
            finally
            {
                cn.cn().Close();
            }
        }

        private void txtValorPagar_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtValorPagar.Text))
            {
                this.txtSubtotal.Text = double.Parse(this.txtValorPagar.Text).ToString("N2", df);
                this.txtTotal.Text = double.Parse(this.txtValorPagar.Text).ToString("N2", df);
            }
            else
            {
                this.txtSubtotal.Text = double.Parse("0").ToString("N2", df);
                this.txtTotal.Text = double.Parse("0").ToString("N2", df);
            }
        }

        private void txtMulta_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtMulta.Text))
            {
                String mv = (double.Parse(this.txtMulta.Text)).ToString("N2", df);
                this.txtTotal.Text = (double.Parse(this.txtValorPagar.Text) + double.Parse(mv)).ToString("N2", df);
            }
        }
    }
}
