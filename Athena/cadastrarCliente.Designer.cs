namespace Athena
{
    partial class cadastrarCliente
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
            this.btnEditarFuncionarioC = new System.Windows.Forms.Button();
            this.btnCancelarC = new System.Windows.Forms.Button();
            this.btnCadastrarC = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtContrato = new System.Windows.Forms.DateTimePicker();
            this.txtContrato = new System.Windows.Forms.TextBox();
            this.txtEmailC = new System.Windows.Forms.TextBox();
            this.txtTel2C = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSexoC = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTel1C = new System.Windows.Forms.TextBox();
            this.txtUNomeC = new System.Windows.Forms.TextBox();
            this.txtPNomeC = new System.Windows.Forms.TextBox();
            this.btnImportarFotoCliente = new System.Windows.Forms.Button();
            this.lblFotoC = new System.Windows.Forms.Label();
            this.pbFotoCliente = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ndCasa = new System.Windows.Forms.NumericUpDown();
            this.dgCliente = new System.Windows.Forms.DataGridView();
            this.contratoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primeironomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimonomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bairroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.casaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cadastroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndCasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditarFuncionarioC
            // 
            this.btnEditarFuncionarioC.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEditarFuncionarioC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarFuncionarioC.Location = new System.Drawing.Point(749, 217);
            this.btnEditarFuncionarioC.Name = "btnEditarFuncionarioC";
            this.btnEditarFuncionarioC.Size = new System.Drawing.Size(96, 30);
            this.btnEditarFuncionarioC.TabIndex = 15;
            this.btnEditarFuncionarioC.Text = "EDITAR";
            this.btnEditarFuncionarioC.UseVisualStyleBackColor = false;
            // 
            // btnCancelarC
            // 
            this.btnCancelarC.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelarC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarC.Location = new System.Drawing.Point(854, 217);
            this.btnCancelarC.Name = "btnCancelarC";
            this.btnCancelarC.Size = new System.Drawing.Size(96, 30);
            this.btnCancelarC.TabIndex = 16;
            this.btnCancelarC.Text = "CANCELAR";
            this.btnCancelarC.UseVisualStyleBackColor = false;
            // 
            // btnCadastrarC
            // 
            this.btnCadastrarC.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCadastrarC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarC.Location = new System.Drawing.Point(642, 217);
            this.btnCadastrarC.Name = "btnCadastrarC";
            this.btnCadastrarC.Size = new System.Drawing.Size(96, 30);
            this.btnCadastrarC.TabIndex = 14;
            this.btnCadastrarC.Text = "CADASTRAR";
            this.btnCadastrarC.UseVisualStyleBackColor = false;
            this.btnCadastrarC.Click += new System.EventHandler(this.btnCadastrarC_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(432, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Data de Cadastro";
            // 
            // dtContrato
            // 
            this.dtContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtContrato.Location = new System.Drawing.Point(435, 227);
            this.dtContrato.Name = "dtContrato";
            this.dtContrato.Size = new System.Drawing.Size(102, 20);
            this.dtContrato.TabIndex = 12;
            this.dtContrato.Value = new System.DateTime(2022, 9, 30, 0, 0, 0, 0);
            // 
            // txtContrato
            // 
            this.txtContrato.Location = new System.Drawing.Point(228, 227);
            this.txtContrato.Name = "txtContrato";
            this.txtContrato.Size = new System.Drawing.Size(184, 20);
            this.txtContrato.TabIndex = 11;
            this.txtContrato.TextChanged += new System.EventHandler(this.txtContrato_TextChanged);
            // 
            // txtEmailC
            // 
            this.txtEmailC.Location = new System.Drawing.Point(642, 133);
            this.txtEmailC.Name = "txtEmailC";
            this.txtEmailC.Size = new System.Drawing.Size(184, 20);
            this.txtEmailC.TabIndex = 7;
            // 
            // txtTel2C
            // 
            this.txtTel2C.Location = new System.Drawing.Point(435, 133);
            this.txtTel2C.Name = "txtTel2C";
            this.txtTel2C.Size = new System.Drawing.Size(136, 20);
            this.txtTel2C.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(225, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Nº de Contrato";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Tel.2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(639, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Sexo";
            // 
            // cbSexoC
            // 
            this.cbSexoC.FormattingEnabled = true;
            this.cbSexoC.Items.AddRange(new object[] {
            "Masculino",
            "Feminino"});
            this.cbSexoC.Location = new System.Drawing.Point(642, 86);
            this.cbSexoC.Name = "cbSexoC";
            this.cbSexoC.Size = new System.Drawing.Size(121, 21);
            this.cbSexoC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Tel.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Último Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Primeiro Nome";
            // 
            // txtTel1C
            // 
            this.txtTel1C.Location = new System.Drawing.Point(228, 133);
            this.txtTel1C.Name = "txtTel1C";
            this.txtTel1C.Size = new System.Drawing.Size(136, 20);
            this.txtTel1C.TabIndex = 5;
            this.txtTel1C.TextChanged += new System.EventHandler(this.txtTel1C_TextChanged);
            // 
            // txtUNomeC
            // 
            this.txtUNomeC.Location = new System.Drawing.Point(435, 86);
            this.txtUNomeC.Name = "txtUNomeC";
            this.txtUNomeC.Size = new System.Drawing.Size(184, 20);
            this.txtUNomeC.TabIndex = 2;
            this.txtUNomeC.TextChanged += new System.EventHandler(this.txtUNomeC_TextChanged);
            // 
            // txtPNomeC
            // 
            this.txtPNomeC.Location = new System.Drawing.Point(228, 86);
            this.txtPNomeC.Name = "txtPNomeC";
            this.txtPNomeC.Size = new System.Drawing.Size(184, 20);
            this.txtPNomeC.TabIndex = 1;
            this.txtPNomeC.TextChanged += new System.EventHandler(this.txtPNomeC_TextChanged);
            // 
            // btnImportarFotoCliente
            // 
            this.btnImportarFotoCliente.Location = new System.Drawing.Point(56, 254);
            this.btnImportarFotoCliente.Name = "btnImportarFotoCliente";
            this.btnImportarFotoCliente.Size = new System.Drawing.Size(98, 23);
            this.btnImportarFotoCliente.TabIndex = 13;
            this.btnImportarFotoCliente.Text = "Importar";
            this.btnImportarFotoCliente.UseVisualStyleBackColor = true;
            // 
            // lblFotoC
            // 
            this.lblFotoC.AutoSize = true;
            this.lblFotoC.ForeColor = System.Drawing.Color.Gray;
            this.lblFotoC.Location = new System.Drawing.Point(53, 238);
            this.lblFotoC.Name = "lblFotoC";
            this.lblFotoC.Size = new System.Drawing.Size(101, 13);
            this.lblFotoC.TabIndex = 28;
            this.lblFotoC.Text = "Foto do Funcionário";
            // 
            // pbFotoCliente
            // 
            this.pbFotoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFotoCliente.Location = new System.Drawing.Point(27, 65);
            this.pbFotoCliente.Name = "pbFotoCliente";
            this.pbFotoCliente.Size = new System.Drawing.Size(155, 170);
            this.pbFotoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoCliente.TabIndex = 27;
            this.pbFotoCliente.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "CADASTRAR CLIENTE";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(228, 180);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(184, 20);
            this.txtBairro.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(225, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "BAIRRO";
            // 
            // txtRua
            // 
            this.txtRua.Location = new System.Drawing.Point(435, 180);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(184, 20);
            this.txtRua.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(432, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "RUA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(639, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "CASA Nº";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(781, 86);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(184, 20);
            this.txtDocumento.TabIndex = 4;
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(778, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "DOCUMENTO (B.I.)";
            // 
            // ndCasa
            // 
            this.ndCasa.Location = new System.Drawing.Point(642, 181);
            this.ndCasa.Name = "ndCasa";
            this.ndCasa.Size = new System.Drawing.Size(96, 20);
            this.ndCasa.TabIndex = 10;
            // 
            // dgCliente
            // 
            this.dgCliente.AllowUserToAddRows = false;
            this.dgCliente.AllowUserToDeleteRows = false;
            this.dgCliente.AllowUserToResizeColumns = false;
            this.dgCliente.AllowUserToResizeRows = false;
            this.dgCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCliente.AutoGenerateColumns = false;
            this.dgCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCliente.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgCliente.ColumnHeadersHeight = 40;
            this.dgCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contratoDataGridViewTextBoxColumn,
            this.primeironomeDataGridViewTextBoxColumn,
            this.ultimonomeDataGridViewTextBoxColumn,
            this.sexoDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.tel1DataGridViewTextBoxColumn,
            this.tel2DataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.bairroDataGridViewTextBoxColumn,
            this.ruaDataGridViewTextBoxColumn,
            this.casaDataGridViewTextBoxColumn,
            this.cadastroDataGridViewTextBoxColumn});
            this.dgCliente.DataSource = this.clientesBindingSource;
            this.dgCliente.Location = new System.Drawing.Point(12, 294);
            this.dgCliente.Name = "dgCliente";
            this.dgCliente.ReadOnly = true;
            this.dgCliente.RowHeadersVisible = false;
            this.dgCliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCliente.Size = new System.Drawing.Size(1262, 261);
            this.dgCliente.TabIndex = 17;
            // 
            // contratoDataGridViewTextBoxColumn
            // 
            this.contratoDataGridViewTextBoxColumn.DataPropertyName = "contrato";
            this.contratoDataGridViewTextBoxColumn.HeaderText = "Contrato";
            this.contratoDataGridViewTextBoxColumn.Name = "contratoDataGridViewTextBoxColumn";
            this.contratoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // primeironomeDataGridViewTextBoxColumn
            // 
            this.primeironomeDataGridViewTextBoxColumn.DataPropertyName = "primeiro_nome";
            this.primeironomeDataGridViewTextBoxColumn.FillWeight = 180F;
            this.primeironomeDataGridViewTextBoxColumn.HeaderText = "Primeiro Nome";
            this.primeironomeDataGridViewTextBoxColumn.Name = "primeironomeDataGridViewTextBoxColumn";
            this.primeironomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ultimonomeDataGridViewTextBoxColumn
            // 
            this.ultimonomeDataGridViewTextBoxColumn.DataPropertyName = "ultimo_nome";
            this.ultimonomeDataGridViewTextBoxColumn.FillWeight = 180F;
            this.ultimonomeDataGridViewTextBoxColumn.HeaderText = "Último Nome";
            this.ultimonomeDataGridViewTextBoxColumn.Name = "ultimonomeDataGridViewTextBoxColumn";
            this.ultimonomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sexoDataGridViewTextBoxColumn
            // 
            this.sexoDataGridViewTextBoxColumn.DataPropertyName = "sexo";
            this.sexoDataGridViewTextBoxColumn.HeaderText = "Sexo";
            this.sexoDataGridViewTextBoxColumn.Name = "sexoDataGridViewTextBoxColumn";
            this.sexoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            this.documentoDataGridViewTextBoxColumn.DataPropertyName = "documento";
            this.documentoDataGridViewTextBoxColumn.FillWeight = 180F;
            this.documentoDataGridViewTextBoxColumn.HeaderText = "Documento";
            this.documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            this.documentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tel1DataGridViewTextBoxColumn
            // 
            this.tel1DataGridViewTextBoxColumn.DataPropertyName = "tel1";
            this.tel1DataGridViewTextBoxColumn.HeaderText = "Tel.1";
            this.tel1DataGridViewTextBoxColumn.Name = "tel1DataGridViewTextBoxColumn";
            this.tel1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tel2DataGridViewTextBoxColumn
            // 
            this.tel2DataGridViewTextBoxColumn.DataPropertyName = "tel2";
            this.tel2DataGridViewTextBoxColumn.HeaderText = "Tel.2";
            this.tel2DataGridViewTextBoxColumn.Name = "tel2DataGridViewTextBoxColumn";
            this.tel2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bairroDataGridViewTextBoxColumn
            // 
            this.bairroDataGridViewTextBoxColumn.DataPropertyName = "bairro";
            this.bairroDataGridViewTextBoxColumn.HeaderText = "Bairro";
            this.bairroDataGridViewTextBoxColumn.Name = "bairroDataGridViewTextBoxColumn";
            this.bairroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ruaDataGridViewTextBoxColumn
            // 
            this.ruaDataGridViewTextBoxColumn.DataPropertyName = "rua";
            this.ruaDataGridViewTextBoxColumn.HeaderText = "Rua";
            this.ruaDataGridViewTextBoxColumn.Name = "ruaDataGridViewTextBoxColumn";
            this.ruaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // casaDataGridViewTextBoxColumn
            // 
            this.casaDataGridViewTextBoxColumn.DataPropertyName = "casa";
            this.casaDataGridViewTextBoxColumn.FillWeight = 85F;
            this.casaDataGridViewTextBoxColumn.HeaderText = "Casa Nº";
            this.casaDataGridViewTextBoxColumn.Name = "casaDataGridViewTextBoxColumn";
            this.casaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cadastroDataGridViewTextBoxColumn
            // 
            this.cadastroDataGridViewTextBoxColumn.DataPropertyName = "cadastro";
            this.cadastroDataGridViewTextBoxColumn.HeaderText = "Data de Contrato";
            this.cadastroDataGridViewTextBoxColumn.Name = "cadastroDataGridViewTextBoxColumn";
            this.cadastroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataSource = typeof(clientes);
            // 
            // cadastrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 578);
            this.Controls.Add(this.dgCliente);
            this.Controls.Add(this.ndCasa);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnEditarFuncionarioC);
            this.Controls.Add(this.btnCancelarC);
            this.Controls.Add(this.btnCadastrarC);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtContrato);
            this.Controls.Add(this.txtContrato);
            this.Controls.Add(this.txtEmailC);
            this.Controls.Add(this.txtTel2C);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSexoC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTel1C);
            this.Controls.Add(this.txtUNomeC);
            this.Controls.Add(this.txtPNomeC);
            this.Controls.Add(this.btnImportarFotoCliente);
            this.Controls.Add(this.lblFotoC);
            this.Controls.Add(this.pbFotoCliente);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cadastrarCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cadastrarCliente";
            this.Load += new System.EventHandler(this.cadastrarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndCasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditarFuncionarioC;
        private System.Windows.Forms.Button btnCancelarC;
        private System.Windows.Forms.Button btnCadastrarC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtContrato;
        private System.Windows.Forms.TextBox txtContrato;
        private System.Windows.Forms.TextBox txtEmailC;
        private System.Windows.Forms.TextBox txtTel2C;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSexoC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTel1C;
        private System.Windows.Forms.TextBox txtUNomeC;
        private System.Windows.Forms.TextBox txtPNomeC;
        private System.Windows.Forms.Button btnImportarFotoCliente;
        private System.Windows.Forms.Label lblFotoC;
        private System.Windows.Forms.PictureBox pbFotoCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown ndCasa;
        private System.Windows.Forms.DataGridView dgCliente;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn contratoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primeironomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimonomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bairroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn casaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cadastroDataGridViewTextBoxColumn;
    }
}