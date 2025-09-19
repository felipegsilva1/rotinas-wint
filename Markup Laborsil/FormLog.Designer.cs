using System.Windows.Forms;

namespace Markup_Laborsil
{
    partial class FormLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.btFiltroProd = new MetroFramework.Controls.MetroButton();
            this.dtFim = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.dtInic = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox5 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox4 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.txbPromocao = new MetroFramework.Controls.MetroTextBox();
            this.txbMarca = new MetroFramework.Controls.MetroTextBox();
            this.txbCodprod = new MetroFramework.Controls.MetroTextBox();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.BtnPesquisarLog = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.exportExcel = new MetroFramework.Controls.MetroButton();
            this.PreviousBtn = new MetroFramework.Controls.MetroButton();
            this.CloseBtn = new MetroFramework.Controls.MetroButton();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroButton3);
            this.metroPanel2.Controls.Add(this.metroButton2);
            this.metroPanel2.Controls.Add(this.btFiltroProd);
            this.metroPanel2.Controls.Add(this.dtFim);
            this.metroPanel2.Controls.Add(this.metroLabel6);
            this.metroPanel2.Controls.Add(this.dtInic);
            this.metroPanel2.Controls.Add(this.metroLabel5);
            this.metroPanel2.Controls.Add(this.metroLabel4);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.metroTextBox5);
            this.metroPanel2.Controls.Add(this.metroTextBox4);
            this.metroPanel2.Controls.Add(this.metroTextBox3);
            this.metroPanel2.Controls.Add(this.txbPromocao);
            this.metroPanel2.Controls.Add(this.txbMarca);
            this.metroPanel2.Controls.Add(this.txbCodprod);
            this.metroPanel2.Controls.Add(this.metroGrid1);
            this.metroPanel2.Controls.Add(this.BtnPesquisarLog);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 130);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(906, 412);
            this.metroPanel2.TabIndex = 9;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroButton3
            // 
            this.metroButton3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton3.Location = new System.Drawing.Point(147, 61);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(22, 23);
            this.metroButton3.TabIndex = 21;
            this.metroButton3.Text = "...";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(147, 32);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(22, 23);
            this.metroButton2.TabIndex = 20;
            this.metroButton2.Text = "...";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // btFiltroProd
            // 
            this.btFiltroProd.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btFiltroProd.Location = new System.Drawing.Point(147, 3);
            this.btFiltroProd.Name = "btFiltroProd";
            this.btFiltroProd.Size = new System.Drawing.Size(22, 23);
            this.btFiltroProd.TabIndex = 19;
            this.btFiltroProd.Text = "...";
            this.btFiltroProd.UseSelectable = true;
            this.btFiltroProd.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // dtFim
            // 
            this.dtFim.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(743, 7);
            this.dtFim.MaxDate = new System.DateTime(4000, 2, 1, 0, 0, 0, 0);
            this.dtFim.MinDate = new System.DateTime(2021, 2, 1, 0, 0, 0, 0);
            this.dtFim.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(150, 25);
            this.dtFim.TabIndex = 18;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(532, 17);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(49, 15);
            this.metroLabel6.TabIndex = 17;
            this.metroLabel6.Text = "Período:";
            // 
            // dtInic
            // 
            this.dtInic.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtInic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInic.Location = new System.Drawing.Point(587, 7);
            this.dtInic.MaxDate = new System.DateTime(4000, 2, 1, 0, 0, 0, 0);
            this.dtInic.MinDate = new System.DateTime(2021, 2, 1, 0, 0, 0, 0);
            this.dtInic.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtInic.Name = "dtInic";
            this.dtInic.Size = new System.Drawing.Size(150, 25);
            this.dtInic.TabIndex = 15;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(6, 69);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(63, 15);
            this.metroLabel5.TabIndex = 14;
            this.metroLabel5.Text = "Promoção:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(28, 40);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(41, 15);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "Marca:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(17, 11);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(52, 15);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Produto:";
            // 
            // metroTextBox5
            // 
            this.metroTextBox5.BackColor = System.Drawing.Color.LightGray;
            // 
            // 
            // 
            this.metroTextBox5.CustomButton.Image = null;
            this.metroTextBox5.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.metroTextBox5.CustomButton.Name = "";
            this.metroTextBox5.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox5.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox5.CustomButton.TabIndex = 1;
            this.metroTextBox5.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox5.CustomButton.UseSelectable = true;
            this.metroTextBox5.CustomButton.Visible = false;
            this.metroTextBox5.Enabled = false;
            this.metroTextBox5.Lines = new string[0];
            this.metroTextBox5.Location = new System.Drawing.Point(175, 61);
            this.metroTextBox5.MaxLength = 32767;
            this.metroTextBox5.Name = "metroTextBox5";
            this.metroTextBox5.PasswordChar = '\0';
            this.metroTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox5.SelectedText = "";
            this.metroTextBox5.SelectionLength = 0;
            this.metroTextBox5.SelectionStart = 0;
            this.metroTextBox5.ShortcutsEnabled = true;
            this.metroTextBox5.Size = new System.Drawing.Size(227, 23);
            this.metroTextBox5.TabIndex = 11;
            this.metroTextBox5.UseSelectable = true;
            this.metroTextBox5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox4
            // 
            this.metroTextBox4.BackColor = System.Drawing.Color.LightGray;
            // 
            // 
            // 
            this.metroTextBox4.CustomButton.Image = null;
            this.metroTextBox4.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.metroTextBox4.CustomButton.Name = "";
            this.metroTextBox4.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox4.CustomButton.TabIndex = 1;
            this.metroTextBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox4.CustomButton.UseSelectable = true;
            this.metroTextBox4.CustomButton.Visible = false;
            this.metroTextBox4.Enabled = false;
            this.metroTextBox4.Lines = new string[0];
            this.metroTextBox4.Location = new System.Drawing.Point(175, 32);
            this.metroTextBox4.MaxLength = 32767;
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.PasswordChar = '\0';
            this.metroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox4.SelectedText = "";
            this.metroTextBox4.SelectionLength = 0;
            this.metroTextBox4.SelectionStart = 0;
            this.metroTextBox4.ShortcutsEnabled = true;
            this.metroTextBox4.Size = new System.Drawing.Size(227, 23);
            this.metroTextBox4.TabIndex = 10;
            this.metroTextBox4.UseSelectable = true;
            this.metroTextBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox3
            // 
            this.metroTextBox3.BackColor = System.Drawing.Color.LightGray;
            // 
            // 
            // 
            this.metroTextBox3.CustomButton.Image = null;
            this.metroTextBox3.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.metroTextBox3.CustomButton.Name = "";
            this.metroTextBox3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.CustomButton.TabIndex = 1;
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Enabled = false;
            this.metroTextBox3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.metroTextBox3.Lines = new string[0];
            this.metroTextBox3.Location = new System.Drawing.Point(175, 3);
            this.metroTextBox3.MaxLength = 32767;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.SelectionLength = 0;
            this.metroTextBox3.SelectionStart = 0;
            this.metroTextBox3.ShortcutsEnabled = true;
            this.metroTextBox3.Size = new System.Drawing.Size(227, 23);
            this.metroTextBox3.TabIndex = 9;
            this.metroTextBox3.UseSelectable = true;
            this.metroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCodprod_KeyDown);
            this.metroTextBox3.Leave += new System.EventHandler(this.txbCodprod_Leave);
            // 
            // txbPromocao
            // 
            // 
            // 
            // 
            this.txbPromocao.CustomButton.Image = null;
            this.txbPromocao.CustomButton.Location = new System.Drawing.Point(44, 1);
            this.txbPromocao.CustomButton.Name = "";
            this.txbPromocao.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbPromocao.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbPromocao.CustomButton.TabIndex = 1;
            this.txbPromocao.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbPromocao.CustomButton.UseSelectable = true;
            this.txbPromocao.CustomButton.Visible = false;
            this.txbPromocao.Lines = new string[0];
            this.txbPromocao.Location = new System.Drawing.Point(75, 61);
            this.txbPromocao.MaxLength = 32767;
            this.txbPromocao.Name = "txbPromocao";
            this.txbPromocao.PasswordChar = '\0';
            this.txbPromocao.PromptText = "Código";
            this.txbPromocao.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbPromocao.SelectedText = "";
            this.txbPromocao.SelectionLength = 0;
            this.txbPromocao.SelectionStart = 0;
            this.txbPromocao.ShortcutsEnabled = true;
            this.txbPromocao.Size = new System.Drawing.Size(66, 23);
            this.txbPromocao.TabIndex = 8;
            this.txbPromocao.UseSelectable = true;
            this.txbPromocao.WaterMark = "Código";
            this.txbPromocao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbPromocao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txbPromocao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPromocao_KeyDown);
            this.txbPromocao.Leave += new System.EventHandler(this.txbPromocao_Leave);
            // 
            // txbMarca
            // 
            // 
            // 
            // 
            this.txbMarca.CustomButton.Image = null;
            this.txbMarca.CustomButton.Location = new System.Drawing.Point(44, 1);
            this.txbMarca.CustomButton.Name = "";
            this.txbMarca.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbMarca.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbMarca.CustomButton.TabIndex = 1;
            this.txbMarca.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbMarca.CustomButton.UseSelectable = true;
            this.txbMarca.CustomButton.Visible = false;
            this.txbMarca.Lines = new string[0];
            this.txbMarca.Location = new System.Drawing.Point(75, 32);
            this.txbMarca.MaxLength = 32767;
            this.txbMarca.Name = "txbMarca";
            this.txbMarca.PasswordChar = '\0';
            this.txbMarca.PromptText = "Código";
            this.txbMarca.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbMarca.SelectedText = "";
            this.txbMarca.SelectionLength = 0;
            this.txbMarca.SelectionStart = 0;
            this.txbMarca.ShortcutsEnabled = true;
            this.txbMarca.Size = new System.Drawing.Size(66, 23);
            this.txbMarca.TabIndex = 7;
            this.txbMarca.UseSelectable = true;
            this.txbMarca.WaterMark = "Código";
            this.txbMarca.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbMarca.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txbMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMarca_KeyDown);
            this.txbMarca.Leave += new System.EventHandler(this.txbMarca_Leave);
            // 
            // txbCodprod
            // 
            // 
            // 
            // 
            this.txbCodprod.CustomButton.Image = null;
            this.txbCodprod.CustomButton.Location = new System.Drawing.Point(44, 1);
            this.txbCodprod.CustomButton.Name = "";
            this.txbCodprod.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbCodprod.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbCodprod.CustomButton.TabIndex = 1;
            this.txbCodprod.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbCodprod.CustomButton.UseSelectable = true;
            this.txbCodprod.CustomButton.Visible = false;
            this.txbCodprod.Lines = new string[0];
            this.txbCodprod.Location = new System.Drawing.Point(75, 3);
            this.txbCodprod.MaxLength = 32767;
            this.txbCodprod.Name = "txbCodprod";
            this.txbCodprod.PasswordChar = '\0';
            this.txbCodprod.PromptText = "Código";
            this.txbCodprod.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbCodprod.SelectedText = "";
            this.txbCodprod.SelectionLength = 0;
            this.txbCodprod.SelectionStart = 0;
            this.txbCodprod.ShortcutsEnabled = true;
            this.txbCodprod.Size = new System.Drawing.Size(66, 23);
            this.txbCodprod.TabIndex = 6;
            this.txbCodprod.UseSelectable = true;
            this.txbCodprod.WaterMark = "Código";
            this.txbCodprod.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbCodprod.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txbCodprod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCodprod_KeyDown);
            this.txbCodprod.Leave += new System.EventHandler(this.txbCodprod_Leave);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(3, 90);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(900, 319);
            this.metroGrid1.TabIndex = 5;
            // 
            // BtnPesquisarLog
            // 
            this.BtnPesquisarLog.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BtnPesquisarLog.Location = new System.Drawing.Point(796, 57);
            this.BtnPesquisarLog.Name = "BtnPesquisarLog";
            this.BtnPesquisarLog.Size = new System.Drawing.Size(97, 27);
            this.BtnPesquisarLog.TabIndex = 4;
            this.BtnPesquisarLog.Text = "Pesquisar";
            this.BtnPesquisarLog.UseSelectable = true;
            this.BtnPesquisarLog.Click += new System.EventHandler(this.metroButton1_Click);
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
            this.metroPanel1.TabIndex = 8;
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
            this.metroLabel2.Size = new System.Drawing.Size(524, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Selecione a filtros desejada e clique em \"Pesquisar\" para verificar os logs de at" +
    "ualização.";
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
            this.metroPanel3.Controls.Add(this.exportExcel);
            this.metroPanel3.Controls.Add(this.PreviousBtn);
            this.metroPanel3.Controls.Add(this.CloseBtn);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(20, 548);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(906, 33);
            this.metroPanel3.TabIndex = 10;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // exportExcel
            // 
            this.exportExcel.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.exportExcel.Location = new System.Drawing.Point(404, 3);
            this.exportExcel.Name = "exportExcel";
            this.exportExcel.Size = new System.Drawing.Size(137, 27);
            this.exportExcel.TabIndex = 4;
            this.exportExcel.Text = "Exportar p/ Excel";
            this.exportExcel.UseSelectable = true;
            this.exportExcel.Click += new System.EventHandler(this.exportExcel_Click);
            // 
            // PreviousBtn
            // 
            this.PreviousBtn.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.PreviousBtn.Location = new System.Drawing.Point(547, 3);
            this.PreviousBtn.Name = "PreviousBtn";
            this.PreviousBtn.Size = new System.Drawing.Size(97, 27);
            this.PreviousBtn.TabIndex = 3;
            this.PreviousBtn.Text = "Anterior";
            this.PreviousBtn.UseSelectable = true;
            this.PreviousBtn.Click += new System.EventHandler(this.PreviousBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.CloseBtn.Location = new System.Drawing.Point(806, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(97, 27);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Sair";
            this.CloseBtn.UseSelectable = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 604);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormLog";
            this.Text = "Acompanhamento de Markup";
            this.Load += new System.EventHandler(this.FormLog_Load);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton PreviousBtn;
        private MetroFramework.Controls.MetroButton CloseBtn;
        private MetroFramework.Controls.MetroButton BtnPesquisarLog;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        public MetroFramework.Controls.MetroTextBox txbCodprod;
        public MetroFramework.Controls.MetroTextBox txbMarca;
        public MetroFramework.Controls.MetroTextBox txbPromocao;
        private MetroFramework.Controls.MetroTextBox metroTextBox5;
        private MetroFramework.Controls.MetroTextBox metroTextBox4;
        private MetroFramework.Controls.MetroTextBox metroTextBox3;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime dtInic;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroDateTime dtFim;
        private MetroFramework.Controls.MetroButton btFiltroProd;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton exportExcel;
    }
}