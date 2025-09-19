namespace ServicoMacro.Forms
{
    partial class ServicosEdit
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
            this.btFiltroProd = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btSalve = new MetroFramework.Controls.MetroButton();
            this.CloseBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtMacroService = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btYes = new MetroFramework.Controls.MetroRadioButton();
            this.btNo = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtMinService = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtHoraService = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtDirService = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtNomeService = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txbCodService = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btFiltroProd
            // 
            this.btFiltroProd.Location = new System.Drawing.Point(404, 148);
            this.btFiltroProd.Name = "btFiltroProd";
            this.btFiltroProd.Size = new System.Drawing.Size(22, 23);
            this.btFiltroProd.TabIndex = 69;
            this.btFiltroProd.Text = "...";
            this.btFiltroProd.UseSelectable = true;
            this.btFiltroProd.Click += new System.EventHandler(this.btFiltroProd_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.btSalve);
            this.metroPanel1.Controls.Add(this.CloseBtn);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 333);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(403, 34);
            this.metroPanel1.TabIndex = 68;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btSalve
            // 
            this.btSalve.Location = new System.Drawing.Point(3, 3);
            this.btSalve.Name = "btSalve";
            this.btSalve.Size = new System.Drawing.Size(97, 27);
            this.btSalve.TabIndex = 4;
            this.btSalve.Text = "Salvar";
            this.btSalve.UseSelectable = true;
            this.btSalve.Click += new System.EventHandler(this.btSalve_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(303, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(97, 27);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "Fechar";
            this.CloseBtn.UseSelectable = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.Location = new System.Drawing.Point(23, 300);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(320, 30);
            this.metroLabel8.TabIndex = 67;
            this.metroLabel8.Text = "Atenção o nome da macro precisa exatamente como no Excel.\r\n";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(23, 254);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(126, 15);
            this.metroLabel7.TabIndex = 66;
            this.metroLabel7.Text = "Macro a ser Executada: ";
            // 
            // txtMacroService
            // 
            // 
            // 
            // 
            this.txtMacroService.CustomButton.Image = null;
            this.txtMacroService.CustomButton.Location = new System.Drawing.Point(381, 1);
            this.txtMacroService.CustomButton.Name = "";
            this.txtMacroService.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMacroService.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMacroService.CustomButton.TabIndex = 1;
            this.txtMacroService.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMacroService.CustomButton.UseSelectable = true;
            this.txtMacroService.CustomButton.Visible = false;
            this.txtMacroService.Lines = new string[0];
            this.txtMacroService.Location = new System.Drawing.Point(23, 274);
            this.txtMacroService.MaxLength = 32767;
            this.txtMacroService.Name = "txtMacroService";
            this.txtMacroService.PasswordChar = '\0';
            this.txtMacroService.PromptText = "Digite o nome da Macro";
            this.txtMacroService.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMacroService.SelectedText = "";
            this.txtMacroService.SelectionLength = 0;
            this.txtMacroService.SelectionStart = 0;
            this.txtMacroService.ShortcutsEnabled = true;
            this.txtMacroService.Size = new System.Drawing.Size(403, 23);
            this.txtMacroService.TabIndex = 65;
            this.txtMacroService.UseSelectable = true;
            this.txtMacroService.WaterMark = "Digite o nome da Macro";
            this.txtMacroService.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMacroService.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.metroLabel6);
            this.metroPanel4.Controls.Add(this.btYes);
            this.metroPanel4.Controls.Add(this.btNo);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(286, 189);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(140, 46);
            this.metroPanel4.TabIndex = 64;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(7, -1);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(36, 15);
            this.metroLabel6.TabIndex = 39;
            this.metroLabel6.Text = "Ativo:";
            // 
            // btYes
            // 
            this.btYes.AutoSize = true;
            this.btYes.Location = new System.Drawing.Point(15, 20);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(43, 15);
            this.btYes.TabIndex = 38;
            this.btYes.Text = "Sim";
            this.btYes.UseSelectable = true;
            // 
            // btNo
            // 
            this.btNo.AutoSize = true;
            this.btNo.Location = new System.Drawing.Point(84, 20);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(45, 15);
            this.btNo.TabIndex = 40;
            this.btNo.Text = "Não";
            this.btNo.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(147, 192);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(87, 15);
            this.metroLabel5.TabIndex = 63;
            this.metroLabel5.Text = "Minuto Serviço: ";
            // 
            // txtMinService
            // 
            // 
            // 
            // 
            this.txtMinService.CustomButton.Image = null;
            this.txtMinService.CustomButton.Location = new System.Drawing.Point(77, 1);
            this.txtMinService.CustomButton.Name = "";
            this.txtMinService.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMinService.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMinService.CustomButton.TabIndex = 1;
            this.txtMinService.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMinService.CustomButton.UseSelectable = true;
            this.txtMinService.CustomButton.Visible = false;
            this.txtMinService.Lines = new string[0];
            this.txtMinService.Location = new System.Drawing.Point(147, 212);
            this.txtMinService.MaxLength = 32767;
            this.txtMinService.Name = "txtMinService";
            this.txtMinService.PasswordChar = '\0';
            this.txtMinService.PromptText = "Hora";
            this.txtMinService.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMinService.SelectedText = "";
            this.txtMinService.SelectionLength = 0;
            this.txtMinService.SelectionStart = 0;
            this.txtMinService.ShortcutsEnabled = true;
            this.txtMinService.Size = new System.Drawing.Size(99, 23);
            this.txtMinService.TabIndex = 62;
            this.txtMinService.UseSelectable = true;
            this.txtMinService.WaterMark = "Hora";
            this.txtMinService.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMinService.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(23, 192);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(77, 15);
            this.metroLabel4.TabIndex = 61;
            this.metroLabel4.Text = "Hora Serviço: ";
            // 
            // txtHoraService
            // 
            // 
            // 
            // 
            this.txtHoraService.CustomButton.Image = null;
            this.txtHoraService.CustomButton.Location = new System.Drawing.Point(77, 1);
            this.txtHoraService.CustomButton.Name = "";
            this.txtHoraService.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtHoraService.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHoraService.CustomButton.TabIndex = 1;
            this.txtHoraService.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHoraService.CustomButton.UseSelectable = true;
            this.txtHoraService.CustomButton.Visible = false;
            this.txtHoraService.Lines = new string[0];
            this.txtHoraService.Location = new System.Drawing.Point(23, 212);
            this.txtHoraService.MaxLength = 32767;
            this.txtHoraService.Name = "txtHoraService";
            this.txtHoraService.PasswordChar = '\0';
            this.txtHoraService.PromptText = "Hora";
            this.txtHoraService.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHoraService.SelectedText = "";
            this.txtHoraService.SelectionLength = 0;
            this.txtHoraService.SelectionStart = 0;
            this.txtHoraService.ShortcutsEnabled = true;
            this.txtHoraService.Size = new System.Drawing.Size(99, 23);
            this.txtHoraService.TabIndex = 60;
            this.txtHoraService.UseSelectable = true;
            this.txtHoraService.WaterMark = "Hora";
            this.txtHoraService.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtHoraService.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(23, 128);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(96, 15);
            this.metroLabel2.TabIndex = 59;
            this.metroLabel2.Text = "Diretório Serviço: ";
            // 
            // txtDirService
            // 
            // 
            // 
            // 
            this.txtDirService.CustomButton.Image = null;
            this.txtDirService.CustomButton.Location = new System.Drawing.Point(353, 1);
            this.txtDirService.CustomButton.Name = "";
            this.txtDirService.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDirService.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDirService.CustomButton.TabIndex = 1;
            this.txtDirService.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDirService.CustomButton.UseSelectable = true;
            this.txtDirService.CustomButton.Visible = false;
            this.txtDirService.Lines = new string[0];
            this.txtDirService.Location = new System.Drawing.Point(23, 148);
            this.txtDirService.MaxLength = 32767;
            this.txtDirService.Name = "txtDirService";
            this.txtDirService.PasswordChar = '\0';
            this.txtDirService.PromptText = "Escolha o Diretório";
            this.txtDirService.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDirService.SelectedText = "";
            this.txtDirService.SelectionLength = 0;
            this.txtDirService.SelectionStart = 0;
            this.txtDirService.ShortcutsEnabled = true;
            this.txtDirService.Size = new System.Drawing.Size(375, 23);
            this.txtDirService.TabIndex = 58;
            this.txtDirService.UseSelectable = true;
            this.txtDirService.WaterMark = "Escolha o Diretório";
            this.txtDirService.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDirService.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(147, 71);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 15);
            this.metroLabel1.TabIndex = 57;
            this.metroLabel1.Text = "Nome Serviço: ";
            // 
            // txtNomeService
            // 
            // 
            // 
            // 
            this.txtNomeService.CustomButton.Image = null;
            this.txtNomeService.CustomButton.Location = new System.Drawing.Point(257, 1);
            this.txtNomeService.CustomButton.Name = "";
            this.txtNomeService.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNomeService.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNomeService.CustomButton.TabIndex = 1;
            this.txtNomeService.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNomeService.CustomButton.UseSelectable = true;
            this.txtNomeService.CustomButton.Visible = false;
            this.txtNomeService.Lines = new string[0];
            this.txtNomeService.Location = new System.Drawing.Point(147, 91);
            this.txtNomeService.MaxLength = 32767;
            this.txtNomeService.Name = "txtNomeService";
            this.txtNomeService.PasswordChar = '\0';
            this.txtNomeService.PromptText = "Nome";
            this.txtNomeService.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNomeService.SelectedText = "";
            this.txtNomeService.SelectionLength = 0;
            this.txtNomeService.SelectionStart = 0;
            this.txtNomeService.ShortcutsEnabled = true;
            this.txtNomeService.Size = new System.Drawing.Size(279, 23);
            this.txtNomeService.TabIndex = 56;
            this.txtNomeService.UseSelectable = true;
            this.txtNomeService.WaterMark = "Nome";
            this.txtNomeService.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNomeService.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(23, 71);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(76, 15);
            this.metroLabel3.TabIndex = 55;
            this.metroLabel3.Text = "Cód. Serviço: ";
            // 
            // txbCodService
            // 
            this.txbCodService.BackColor = System.Drawing.Color.LightGray;
            // 
            // 
            // 
            this.txbCodService.CustomButton.Image = null;
            this.txbCodService.CustomButton.Location = new System.Drawing.Point(77, 1);
            this.txbCodService.CustomButton.Name = "";
            this.txbCodService.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbCodService.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbCodService.CustomButton.TabIndex = 1;
            this.txbCodService.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbCodService.CustomButton.UseSelectable = true;
            this.txbCodService.CustomButton.Visible = false;
            this.txbCodService.Enabled = false;
            this.txbCodService.Lines = new string[0];
            this.txbCodService.Location = new System.Drawing.Point(23, 91);
            this.txbCodService.MaxLength = 32767;
            this.txbCodService.Name = "txbCodService";
            this.txbCodService.PasswordChar = '\0';
            this.txbCodService.PromptText = "Código";
            this.txbCodService.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbCodService.SelectedText = "";
            this.txbCodService.SelectionLength = 0;
            this.txbCodService.SelectionStart = 0;
            this.txbCodService.ShortcutsEnabled = true;
            this.txbCodService.Size = new System.Drawing.Size(99, 23);
            this.txbCodService.TabIndex = 54;
            this.txbCodService.UseSelectable = true;
            this.txbCodService.WaterMark = "Código";
            this.txbCodService.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbCodService.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ServicosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 403);
            this.Controls.Add(this.btFiltroProd);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtMacroService);
            this.Controls.Add(this.metroPanel4);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtMinService);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtHoraService);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtDirService);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtNomeService);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txbCodService);
            this.Name = "ServicosEdit";
            this.Text = "Serviços";
            this.Load += new System.EventHandler(this.ServicosEdit_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btFiltroProd;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btSalve;
        private MetroFramework.Controls.MetroButton CloseBtn;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        public MetroFramework.Controls.MetroTextBox txtMacroService;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroRadioButton btYes;
        private MetroFramework.Controls.MetroRadioButton btNo;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroTextBox txtMinService;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroTextBox txtHoraService;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroTextBox txtDirService;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroTextBox txtNomeService;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroTextBox txbCodService;
    }
}