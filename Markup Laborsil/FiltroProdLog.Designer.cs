namespace Markup_Laborsil
{
    partial class FiltroProdLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.BtnPesquisarLog = new MetroFramework.Controls.MetroButton();
            this.txbDescricao = new MetroFramework.Controls.MetroTextBox();
            this.txbFiltroCodProd = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.btnConfirmar = new MetroFramework.Controls.MetroButton();
            this.BtnClose = new MetroFramework.Controls.MetroButton();
            this.FiltroProdGrid = new MetroFramework.Controls.MetroGrid();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FiltroProdGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.BtnPesquisarLog);
            this.metroPanel1.Controls.Add(this.txbDescricao);
            this.metroPanel1.Controls.Add(this.txbFiltroCodProd);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.ForeColor = System.Drawing.Color.Black;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(498, 64);
            this.metroPanel1.TabIndex = 9;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(19, 11);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 15);
            this.metroLabel1.TabIndex = 14;
            this.metroLabel1.Text = "Cód. Prod.:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(118, 11);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(58, 15);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Descrição:";
            // 
            // BtnPesquisarLog
            // 
            this.BtnPesquisarLog.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BtnPesquisarLog.Location = new System.Drawing.Point(357, 25);
            this.BtnPesquisarLog.Name = "BtnPesquisarLog";
            this.BtnPesquisarLog.Size = new System.Drawing.Size(121, 27);
            this.BtnPesquisarLog.TabIndex = 9;
            this.BtnPesquisarLog.Text = "Pesquisar";
            this.BtnPesquisarLog.UseSelectable = true;
            this.BtnPesquisarLog.Click += new System.EventHandler(this.BtnPesquisarLog_Click);
            // 
            // txbDescricao
            // 
            // 
            // 
            // 
            this.txbDescricao.CustomButton.Image = null;
            this.txbDescricao.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txbDescricao.CustomButton.Name = "";
            this.txbDescricao.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbDescricao.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbDescricao.CustomButton.TabIndex = 1;
            this.txbDescricao.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbDescricao.CustomButton.UseSelectable = true;
            this.txbDescricao.CustomButton.Visible = false;
            this.txbDescricao.Lines = new string[0];
            this.txbDescricao.Location = new System.Drawing.Point(118, 29);
            this.txbDescricao.MaxLength = 32767;
            this.txbDescricao.Name = "txbDescricao";
            this.txbDescricao.PasswordChar = '\0';
            this.txbDescricao.PromptText = "Descrição";
            this.txbDescricao.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbDescricao.SelectedText = "";
            this.txbDescricao.SelectionLength = 0;
            this.txbDescricao.SelectionStart = 0;
            this.txbDescricao.ShortcutsEnabled = true;
            this.txbDescricao.Size = new System.Drawing.Size(233, 23);
            this.txbDescricao.TabIndex = 8;
            this.txbDescricao.UseSelectable = true;
            this.txbDescricao.WaterMark = "Descrição";
            this.txbDescricao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbDescricao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txbFiltroCodProd
            // 
            // 
            // 
            // 
            this.txbFiltroCodProd.CustomButton.Image = null;
            this.txbFiltroCodProd.CustomButton.Location = new System.Drawing.Point(71, 1);
            this.txbFiltroCodProd.CustomButton.Name = "";
            this.txbFiltroCodProd.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbFiltroCodProd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbFiltroCodProd.CustomButton.TabIndex = 1;
            this.txbFiltroCodProd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbFiltroCodProd.CustomButton.UseSelectable = true;
            this.txbFiltroCodProd.CustomButton.Visible = false;
            this.txbFiltroCodProd.Lines = new string[0];
            this.txbFiltroCodProd.Location = new System.Drawing.Point(19, 29);
            this.txbFiltroCodProd.MaxLength = 32767;
            this.txbFiltroCodProd.Name = "txbFiltroCodProd";
            this.txbFiltroCodProd.PasswordChar = '\0';
            this.txbFiltroCodProd.PromptText = "Código";
            this.txbFiltroCodProd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbFiltroCodProd.SelectedText = "";
            this.txbFiltroCodProd.SelectionLength = 0;
            this.txbFiltroCodProd.SelectionStart = 0;
            this.txbFiltroCodProd.ShortcutsEnabled = true;
            this.txbFiltroCodProd.Size = new System.Drawing.Size(93, 23);
            this.txbFiltroCodProd.TabIndex = 7;
            this.txbFiltroCodProd.UseSelectable = true;
            this.txbFiltroCodProd.WaterMark = "Código";
            this.txbFiltroCodProd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbFiltroCodProd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metroPanel2.Controls.Add(this.btnConfirmar);
            this.metroPanel2.Controls.Add(this.BtnClose);
            this.metroPanel2.ForeColor = System.Drawing.Color.Black;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 472);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(498, 33);
            this.metroPanel2.TabIndex = 10;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnConfirmar.Location = new System.Drawing.Point(230, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(121, 27);
            this.btnConfirmar.TabIndex = 16;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseSelectable = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BtnClose.Location = new System.Drawing.Point(357, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(121, 27);
            this.BtnClose.TabIndex = 15;
            this.BtnClose.Text = "Cancelar";
            this.BtnClose.UseSelectable = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // FiltroProdGrid
            // 
            this.FiltroProdGrid.AllowUserToResizeRows = false;
            this.FiltroProdGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FiltroProdGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FiltroProdGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.FiltroProdGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FiltroProdGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.FiltroProdGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FiltroProdGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.FiltroProdGrid.EnableHeadersVisualStyles = false;
            this.FiltroProdGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FiltroProdGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FiltroProdGrid.Location = new System.Drawing.Point(20, 130);
            this.FiltroProdGrid.Name = "FiltroProdGrid";
            this.FiltroProdGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FiltroProdGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.FiltroProdGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.FiltroProdGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FiltroProdGrid.Size = new System.Drawing.Size(498, 336);
            this.FiltroProdGrid.TabIndex = 11;
            this.FiltroProdGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FiltroProdGrid_CellDoubleClick);
            // 
            // FiltroProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 528);
            this.Controls.Add(this.FiltroProdGrid);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FiltroProd";
            this.Text = "Pesquisa de Produtos";
            this.Load += new System.EventHandler(this.FiltroProd_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FiltroProdGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txbFiltroCodProd;
        private MetroFramework.Controls.MetroTextBox txbDescricao;
        private MetroFramework.Controls.MetroButton BtnPesquisarLog;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroButton btnConfirmar;
        private MetroFramework.Controls.MetroButton BtnClose;
        private MetroFramework.Controls.MetroGrid FiltroProdGrid;
    }
}