using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Markup_Laborsil
{
    public partial class FormConfig : MetroFramework.Forms.MetroForm
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            // Informando para o Metro que Fundo é customizado
            metroPanel1.UseCustomBackColor = true;
            metroLabel1.UseCustomBackColor = true;
            metroLabel2.UseCustomBackColor = true;

            //Informando para o "Cadastro de Marckuk" já vim selecionado
            btConfigMarca.Checked = true;
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formPrincipal = new Form1();
            formPrincipal.FormClosed += (s, args) => this.Close();
            formPrincipal.Show();
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            if (btConfigMarca.Checked)
            {
                this.Hide();
                FormConfigMarca formConfigMarca = new FormConfigMarca();
                formConfigMarca.FormClosed += (s, args) => this.Close();
                formConfigMarca.Show();
            }
            else if (btConfigProd.Checked)
            {
                this.Hide();
                FormConfigProd formConfigProd = new FormConfigProd();
                formConfigProd.FormClosed += (s, args) => this.Close();
                formConfigProd.Show();

            }
            else if (btConfigTabPreco.Checked)
            {
                this.Hide();
                FormConfigTabPreco formConfigTabPreco = new FormConfigTabPreco();
                formConfigTabPreco.FormClosed += (s, args) => this.Close();
                formConfigTabPreco.Show();
            }
        }
    }
}
