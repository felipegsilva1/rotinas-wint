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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Informando para o Metro que Fundo é customizado
            metroPanel1.UseCustomBackColor = true;
            metroLabel1.UseCustomBackColor = true;
            metroLabel2.UseCustomBackColor = true;

            //Informando para o "Cadastro de Marckuk" já vim selecionado
            metroRadioButton3.Checked = true;

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (metroRadioButton3.Checked)
            {
                this.Hide();
                FormCadMkpTabPreco formCadastroMkp = new FormCadMkpTabPreco();
                formCadastroMkp.FormClosed += (s, args) => this.Close();
                formCadastroMkp.Show();
            }
            else if (metroRadioButton2.Checked)
            {
                this.Hide();
                FormConfig formConfig = new FormConfig();
                formConfig.FormClosed += (s, args) => this.Close();
                formConfig.Show();
            }
            else if (metroRadioButton1.Checked)
            {
                this.Hide();
                FormLog formLog = new FormLog();
                formLog.FormClosed += (s, args) => this.Close();
                formLog.Show();
            }
        }

        private void btSobre_Click(object sender, EventArgs e)
        {
            FormSobre formSobre = new FormSobre();
            formSobre.Show();
        }
    }
}
