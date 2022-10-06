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

            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                string str = "SELECT ID_CONT as idCont, primeiro_nome, ultimo_nome, contrato_numero as contrato, documento, bairro, rua, casa FROM CLIENTES AS CL INNER JOIN CONTRATOS AS CT ON CT.CLIENTE = CL.ID_CL";
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
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCliente.Text))
                try
                {
                    if (cn.cn().State == ConnectionState.Closed)
                        cn.cn().Open();
                    string str = "SELECT ID_CONT as idCont, primeiro_nome, ultimo_nome, contrato_numero as contrato, documento, bairro, rua, casa FROM CLIENTES AS CL INNER JOIN CONTRATOS AS CT ON CT.CLIENTE = CL.ID_CL WHERE CL.PRIMEIRO_NOME LIKE '%" + this.txtCliente.Text + "%' OR CL.ULTIMO_NOME LIKE '%" + this.txtCliente.Text + "%' OR CT.CONTRATO_NUMERO LIKE '" + this.txtCliente.Text + "%'";
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

        private int idCont;
        private void dgCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtContrato.Text = (this.dgCliente.CurrentRow.Cells[1].Value.ToString());
            idCont = int.Parse(this.dgCliente.CurrentRow.Cells[0].Value.ToString());

            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                string str = "SELECT mes, descricao as servico, observacao, data_pagamento, data_registo FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON CT.ID_CONT = PG.CONTRATO WHERE CT.CONTRATO_NUMERO = '" + this.txtContrato.Text + "'";
                this.pagamentosBindingSource.DataSource = cn.cn().Query<pagamentos>(str, commandType: CommandType.Text);

                this.fill_debt();
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
                this.txtValorPagar.Enabled = false;
            }
            else
            {
                this.txtMulta.Enabled = false;
                this.cbMes.Enabled = false;
                this.txtValorPagar.Enabled = false;
            }
            if (this.cbServico.SelectedIndex == 2)
                this.txtValorPagar.Enabled = true;
            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                MySqlCommand cm = new MySqlCommand("SELECT * FROM SERVICOS_PAGAMENTO WHERE ID_SERVICO = '" + (this.cbServico.SelectedIndex + 1) + "'", cn.cn());
                MySqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                    this.txtValorPagar.Text = dr["VALOR"].ToString();
                else
                    this.txtValorPagar.Text = "0";
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
        private float totTt;
        private void txtMulta_TextChanged(object sender, EventArgs e)
        {
            float mp = valor_p;
            if (!String.IsNullOrEmpty(this.txtMulta.Text))
                mv = (float.Parse(this.txtMulta.Text));
            else
                mv = 0;

            sm = (mv + mp) - desc;
            totTt = sm;
            this.txtTotal.Text = (sm).ToString("N2", df);
        }

        private float valor_enter;
        private float smt;
        private float totTc;
        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtValorPago.Text))
                valor_enter = float.Parse(this.txtValorPago.Text);
            else
                valor_enter = 0;

            totTc = valor_enter - totTt;
            this.txtTroco.Text = totTc.ToString("N2", df);
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
            totTt = smtd;
            this.txtTotal.Text = smtd.ToString("N2", df);
        }

        private MySqlCommand cm;
        private MySqlDataReader dr;
        private void btnCadastrarC_Click(object sender, EventArgs e)
        {
            float pars = 0;
            if (!String.IsNullOrEmpty(this.txtContrato.Text))
                if (!String.IsNullOrEmpty(this.txtValorPagar.Text))
                    if (float.TryParse(this.txtValorPagar.Text, out pars))
                        if (!String.IsNullOrEmpty(this.txtValorPago.Text))
                            try
                            {
                                if (cn.cn().State == ConnectionState.Closed)
                                    cn.cn().Open();
                                if (this.cbServico.SelectedIndex == 0)
                                {
                                    cm = new MySqlCommand("SELECT * FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON PG.CONTRATO = CT.ID_CONT WHERE PG.DESCRICAO LIKE '" + this.cbServico.SelectedItem.ToString() + "' AND CT.CONTRATO_NUMERO = '" + this.txtContrato.Text + "'", cn.cn());
                                    dr = cm.ExecuteReader();
                                    if (dr.Read())
                                        MessageBox.Show("O contrato já feito pago.", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    else
                                    {
                                        dr.Close();

                                        cm = new MySqlCommand("INSERT INTO PAGAMENTOS (DESCRICAO, VALOR_PAGAR, MULTA, DESCONTO, VALOR_ENTREGUE, TROCO, DATA_PAGAMENTO, DATA_REGISTO, OBSERVACAO, CONTRATO, FUNCIONARIO) VALUES ('" +
                                            this.cbServico.SelectedItem.ToString() + "', '" + float.Parse(this.txtValorPagar.Text) + "', '" + float.Parse(this.txtMulta.Text) + "', '" +
                                            float.Parse(this.txtDesconto.Text) + "', '" + float.Parse(this.txtValorPago.Text) + "', '" + this.totTc + "', '" +
                                            this.dtPagamento.Value.ToString("yyyy-MM-dd") + "', '" + this.dtRegisto.Value.ToString("yyyy-MM-dd") + "', '" + this.rtxtObs.Text + "', '" + idCont + "', '" + login.id + "')", cn.cn());
                                        if (cm.ExecuteNonQuery() != 0)
                                        {
                                            MessageBox.Show("Serviço Pago Com Successo!", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            string str = "SELECT mes, descricao as servico, observacao, data_pagamento, data_registo FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON CT.ID_CONT = PG.CONTRATO WHERE CT.CONTRATO_NUMERO = '" + this.txtContrato.Text + "'";
                                            this.pagamentosBindingSource.DataSource = cn.cn().Query<pagamentos>(str, commandType: CommandType.Text);
                                            this.dgSPagos.Refresh();
                                        }
                                    }
                                    dr.Close();
                                }

                                if (this.cbServico.SelectedIndex == 1)
                                {
                                    cm = new MySqlCommand("SELECT * FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON PG.CONTRATO = CT.ID_CONT WHERE PG.MES LIKE '" + this.cbMes.SelectedItem.ToString() + "' AND CT.CONTRATO_NUMERO = '" + this.txtContrato.Text + "' AND PG.DATA_PAGAMENTO LIKE '%" + this.dtPagamento.Value.ToString("yyyy") + "%'", cn.cn());
                                    dr = cm.ExecuteReader();
                                    if (dr.Read())
                                        MessageBox.Show("O Mês já feito pago.", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    else
                                    {
                                        dr.Close();

                                        cm = new MySqlCommand("INSERT INTO PAGAMENTOS (DESCRICAO, MES, VALOR_PAGAR, MULTA, DESCONTO, VALOR_ENTREGUE, TROCO, DATA_PAGAMENTO, DATA_REGISTO, OBSERVACAO, CONTRATO, FUNCIONARIO) VALUES ('" +
                                            this.cbServico.SelectedItem.ToString() + "', '" + this.cbMes.SelectedItem.ToString() + "', '" + float.Parse(this.txtValorPagar.Text) + "', '" + float.Parse(this.txtMulta.Text) + "', '" +
                                            float.Parse(this.txtDesconto.Text) + "', '" + float.Parse(this.txtValorPago.Text) + "', '" + this.totTc + "', '" +
                                            this.dtPagamento.Value.ToString("yyyy-MM-dd") + "', '" + this.dtRegisto.Value.ToString("yyyy-MM-dd") + "', '" + this.rtxtObs.Text + "', '" + idCont + "', '" + login.id + "')", cn.cn());
                                        if (cm.ExecuteNonQuery() != 0)
                                        {
                                            MessageBox.Show("Serviço Pago Com Successo!", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            string str = "SELECT mes, descricao as servico, observacao, data_pagamento, data_registo FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON CT.ID_CONT = PG.CONTRATO WHERE CT.CONTRATO_NUMERO = '" + this.txtContrato.Text + "'";
                                            this.pagamentosBindingSource.DataSource = cn.cn().Query<pagamentos>(str, commandType: CommandType.Text);
                                            this.dgSPagos.Refresh();
                                        }
                                    }
                                    dr.Close();
                                }
                            }
                            finally
                            {
                                cn.cn().Close();
                            }
                        else
                            MessageBox.Show("Intrduza o valor entregue.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("O valor introduzido não é válido", "Erro de Valores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Introduza o respectivo motante do serviço!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Informe os Dados do cliente", "Dados de Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void fill_debt()
        {
            int ano = 0;
            float vlp = 0;

            cm = new MySqlCommand("SELECT * FROM SERVICOS_PAGAMENTO WHERE SERVICO LIKE 'MENSALIDADE'", cn.cn());
            dr = cm.ExecuteReader();
            if (dr.Read())
                vlp = float.Parse(dr["VALOR"].ToString());
            dr.Close();

            cm = new MySqlCommand("SELECT * FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON PG.CONTRATO = CT.ID_CONT WHERE PG.DESCRICAO LIKE 'ABERTURA DE CONTRATO' AND CT.CONTRATO_NUMERO = '" + this.txtContrato.Text + "'", cn.cn());
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                ano = int.Parse(Convert.ToDateTime(dr["DATA_REGISTO"].ToString()).ToString("yyyy"));
                dr.Close();
                for (int an = DateTime.Now.Year; an >= ano; an--)
                    for (int im = 1; im <= DateTime.Now.Month; im++)
                    {
                        cm = new MySqlCommand("SELECT * FROM CONTRATOS AS CT INNER JOIN PAGAMENTOS AS PG ON PG.CONTRATO = CT.ID_CONT WHERE PG.MES LIKE '" + this.getMonth(im) + "' AND PG.DATA_PAGAMENTO LIKE '%" + an + "%'", cn.cn());
                        dr = cm.ExecuteReader();
                        if (!dr.Read())
                            this.dgDividas.Rows.Add("SERVIÇO MENSAL", this.getMonth(im), vlp.ToString("N2", df), an);
                        dr.Close();
                    }
            }
            dr.Close();
        }
        private String getMonth(int mes)
        {
            if (mes == 1)
                return "JANEIRO";
            else if (mes == 2)
                return "FEVEREIRO";
            else if (mes == 3)
                return "MARÇO";
            else if (mes == 4)
                return "ABRIL";
            else if (mes == 5)
                return "MAIO";
            else if (mes == 6)
                return "JUNHO";
            else if (mes == 7)
                return "JULHO";
            else if (mes == 8)
                return "AGOSTO";
            else if (mes == 9)
                return "SETEMBRO";
            else if (mes == 10)
                return "OUTUBRO";
            else if (mes == 11)
                return "NOVEMBRO";
            else
                return "DEZEMBRO";
        }
    }
}
