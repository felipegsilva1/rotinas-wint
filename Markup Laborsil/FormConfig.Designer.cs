namespace Markup_Laborsil
{
    partial class FormConfig
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
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.btConfigTabPreco = new MetroFramework.Controls.MetroRadioButton();
            this.btConfigMarca = new MetroFramework.Controls.MetroRadioButton();
            this.btConfigProd = new MetroFramework.Controls.MetroRadioButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.btProximo = new MetroFramework.Controls.MetroButton();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.btConfigTabPreco);
            this.metroPanel2.Controls.Add(this.btConfigMarca);
            this.metroPanel2.Controls.Add(this.btConfigProd);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 130);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(906, 412);
            this.metroPanel2.TabIndex = 6;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // btConfigTabPreco
            // 
            this.btConfigTabPreco.AutoSize = true;
            this.btConfigTabPreco.Location = new System.Drawing.Point(104, 213);
            this.btConfigTabPreco.Name = "btConfigTabPreco";
            this.btConfigTabPreco.Size = new System.Drawing.Size(202, 15);
            this.btConfigTabPreco.TabIndex = 4;
            this.btConfigTabPreco.Text = "Configuração por Tabela de Preço";
            this.btConfigTabPreco.UseSelectable = true;
            // 
            // btConfigMarca
            // 
            this.btConfigMarca.AutoSize = true;
            this.btConfigMarca.Location = new System.Drawing.Point(104, 72);
            this.btConfigMarca.Name = "btConfigMarca";
            this.btConfigMarca.Size = new System.Drawing.Size(152, 15);
            this.btConfigMarca.TabIndex = 3;
            this.btConfigMarca.Text = "Configuração por Marca";
            this.btConfigMarca.UseSelectable = true;
            this.btConfigMarca.CheckedChanged += new System.EventHandler(this.metroRadioButton3_CheckedChanged);
            // 
            // btConfigProd
            // 
            this.btConfigProd.AutoSize = true;
            this.btConfigProd.Location = new System.Drawing.Point(104, 142);
            this.btConfigProd.Name = "btConfigProd";
            this.btConfigProd.Size = new System.Drawing.Size(162, 15);
            this.btConfigProd.TabIndex = 2;
            this.btConfigProd.Text = "Configuração por Produto";
            this.btConfigProd.UseSelectable = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.ForeColor = System.Drawing.Color.Black;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(906, 64);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.ForeColor = System.Drawing.Color.White;
            this.metroLabel2.Location = new System.Drawing.Point(3, 35);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(396, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Selecione a opção desejada e clique em \"Próximo\" para continuar.";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.ForeColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(3, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(169, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "O que deseja Fazer?";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.metroButton3);
            this.metroPanel3.Controls.Add(this.metroButton2);
            this.metroPanel3.Controls.Add(this.btProximo);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(20, 548);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(906, 33);
            this.metroPanel3.TabIndex = 8;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroButton3
            // 
            this.metroButton3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton3.Location = new System.Drawing.Point(547, 3);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(97, 27);
            this.metroButton3.TabIndex = 3;
            this.metroButton3.Text = "Anterior";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(806, 3);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(97, 27);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "Sair";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // btProximo
            // 
            this.btProximo.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btProximo.Location = new System.Drawing.Point(650, 3);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(97, 27);
            this.btProximo.TabIndex = 1;
            this.btProximo.Text = "Próximo";
            this.btProximo.UseSelectable = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 604);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormConfig";
            this.Text = "Acompanhamento de Markup";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroRadioButton btConfigMarca;
        private MetroFramework.Controls.MetroRadioButton btConfigProd;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton btProximo;
        private MetroFramework.Controls.MetroRadioButton btConfigTabPreco;
    }
}