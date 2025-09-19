using MetroFramework.Controls;
using ServicoMacro.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicoMacro.Forms
{
    public partial class ServicosInsert : MetroFramework.Forms.MetroForm
    {
        public ServicosInsert()
        {
            InitializeComponent();
        }

        private void Servicos_Load(object sender, EventArgs e)
        {
            txbCodService.UseCustomBackColor = true;
            this.MaximizeBox = false;
            this.Resizable = false;         // impede redimensionar
            btYes.Checked = true;

            ServiceDAO serviceDAO = new ServiceDAO();
            int nextCodService = serviceDAO.getNextServiceCode();
            txbCodService.Text = nextCodService.ToString();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(metroTextBox1.Text) || string.IsNullOrWhiteSpace(metroTextBox2.Text) || string.IsNullOrWhiteSpace(metroTextBox3.Text) || string.IsNullOrWhiteSpace(metroTextBox4.Text) || string.IsNullOrWhiteSpace(metroTextBox5.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Por favor, preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string nomeService = metroTextBox1.Text.Trim();
                string dirService = metroTextBox2.Text.Trim();
                int horaService = int.TryParse(metroTextBox3.Text.Trim(), out int h) ? h : 0;
                int minutoService = int.TryParse(metroTextBox4.Text.Trim(), out int m) ? m : 0;
                string macroService = metroTextBox5.Text.Trim();
                string status = btYes.Checked ? "A" : "I"; //A - Ativo, I - Inativo


                ServiceDAO serviceDAO = new ServiceDAO();
                serviceDAO.insertService(nomeService, dirService, horaService, minutoService, null, macroService, status);
                MessageBox.Show("Serviço inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFiltroProd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione um arquivo";
                openFileDialog.Filter = "Todos os arquivos (*.*)|*.*"; // pode filtrar por .txt, .csv, etc
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Pega o caminho completo do arquivo e coloca no txtDirService
                    metroTextBox2.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
