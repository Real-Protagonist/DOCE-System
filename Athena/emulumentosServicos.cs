using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Athena
{
    public partial class emulumentosServicos : Form
    {
        bridge cn = new bridge();
        public emulumentosServicos()
        {
            InitializeComponent();
        }
        NumberFormatInfo m = new CultureInfo("en-US").NumberFormat;
        CultureInfo df = new CultureInfo("en-US");

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String valor = "";
            if (!String.IsNullOrEmpty(this.txtValorPagar.Text))
                valor = double.Parse(this.txtValorPagar.Text).ToString("N2", df);
            else
                valor = "0";
            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                MySqlCommand cm = new MySqlCommand("INSERT INTO SERVICOS_PAGAMENTO VALUES(DEFAULT, '" + this.cbServico.SelectedItem.ToString() + "', '" + valor + "')", cn.cn());
                if (cm.ExecuteNonQuery() != 0)
                    MessageBox.Show("Informação Salva!", "Emulumentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.cn().Close();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            String valor = "";
            if (!String.IsNullOrEmpty(this.txtValorPagar.Text))
                valor = float.Parse(this.txtValorPagar.Text).ToString("N2", df);
            else
                valor = "0";
            try
            {
                if (cn.cn().State == ConnectionState.Closed)
                    cn.cn().Open();
                MySqlCommand cm = new MySqlCommand("UPDATE SERVICOS_PAGAMENTO SET SERVICO = '" + this.cbServico.SelectedItem.ToString() + "', VALOR = '" + valor + "' WHERE ID_SERVICO = '" + (this.cbServico.SelectedIndex + 1) + "'", cn.cn());
                if (cm.ExecuteNonQuery() != 0)
                    MessageBox.Show("Informação Atualizada!", "Emulumentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.cn().Close();
            }
        }

        private void emulumentosServicos_Load(object sender, EventArgs e)
        {
            df.NumberFormat.NumberGroupSeparator = "";
        }
    }
}
