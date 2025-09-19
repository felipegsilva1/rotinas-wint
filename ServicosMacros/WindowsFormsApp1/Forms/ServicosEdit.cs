using ServicoMacro.DAO;
using ServicoMacro.Model;
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
    public partial class ServicosEdit : MetroFramework.Forms.MetroForm
    {
        private Servicos _service;
        public ServicosEdit(Servicos service)
        {
            InitializeComponent();
            _service = service;
        }

        private void ServicosEdit_Load(object sender, EventArgs e)
        {
            txbCodService.UseCustomBackColor = true;
            this.MaximizeBox = false;
            this.Resizable = false;         // impede redimensionar
            btYes.Checked = true;

            if (_service != null)
            {
                txbCodService.Text = _service.codService.ToString();
                txtNomeService.Text = _service.nomeService.ToString();
                txtDirService.Text = _service.directorService.ToString();
                txtMacroService.Text = _service.macroService.ToString();
                txtHoraService.Text = _service.horaService.ToString();
                txtMinService.Text = _service.minutoService.ToString();
                if (_service.statusService == "A")
                    btYes.Checked = true;
                else
                    btNo.Checked = true;
            }

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSalve_Click(object sender, EventArgs e)
        {
            try
            {
                // Monta o objeto Service com os dados da tela
                Servicos service = new Servicos
                {
                    codService = Convert.ToInt32(txbCodService.Text),
                    nomeService = txtNomeService.Text,
                    directorService = txtDirService.Text,
                    horaService = Convert.ToInt32(txtHoraService.Text),
                    minutoService = Convert.ToInt32(txtMinService.Text),
                    dataService = DateTime.Now,
                    macroService = txtMacroService.Text,
                    statusService = btYes.Checked ? "A" : "I"
                };

                // Chama o DAO para atualizar
                ServiceDAO dao = new ServiceDAO();
                bool atualizado = dao.updateService(service);

                if (atualizado)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Serviço atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Não foi possível atualizar o serviço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Erro ao salvar serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtDirService.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
