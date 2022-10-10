namespace Athena
{
    partial class formFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fatura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pagamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pagamentosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fatura
            // 
            this.fatura.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.pagamentosBindingSource, "servico", true));
            this.fatura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fatura.LocalReport.ReportEmbeddedResource = "Athena.factura.rdlc";
            this.fatura.Location = new System.Drawing.Point(0, 0);
            this.fatura.Name = "fatura";
            this.fatura.ServerReport.BearerToken = null;
            this.fatura.ShowBackButton = false;
            this.fatura.Size = new System.Drawing.Size(995, 577);
            this.fatura.TabIndex = 0;
            this.fatura.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.fatura.Load += new System.EventHandler(this.fatura_Load);
            // 
            // pagamentosBindingSource
            // 
            this.pagamentosBindingSource.DataSource = typeof(pagamentos);
            // 
            // formFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 577);
            this.Controls.Add(this.fatura);
            this.Name = "formFactura";
            this.Text = "Fatura Recibo";
            this.Load += new System.EventHandler(this.formFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pagamentosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer fatura;
        private System.Windows.Forms.BindingSource pagamentosBindingSource;
    }
}