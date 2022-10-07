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

namespace Athena
{
    public partial class formFactura : Form
    {
        bridge cn = new bridge();
        public formFactura()
        {
            InitializeComponent();
        }

        private String data_pagamento;
        private String contrato;

        public String getData()
        {
            return data_pagamento;
        }
        public String getContrato()
        {
            return contrato;
        }
        public void setData(String data)
        {
            data_pagamento = data;
        }
        public void setContrato(String contrato)
        {
            this.contrato = contrato;
        }

        private void formFactura_Load(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT * FROM EMPRESA", cn.cn());
            MySqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("empresa", dr["nome"].ToString()));
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("nifEmp", dr["NIF"].ToString()));
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("endereco", dr["ENDERECO"].ToString()));
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("tel1", dr["TEL1"].ToString()));
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("tel2", dr["TEL2"].ToString()));
            }
            dr.Close();

            cm = new MySqlCommand("SELECT SUM(VALOR_PAGAR) AS totPag, SUM(MULTA) AS mt, SUM(DESCONTO) AS dsc FROM PAGAMENTOS AS PG INNER JOIN CONTRATOS AS CT ON CT.ID_CONT = PG.CONTRATO WHERE PG.DATA_PAGAMENTO LIKE '" + this.getData() + "' AND CT.NUMERO_CONTRATO LIKE '" + this.getContrato() + "'", cn.cn());
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("totMulta", dr["mt"].ToString()));
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("totDesc", dr["dsc"].ToString()));
                this.fatura.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("valorPagar", dr["totPag"].ToString()));
            }
            dr.Close();
            this.fatura.RefreshReport();
        }

        private void fatura_Load(object sender, EventArgs e)
        {

        }
    }
}
