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

            if (this.lkLog.Text != "Logout")
                this.Athena_Load(sender, e);
            else
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
            if (this.lkLog.Text != "Logout")
                this.Athena_Load(sender, e);
            else
                this.novo_form(new cadastrarCliente());
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            if (this.lkLog.Text != "Logout")
                this.Athena_Load(sender, e);
            else
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
            this.timer.Start();

            if (this.lkLog.Text == "Login")
            {
                login lg = new login();
                lg.ShowDialog();
            }
            if (login.id != 0)
            {
                this.lkLog.Text = "Logout";
                this.lblDtSession.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.lblUser.Text = login.usuario;
            }
            else
            {
                this.lblUser.Text = "Not logged";
                this.lkLog.Text = "Login";
                this.lblDtSession.Text = "0000-00-00 00:00:00";
            }
        }

        private void btnCadUsuario_Click(object sender, EventArgs e)
        {
            if (this.lkLog.Text != "Logout")
                this.Athena_Load(sender, e);
            else
            {
                cadastroUser cds = new cadastroUser();
                cds.ShowDialog();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.lblDataAt.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private void lkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.lkLog.Text == "Logout")
            {
                if (MessageBox.Show("Terminar Sessão?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    login lg = new login();
                    lg.logout();
                    this.Athena_Load(sender, e);
                }
            }
            else
                this.Athena_Load(sender, e);
        }

        private void btnEmulumento_Click(object sender, EventArgs e)
        {
            if (this.lkLog.Text != "Logout")
                this.Athena_Load(sender, e);
            else
            {
                emulumentosServicos em = new emulumentosServicos();
                em.ShowDialog();
            }
        }
    }
}
