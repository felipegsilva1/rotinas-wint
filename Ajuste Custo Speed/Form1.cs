using Ajuste_Custo_Speed.DAO;
using Ajuste_Custo_Speed.Model;
using ExcelDataReader;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Ajuste_Custo_Speed
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            CarregarMetroviewList();
            btListBox.Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btListBox.Text = "Custo Real";
        }   

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarMetroviewList()
        {
            // Configurações globais do DataGridView
            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            metroGrid1.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            metroGrid1.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            metroGrid1.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            metroGrid1.ReadOnly = true;                                               // Apenas leitura (se aplicável)
            metroGrid1.MultiSelect = false;                                          // Uma linha selecionada por vez
            metroGrid1.RowHeadersVisible = false;                                   // Oculta os headers de linha
            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            metroGrid1.Columns.Clear();

            // Adicionando coluna CodigoProduto
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProduto",
                HeaderText = "Código Produto",     // Nome exibido no cabeçalho
                Width = 135,                      // Largura da coluna em pixels
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Descricao
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Descricao",
                HeaderText = "Descrição",         // Nome exibido no cabeçalho
                Width = 300,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Descricao
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Custo",
                HeaderText = "Vlr Novo Custo",         // Nome exibido no cabeçalho
                Width = 140,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Arquivos Suportados (*.xlsx;*.xls;*.csv)|*.xlsx;*.xls;*.csv|" +
                             "Arquivos Excel (*.xlsx;*.xls)|*.xlsx;*.xls|" +
                             "Arquivos CSV (*.csv)|*.csv",
                    Title = "Selecione o arquivo de layout"
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                ProdutoDAO produtodao = new ProdutoDAO();

                if (openFileDialog.FileName.EndsWith(".xlsx") || openFileDialog.FileName.EndsWith(".xls"))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var config = new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true
                            }
                        };

                        var result = reader.AsDataSet(config);
                        var tabela = result.Tables[0];

                        metroGrid1.Rows.Clear();

                        foreach (DataRow linha in tabela.Rows)
                        {
                            if (int.TryParse(linha[0]?.ToString(), out int codigoProduto) &&
                                decimal.TryParse(linha[1]?.ToString(), out decimal custoNovo))
                            {
                                var produtos = produtodao.getProdutos(codigoProduto);
                                string descricaoBanco = produtos?.Count > 0 ? produtos[0].Descricao : "NÃO ENCONTRADO";

                                metroGrid1.Rows.Add(codigoProduto, descricaoBanco, custoNovo.ToString("N2"));
                            }
                        }
                    }
                }
                else if (openFileDialog.FileName.EndsWith(".csv"))
                {
                    var linhas = File.ReadAllLines(openFileDialog.FileName);
                    metroGrid1.Rows.Clear();

                    foreach (var linha in linhas.Skip(1))
                    {
                        var colunas = linha.Split(';');
                        if (colunas.Length >= 3 &&
                            int.TryParse(colunas[0], out int codigoProduto) &&
                            decimal.TryParse(colunas[2], out decimal custoNovo))
                        {
                            var produtos = produtodao.getProdutos(codigoProduto);
                            string descricaoBanco = produtos?.Count > 0 ? produtos[0].Descricao : "NÃO ENCONTRADO";

                            metroGrid1.Rows.Add(codigoProduto, descricaoBanco, custoNovo.ToString("N2"));
                        }
                    }
                }
            }
            catch (System.IO.IOException)
            {
                string mensagem = "❌ **Erro ao importar planilha**\n\n" +
                                  "O arquivo está sendo usado por outro programa.\n" +
                                  "**Soluções:**\n" +
                                  "• Feche o arquivo no Excel ou outro programa\n" +
                                  "• Verifique se não há outros processos usando o arquivo\n";

                MetroFramework.MetroMessageBox.Show(this, mensagem, "Arquivo em Uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao importar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btSalvar_Click(object sender, EventArgs e)
        {
            // Criar e configurar a ProgressBar
            ProgressBar progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 50,
                Dock = DockStyle.Bottom
            };
            this.Controls.Add(progressBar);

            // Label para mostrar status
            Label lblStatus = new Label
            {
                Text = "Carregando dados...",
                Dock = DockStyle.Bottom
            };
            this.Controls.Add(lblStatus);

            btSalvar.Enabled = false;

            try
            {
                string custoEscolhido = btListBox.Text;
                string colunaCusto;

                switch (custoEscolhido)
                {
                    case "Custo Contábil": colunaCusto = "custocont"; break;
                    case "Custo Real": colunaCusto = "custoreal"; break;
                    case "Custo Real sem ST": colunaCusto = "custorealsemst"; break;
                    case "Custo Financeiro": colunaCusto = "custofin"; break;
                    case "Custo de Reposição": colunaCusto = "custorep"; break;
                    case "Custo últ. Entrada": colunaCusto = "custoultent"; break;
                    case "Valor da última entrada": colunaCusto = "valorultent"; break;
                    case "Valor da última entrada sem ST": colunaCusto = "vlultentcontsemst"; break;
                    default:
                        throw new ArgumentException("Custo inválido selecionado");
                }

                if (metroGrid1.Rows.Count == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Nenhum dado para salvar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Executa o update em background sem travar a UI
                await Task.Run(() =>
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    foreach (DataGridViewRow row in metroGrid1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            try
                            {
                                int codprod = Convert.ToInt32(row.Cells["CodigoProduto"].Value);
                                decimal novoCusto = Convert.ToDecimal(row.Cells["Custo"].Value);

                                produtoDAO.atualizarCusto(codprod, novoCusto, colunaCusto);
                            }
                            catch (Exception exRow)
                            {
                                // Se quiser registrar, use log, pois não podemos mostrar MessageBox aqui (UI thread)
                                Console.WriteLine($"Erro linha {row.Index + 1}: {exRow.Message}");
                            }
                        }
                    }
                });

                MetroFramework.MetroMessageBox.Show(this, "Atualização concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Erro inesperado:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btSalvar.Enabled = true;
                this.Controls.Remove(progressBar);
                this.Controls.Remove(lblStatus);
            }
        }
    }
}
