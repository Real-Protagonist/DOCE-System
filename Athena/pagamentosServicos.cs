﻿using System;
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
                valor_p = float.Parse(this.txtValorPagar.Text);
            }
            else
            {
                this.txtSubtotal.Text = double.Parse("0").ToString("N2", df);
                this.txtTotal.Text = double.Parse("0").ToString("N2", df);
                valor_p = 0;
            }
            this.txtMulta_TextChanged(sender, e);
        }

        private float valor_p;
        private float valor_multa;
        private float mv;
        private float sm;
        private void txtMulta_TextChanged(object sender, EventArgs e)
        {
            float mp = valor_p;
            if (!String.IsNullOrEmpty(this.txtMulta.Text))
                mv = (float.Parse(this.txtMulta.Text));
            else
                mv = 0;

            sm = (mv + mp);
            this.txtTotal.Text = (sm).ToString("N2", df);
        }

        private float valor_enter;
        private float smt;
        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtValorPago.Text))
                valor_enter = float.Parse(this.txtValorPago.Text);
            else
                valor_enter = 0;
            smt = float.Parse(this.txtTotal.Text);
            float totTc = valor_enter - smt;
            this.txtTroco.Text = totTc.ToString();
        }

        private float desc;
        private float smtd;
        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtDesconto.Text))
                desc = float.Parse(this.txtDesconto.Text);
            else
                desc = 0;

            float totT = float.Parse(this.txtTotal.Text);
            smtd = (valor_p + mv) - desc;
            this.txtTotal.Text = smtd.ToString("N2", df);
        }
    }
}
