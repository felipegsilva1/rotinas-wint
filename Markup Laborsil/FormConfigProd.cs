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
using DataGridViewAutoFilter;

namespace Markup_Laborsil
{
    public partial class FormConfigProd : MetroFramework.Forms.MetroForm
    {
        public FormConfigProd()
        {
            InitializeComponent();
            ConfigurarMetroListView();
        }

        private void FormConfigProd_Load(object sender, EventArgs e)
        {
            metroPanel1.UseCustomBackColor = true;
            metroLabel1.UseCustomBackColor = true;
            metroLabel2.UseCustomBackColor = true;
            metroTextBox3.UseCustomBackColor = true;
            metroTextBox4.UseCustomBackColor = true;

            btAll.Checked = true;
            BtAllTipoAtu.Checked = true;
        }

        private void ConfigurarMetroListView()
        {
            // Configurações globais do DataGridView
            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            metroGrid1.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            metroGrid1.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            metroGrid1.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            metroGrid1.MultiSelect = false;                                           // Uma linha selecionada por vez
            metroGrid1.RowHeadersVisible = false;                                    // Oculta os headers de linha
            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;  // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            metroGrid1.Columns.Clear();

            // Adicionando coluna codProd (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codProd",
                HeaderText = "Cód. Produto",     // Nome exibido no cabeçalho
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
                Width = 340,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna codAuxiliar (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codAuxiliar",
                HeaderText = "Cód. Auxiliar",         // Nome exibido no cabeçalho
                Width = 150,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna AtualizaAuto (editável, com lista SIM/NAO)
            var comboCol = new DataGridViewComboBoxColumn();
            comboCol.Name = "atualizaAuto";
            comboCol.HeaderText = "Atualiza Automaticamente?";
            comboCol.Width = 200;
            comboCol.Items.AddRange("Sim", "Nao");
            comboCol.FlatStyle = FlatStyle.Flat;
            comboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton; // padrão
            comboCol.ReadOnly = false;

            comboCol.DefaultCellStyle.BackColor = Color.White;

            metroGrid1.Columns.Add(comboCol);

            // Adicionando coluna TipoAtuPreco (editável, com lista SIM/NAO)
            var listaTipoAtu = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("P", "Markup por Produto (P)"),
                    new KeyValuePair<string, string>("T", "Markup por Tabela de Preço (T)")
                };

            // 2. Criar coluna do tipo ComboBox
            var comboColTipoAtu = new DataGridViewComboBoxColumn();
            comboColTipoAtu.Name = "tipoAtuPreco";
            comboColTipoAtu.HeaderText = "Tipo Atualização de Preço";
            comboColTipoAtu.Width = 200;
            comboColTipoAtu.FlatStyle = FlatStyle.Flat;
            comboColTipoAtu.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            comboColTipoAtu.ReadOnly = false;
            comboColTipoAtu.DefaultCellStyle.BackColor = Color.White;

            // 3. Configurar Display/Value
            comboColTipoAtu.DataSource = listaTipoAtu;
            comboColTipoAtu.DisplayMember = "Value";
            comboColTipoAtu.ValueMember = "Key";

            // 4. Adicionar ao grid
            metroGrid1.Columns.Add(comboColTipoAtu);

            // Adicionando coluna codAuxiliar (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "percMkp",
                HeaderText = "Perc. Markup",         // Nome exibido no cabeçalho
                Width = 150,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    BackColor = Color.White
                },
                ReadOnly = false // Somente leitura
            });

            metroGrid1.CellValueChanged += MetroGrid1_CellValueChanged;
            metroGrid1.CurrentCellDirtyStateChanged += MetroGrid1_CurrentCellDirtyStateChanged;

        }

        private void MetroGrid1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Força o commit da mudança imediatamente para ComboBox
            if (metroGrid1.IsCurrentCellDirty)
            {
                metroGrid1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void MetroGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula editada é uma das colunas editáveis
            if (e.RowIndex >= 0 && (metroGrid1.Columns[e.ColumnIndex].Name == "atualizaAuto" ||
                                   metroGrid1.Columns[e.ColumnIndex].Name == "tipoAtuPreco" ||
                                   metroGrid1.Columns[e.ColumnIndex].Name == "percMkp"))
            {
                // Marca a linha como modificada alterando a cor de fundo
                MarcarLinhaComoModificada(e.RowIndex);
            }
        }

        private void MarcarLinhaComoModificada(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < metroGrid1.Rows.Count)
            {
                DataGridViewRow row = metroGrid1.Rows[rowIndex];

                // Altera a cor de fundo de todas as células da linha
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.MistyRose;
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarDadosNoMetroListView()
        {

            ProdutoDAO dao = new ProdutoDAO();

            metroGrid1.Rows.Clear();

            int? codProd = string.IsNullOrWhiteSpace(txbCodprod.Text) ? (int?)null : int.Parse(txbCodprod.Text);
            int? codMarca = string.IsNullOrWhiteSpace(txbMarca.Text) ? (int?)null : int.Parse(txbMarca.Text);
            string atualAuto = btYes.Checked ? "S" : (btNo.Checked ? "N" : null);
            string tipoAtualizacao = btMkpProd.Checked ? "P" : (btMkpTabPreco.Checked ? "T" : null);

            try
            {

                // Obtem os dados do banco
                List<Produto> dados = dao.getProdutosMkp(codProd, null, codMarca, atualAuto, tipoAtualizacao);

                foreach (Produto item in dados)
                {
                    string atualizaAuto = null; // valor padrão
                    if (!string.IsNullOrWhiteSpace(item.atualizaAuto))
                    {
                        if (item.atualizaAuto == "S")
                            atualizaAuto = "Sim";
                        else if (item.atualizaAuto == "N")
                            atualizaAuto = "Nao";
                    }

                    string tipoAtu = null; // valor padrão
                    if (!string.IsNullOrWhiteSpace(item.tipoAtuPreco))
                    {
                        if (item.tipoAtuPreco.ToUpper() == "P")
                            tipoAtu = "P";
                        else if (item.tipoAtuPreco.ToUpper() == "T")
                            tipoAtu = "T";
                    }

                    metroGrid1.Rows.Add(
                     item.codProd.ToString(),                              // Código Produto
                     item.descricao?.ToString() ?? string.Empty,          // Descricao Produto
                     item.codAuxiliar?.ToString() ?? string.Empty,       // Se atualiza automaticamente
                     atualizaAuto,                                      // Tipo de atualização do preço
                     tipoAtu,                                          // Tipo de atualização do preço
                     item.percMkp?.ToString() ?? string.Empty         // Tipo de atualização do preço
                 );
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarDadosNoMetroListView();
        }

        private void ValidarEPreencherProduto()
        {
            if (int.TryParse(txbCodprod.Text, out int codProd))
            {
                var dao = new ProdutoDAO();
                var produtos = dao.getProdutos(codProd, null);

                if (produtos != null && produtos.Count > 0)
                {
                    metroTextBox3.Text = produtos[0].descricao;
                }
                else
                {
                    metroTextBox3.Text = "";
                    MetroFramework.MetroMessageBox.Show(this, "Produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbCodprod.Text = "";
                    txbCodprod.Focus();
                }
            }
            else
            {
                metroTextBox3.Text = "";
            }
        }

        private void txbCodprod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ValidarEPreencherProduto();
                e.SuppressKeyPress = true;
            }
        }

        public void txbCodprod_Leave(object sender, EventArgs e)
        {
            ValidarEPreencherProduto();
        }

        private void ValidarEPreencherMarca()
        {
            if (int.TryParse(txbMarca.Text, out int codMarca))
            {
                var dao = new MarcaDAO();
                var marca = dao.obterMarcas(codMarca, null, null, null);

                if (marca != null && marca.Count > 0)
                {
                    metroTextBox4.Text = marca[0].descMarca;
                }
                else
                {
                    metroTextBox4.Text = "";
                    MetroFramework.MetroMessageBox.Show(this, "Marca não encontrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMarca.Text = "";
                }
            }
            else
            {
                // Limpa o campo de descrição se o código digitado não for um número válido
                metroTextBox4.Text = "";
            }
        }

        private void txbMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ValidarEPreencherMarca();
                e.SuppressKeyPress = true;
            }
        }

        public void txbMarca_Leave(object sender, EventArgs e)
        {
            ValidarEPreencherMarca();
        }

        private void btExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DadosExportados.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Dados");

                            // Cabeçalhos
                            for (int col = 0; col < metroGrid1.Columns.Count; col++)
                            {
                                worksheet.Cell(1, col + 1).Value = metroGrid1.Columns[col].HeaderText;
                            }

                            // Dados visíveis (com filtros)
                            int linha = 2;
                            foreach (DataGridViewRow row in metroGrid1.Rows)
                            {
                                if (!row.Visible) continue; // ignora linhas ocultas por filtros

                                for (int col = 0; col < metroGrid1.Columns.Count; col++)
                                {
                                    worksheet.Cell(linha, col + 1).Value = row.Cells[col].Value?.ToString();
                                }
                                linha++;
                            }

                            workbook.SaveAs(sfd.FileName);
                            MetroFramework.MetroMessageBox.Show(this, "Exportação concluída com sucesso!", "Exportar para Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Erro ao exportar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Selecione o arquivo Excel com os dados"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var path = ofd.FileName;

                    try
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook(path))
                        {
                            var ws = workbook.Worksheets.First();
                            int linhas = ws.RowsUsed().Count();

                            var confirm = MetroFramework.MetroMessageBox.Show(this,
                                $"O arquivo contém {linhas - 1} linhas (excluindo o cabeçalho).\nDeseja importar as alterações?",
                                "Confirmação de Importação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (confirm != DialogResult.Yes)
                                return;

                            CarregarDadosNoMetroListView();
                            int alteradas = 0;

                            foreach (var row in ws.RowsUsed().Skip(1)) // pula cabeçalho
                            {
                                string codProdStr = row.Cell(1).GetString().Trim();
                                string atualTo = row.Cell(2).GetString().Trim();
                                string tipoAtu = row.Cell(3).GetString().Trim();
                                string percMkpStr = row.Cell(4).GetString().Trim();

                                if (!int.TryParse(codProdStr, out int codProd))
                                    continue;

                                foreach (DataGridViewRow dgvRow in metroGrid1.Rows)
                                {
                                    if (int.TryParse(dgvRow.Cells["codProd"].Value?.ToString(), out int gridCodProd)
                                        && gridCodProd == codProd)
                                    {
                                        bool alterou = false;

                                        if (dgvRow.Cells["atualizaAuto"].Value?.ToString() != atualTo)
                                        {
                                            dgvRow.Cells["atualizaAuto"].Value = atualTo;
                                            alterou = true;
                                        }

                                        if (dgvRow.Cells["tipoAtuPreco"].Value?.ToString() != tipoAtu)
                                        {
                                            dgvRow.Cells["tipoAtuPreco"].Value = tipoAtu;
                                            alterou = true;
                                        }

                                        if (decimal.TryParse(percMkpStr, out decimal percMkpExcel))
                                        {
                                            if (decimal.TryParse(dgvRow.Cells["percMkp"].Value?.ToString(), out decimal percMkpGrid))
                                            {
                                                if (percMkpExcel != percMkpGrid)
                                                {
                                                    dgvRow.Cells["percMkp"].Value = percMkpExcel;
                                                    alterou = true;
                                                }
                                            }
                                            else
                                            {
                                                dgvRow.Cells["percMkp"].Value = percMkpExcel;
                                                alterou = true;
                                            }
                                        }

                                        if (alterou)
                                        {
                                            dgvRow.DefaultCellStyle.BackColor = Color.MistyRose;
                                            alteradas++;
                                        }

                                        break;
                                    }
                                }
                            }

                            MetroFramework.MetroMessageBox.Show(this,
                                $"Importação concluída!\n{alteradas} linha(s) foram alteradas.",
                                "Importação Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Erro ao importar: " + ex.Message,
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            var confirm = MetroFramework.MetroMessageBox.Show(
                this,
                "Deseja realmente salvar as alterações realizadas?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            // Verifica se há linhas alteradas
            bool temAlteracoes = metroGrid1.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow && r.Cells.Cast<DataGridViewCell>().Any(c => c.Style.BackColor == Color.MistyRose));

            if (!temAlteracoes)
            {
                MetroFramework.MetroMessageBox.Show(this, "Não há produtos alterados para atualização!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells.Cast<DataGridViewCell>().Any(c => c.Style.BackColor == Color.MistyRose))
                {
                    string codProdStr = row.Cells["codProd"].Value?.ToString();
                    string atualizaAutoStr = row.Cells["atualizaAuto"].Value?.ToString();
                    string tipoAtuPrecoStr = row.Cells["tipoAtuPreco"].Value?.ToString();
                    string percMkpStr = row.Cells["percMkp"].Value?.ToString();

                    if (int.TryParse(codProdStr, out int codProd) && decimal.TryParse(percMkpStr, out decimal percMkp))
                    {
                        string atualizaAuto = atualizaAutoStr == "Sim" ? "S" : "N";
                        string tipoAtuPreco = tipoAtuPrecoStr == "Markup por Produto (P)" ? "P" :
                                              tipoAtuPrecoStr == "Markup por Tabela de Preço (T)" ? "T" :
                                              tipoAtuPrecoStr;

                        var dao = new ProdutoDAO();
                        dao.AtualizarProduto(codProd, atualizaAuto, tipoAtuPreco, percMkp);
                    }
                }
            }

            MetroFramework.MetroMessageBox.Show(this, "Produtos atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarregarDadosNoMetroListView();
        }

        private void btPrevios_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConfig formConfig = new FormConfig();
            formConfig.FormClosed += (s, args) => this.Close();
            formConfig.Show();
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            var filtro = new FiltroMarcaLog();
            filtro.OnMarcaSelecionada = (codMarca) =>
            {
                txbMarca.Text = codMarca;
                txbMarca.Focus();
                txbMarca_Leave(null, EventArgs.Empty);
            };
            filtro.ShowDialog();
        }

        private void btFiltroProd_Click(object sender, EventArgs e)
        {
            var filtro = new FiltroProdLog();
            filtro.OnMarcaSelecionada = (codProd) =>
            {
                txbCodprod.Text = codProd;
                txbCodprod.Focus();
                txbCodprod_Leave(null, EventArgs.Empty);
            };
            filtro.ShowDialog();
        }
    }
}
