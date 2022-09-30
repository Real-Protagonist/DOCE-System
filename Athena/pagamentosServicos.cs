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
    public partial class pagamentosServicos : Form
    {
        public pagamentosServicos()
        {
            InitializeComponent();
        }

        private void pagamentosServicos_Load(object sender, EventArgs e)
        {
            this.txtSubtotal.Text = "0,00";
            this.txtTotal.Text = "0,00";

            this.cbFPagamento.SelectedIndex = 3;
            this.cbMes.SelectedIndex = 0;
            this.cbServico.SelectedIndex = 0;
        }
    }
}
