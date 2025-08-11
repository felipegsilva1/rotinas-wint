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
    public partial class FormCadastroMkp : MetroFramework.Forms.MetroForm
    {
        public FormCadastroMkp()
        {
            InitializeComponent();
        }



        private void FormCadastroMkp_Load(object sender, EventArgs e)
        {
            // Informando para o Metro que Fundo é customizado
            metroPanel1.UseCustomBackColor = true;
            metroLabel1.UseCustomBackColor = true;
            metroLabel2.UseCustomBackColor = true;

            //Informando para o "Cadastro de Marckuk" já vim selecionado
            btnMkpProduto.Checked = true;

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

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (btnMkpProduto.Checked)
            {
                
            }
            else if (btnMkpTabPreco.Checked)
            {
                this.Hide();
                FormCadMkpTabPreco formCadMkpTabPreco= new FormCadMkpTabPreco();
                formCadMkpTabPreco.FormClosed += (s, args) => this.Close();
                formCadMkpTabPreco.Show();

            }
        }
    }
}
