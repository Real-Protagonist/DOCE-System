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

            this.fatura.RefreshReport();
        }

        private void fatura_Load(object sender, EventArgs e)
        {

        }
    }
}
