using DocumentFormat.OpenXml.Wordprocessing;
using Markup_Laborsil.DAO;
using Markup_Laborsil.Model;
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
    public partial class FormConfigTabPreco : MetroFramework.Forms.MetroForm
    {
        private MetroFramework.Controls.MetroLabel metroLabelStatus;
        private bool dadosCarregados = false;
        public FormConfigTabPreco()
        {
            InitializeComponent();
            ConfigurarMetroListView1();
            ConfigurarMetroListView2();

            // ✅ Corrigido: usa o campo da classe
            metroLabelStatus = new MetroFramework.Controls.MetroLabel();
            metroLabelStatus.Name = "metroLabelStatus";
            metroLabelStatus.Text = "Carregando dados...";
            metroLabelStatus.Visible = false;
            metroLabelStatus.Location = new Point(10, 10); // Ajuste conforme o layout
            metroLabelStatus.AutoSize = true;

            // Adiciona ao formulário
            this.Controls.Add(metroLabelStatus);

            this.Shown += FormConfigTabPreco_Shown;
        }


        private void FormConfigTabPreco_Load(object sender, EventArgs e)
        {
            metroPanel1.UseCustomBackColor = true;
            metroLabel1.UseCustomBackColor = true;
            metroLabel2.UseCustomBackColor = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarMetroListView1()
        {
            // Configurações globais do DataGridView
            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            metroGrid1.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            metroGrid1.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            metroGrid1.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            metroGrid1.MultiSelect = false;                                          // Uma linha selecionada por vez
            metroGrid1.RowHeadersVisible = false;                                   // Oculta os headers de linha
            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            metroGrid1.Columns.Clear();

            // Adicionando coluna codPromocao (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codPromocao",
                HeaderText = "Cód. Promoção",     // Nome exibido no cabeçalho
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Alinhamento correto
                },
                ReadOnly = true
            });

            // Adicionando coluna descricao (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "descricao",
                HeaderText = "Descrição",         // Nome exibido no cabeçalho
                Width = 230,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });
        }

        private void ConfigurarMetroListView2()
        {
            // Configurações globais do DataGridView
            metroGrid2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            metroGrid2.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            metroGrid2.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            metroGrid2.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            metroGrid2.MultiSelect = false;                                          // Uma linha selecionada por vez
            metroGrid2.RowHeadersVisible = false;                                   // Oculta os headers de linha
            metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            metroGrid2.Columns.Clear();

            // Adicionando coluna codPromocao (apenas leitura)
            metroGrid2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codPromocao",
                HeaderText = "Cód. Promoção",     // Nome exibido no cabeçalho
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Alinhamento correto
                },
                ReadOnly = true
            });

            // Adicionando coluna descricao (apenas leitura)
            metroGrid2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "descricao",
                HeaderText = "Descrição",         // Nome exibido no cabeçalho
                Width = 230,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });
        }

        private void CarregarDadosTabPromoWinthor()
        {
            CabPromocaoDAO dao = new CabPromocaoDAO();

            try
            {
                // ⚠️ Limpar o grid na thread da interface
                this.Invoke((MethodInvoker)delegate
                {
                    metroGrid1.Rows.Clear();
                });

                // Obtem os dados do banco
                List<CabPromocao> dados = dao.ObterCabecalhoPromocoes(null, null);

                foreach (CabPromocao item in dados)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        metroGrid1.Rows.Add(
                            item.codPromocao.ToString(),
                            item.descPromocao?.ToString() ?? string.Empty
                        );
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                this.Invoke((MethodInvoker)delegate
                {
                    MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }

        private void CarregarDadosTabMarkup()
        {
            CabPromocaoDAO dao = new CabPromocaoDAO();

            try
            {
                // ⚠️ Limpar o grid na thread da interface
                this.Invoke((MethodInvoker)delegate
                {
                    metroGrid2.Rows.Clear();
                });

                // Obtem os dados do banco
                List<CabPromocao> dados = dao.getPromocoesparaAtualizacao();

                foreach (CabPromocao item in dados)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        metroGrid2.Rows.Add(
                            item.codPromocao.ToString(),
                            item.descPromocao?.ToString() ?? string.Empty
                        );
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                this.Invoke((MethodInvoker)delegate
                {
                    MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }

        private async void FormConfigTabPreco_Shown(object sender, EventArgs e)
        {
            if (dadosCarregados) return; // Já carregou? Sai fora.
            dadosCarregados = true;

            metroLabelStatus.Text = "Carregando dados...";
            metroLabelStatus.Visible = true;

            await Task.Run(() => CarregarDadosTabPromoWinthor());
            await Task.Run(() => CarregarDadosTabMarkup());

            metroLabelStatus.Visible = false;
        }

        private void btPrevios_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConfig formConfig = new FormConfig();
            formConfig.FormClosed += (s, args) => this.Close();
            formConfig.Show();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Selecione uma promoção para inserir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = metroGrid1.SelectedRows[0];
            string codPromocao = selectedRow.Cells[0].Value?.ToString();

            // Verifica se já existe no metroGrid2
            foreach (DataGridViewRow row in metroGrid2.Rows)
            {
                if (row.Cells[0].Value?.ToString() == codPromocao)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Esta promoção já foi adicionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Adiciona no metroGrid2
            int rowIndex = metroGrid2.Rows.Add();
            metroGrid2.Rows[rowIndex].Cells[0].Value = selectedRow.Cells[0].Value; // cod
            metroGrid2.Rows[rowIndex].Cells[1].Value = selectedRow.Cells[1].Value; // desc

            // Linha verde
            metroGrid2.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (metroGrid2.SelectedRows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Selecione uma promoção para remover da regra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MetroFramework.MetroMessageBox.Show(this, "Deseja realmente remover esta promoção da regra?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = metroGrid2.SelectedRows[0];

                // Marcar a linha de vermelho (não excluir ainda)
                selectedRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var resultado = MetroFramework.MetroMessageBox.Show(
                this,
                "Deseja realmente alterar as configurações da regra?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            var dao = new CabPromocaoDAO();

            foreach (DataGridViewRow row in metroGrid2.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var codPromocaoObj = row.Cells[0].Value;
                var descricaoObj = row.Cells[1].Value;

                if (codPromocaoObj == null)
                    continue;

                int codPromocao;
                if (!int.TryParse(codPromocaoObj.ToString(), out codPromocao))
                    continue;

                string descricao = descricaoObj?.ToString() ?? "";

                var backColor = row.DefaultCellStyle.BackColor;

                if (backColor == System.Drawing.Color.LightGreen)
                {
                    dao.InsertTabPreco(codPromocao, descricao);
                }
                else if (backColor == System.Drawing.Color.LightCoral)
                {
                    dao.DeletarTabPreco(codPromocao);
                }
            }

            MetroFramework.MetroMessageBox.Show(this, "Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarDadosTabPromoWinthor();
            CarregarDadosTabMarkup();
        }



    }
}
