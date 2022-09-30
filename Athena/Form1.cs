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
    public partial class Athena : Form
    {
        public Athena()
        {
            InitializeComponent();
        }

        private void btnCadFuncionario_Click(object sender, EventArgs e)
        {
            this.novo_form(new cadastroFuncionarios());
        }

        private void novo_form(object form)
        {
            Form fm = form as Form;

            if (this.mainContainer.Controls.Count > 0)
                this.mainContainer.Controls.RemoveAt(0);

            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;

            this.mainContainer.Tag = fm;
            this.mainContainer.Controls.Add(fm);
            fm.Show();
        }

        private void btnCadCliente_Click(object sender, EventArgs e)
        {
            this.novo_form(new cadastrarCliente());
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            this.novo_form(new pagamentosServicos());
        }

        private void btnBloco_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void Athena_Load(object sender, EventArgs e)
        {
            this.novo_form(new home());
        }
    }
}
