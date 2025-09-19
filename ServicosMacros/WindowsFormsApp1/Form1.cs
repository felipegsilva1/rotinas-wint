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
using ServicoMacro.DAO;
using ServicoMacro.Model;
using ServicoMacro.Forms;

namespace ServicoMacro
{
    public partial class ServicoAutomacao : MetroFramework.Forms.MetroForm
    {
        public ServicoAutomacao()
        {
            InitializeComponent();
            ConfigurarMetroGrid();
        }

        private void ServicoAutomacao_Load(object sender, EventArgs e)
        {
            metroTextBox1.UseCustomBackColor = true;

            btAll.Checked = true;
            this.MaximizeBox = false;
            this.Resizable = false;         // impede redimensionar
        }

        private void ConfigurarMetroGrid()
        {
            // Configurações globais do DataGridView
            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            metroGrid1.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            metroGrid1.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            metroGrid1.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            metroGrid1.MultiSelect = false;                                           // Uma linha selecionada por vez
            metroGrid1.RowHeadersVisible = false;                                    // Oculta os headers de linha
            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;  // Controle manual do tamanho das colunas

            metroGrid1.Columns.Clear();

            // Adicionando coluna codService (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codService",
                HeaderText = "Cód. Serviço",     // Nome exibido no cabeçalho
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Alinhamento correto
                },
                ReadOnly = true
            });

            // Adicionando coluna nomeService (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "nomeService",
                HeaderText = "Nome Serviço",     // Nome exibido no cabeçalho
                Width = 250,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft // Alinhamento correto
                },
                ReadOnly = true
            });

            // Adicionando coluna directorService (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "directorService",
                HeaderText = "Diretório Serviço",
                Width = 350,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
                ReadOnly = true
            });

            // Adicionando coluna statusService (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "statusService",
                HeaderText = "Status Serviço",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
                ReadOnly = true
            });


        }

        private void LoadDataToGrid(List<Servicos> servicos)
        {
            metroGrid1.Rows.Clear(); // Limpa as linhas existentes
            foreach (var servico in servicos)
            {
                metroGrid1.Rows.Add(servico.codService, servico.nomeService, servico.directorService, servico.statusService);
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                int? codService = null;
                if (int.TryParse(txbCodAuto.Text, out int parsedCodService))
                {
                    codService = parsedCodService;
                }
                string status = btAll.ToString();

                if (btYes.Checked)
                {
                    status = "S";
                }
                else if(btNo.Checked)
                {
                    status = "N";
                }
                else if (btAll.Checked)
                {
                    status = null;
                }

                ServiceDAO serviceDAO = new ServiceDAO();
                List<Servicos> servicos = serviceDAO.getService(codService, status);
                LoadDataToGrid(servicos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar serviços: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtIncluirService_Click(object sender, EventArgs e)
        {
            ServicosInsert servicosForm = new ServicosInsert();
            servicosForm.ShowDialog();
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (int.TryParse(txbCodAuto.Text, out int codServices))
                {
                    var dao = new ServiceDAO();
                    var services = dao.getService(codServices, null);

                    if (services != null)
                    {
                        metroTextBox1.Text = services[0].nomeService;
                    }
                    else
                    {
                        metroTextBox1.Text = "";
                        MetroFramework.MetroMessageBox.Show(this, "Serviço não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbCodAuto.Text = "";
                    }
                } else
                {
                    metroTextBox1.Text = "";
                }
            }
        }

        private void metroTextBox1_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txbCodAuto.Text, out int codServices))
            {
                var dao = new ServiceDAO();
                var services = dao.getService(codServices, null);

                if (services != null)
                {
                    metroTextBox1.Text = services[0].nomeService;
                }
                else
                {
                    metroTextBox1.Text = "";
                    MetroFramework.MetroMessageBox.Show(this, "Serviço não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbCodAuto.Text = "";
                }
            } else
            {
                metroTextBox1.Text = "";
            }

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var dao = new ServiceDAO();
            if (metroGrid1.SelectedRows.Count > 0)
            {
                var selectedRow = metroGrid1.SelectedRows[0];
                int codService = Convert.ToInt32(selectedRow.Cells["codService"].Value);
                var confirmResult = MetroFramework.MetroMessageBox.Show(this, "Tem certeza que deseja excluir o serviço selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        dao.deleteService(codService);
                        MetroFramework.MetroMessageBox.Show(this, "Serviço excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnPesquisar_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Erro ao excluir serviço: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Por favor, selecione um serviço para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var dao = new ServiceDAO();
            if (metroGrid1.SelectedRows.Count > 0)
            {
                var selectedRow = metroGrid1.SelectedRows[0];
                int codService = Convert.ToInt32(selectedRow.Cells["codService"].Value);
                var services = dao.getService(codService, null);
                if (services != null && services.Count > 0)
                {
                    ServicosEdit editForm = new ServicosEdit(services[0]);
                    editForm.ShowDialog();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Serviço não encontrado para edição.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Por favor, selecione um serviço para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // garante que não clicou no header
            {
                var dao = new ServiceDAO();

                // pega a linha clicada
                var selectedRow = metroGrid1.Rows[e.RowIndex];
                int codService = Convert.ToInt32(selectedRow.Cells["codService"].Value);

                // busca o serviço no DAO
                var services = dao.getService(codService, null);

                if (services != null && services.Count > 0)
                {
                    ServicosEdit editForm = new ServicosEdit(services[0]);
                    editForm.ShowDialog();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this,
                        "Serviço não encontrado para edição.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

    }
}
