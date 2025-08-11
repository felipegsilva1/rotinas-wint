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
using ClosedXML.Excel;

namespace Markup_Laborsil
{
    public partial class FormCadMkpTabPreco : MetroFramework.Forms.MetroForm
    {
        private List<MkpPromocao> dadosImportados = new List<MkpPromocao>();

        public FormCadMkpTabPreco()
        {
            InitializeComponent();
            ConfigurarMetroGrid1_AbaPrincipal();
            CarregarMetroGridPromocoes();
            CarregarMetroGridProds();
        }

        private void FormCadMkpProd_Load(object sender, EventArgs e)
        {
            metroPanel1.UseCustomBackColor = true;
            metroLabel1.UseCustomBackColor = true;
            metroLabel2.UseCustomBackColor = true;
            metroTextBox3.UseCustomBackColor = true;
            metroTextBox4.UseCustomBackColor = true;
            metroTextBox5.UseCustomBackColor = true;

            BtAllTipoAtu.Checked = true;
            CheckBtnUpdate.Checked = true;
            CheckBtnExcluirTudo.Checked = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrevios_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCadastroMkp formCadMkp = new FormCadastroMkp();
            formCadMkp.FormClosed += (s, args) => this.Close();
            formCadMkp.Show();
        }

        private void ConfigurarMetroGrid1_AbaPrincipal()
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
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Alinhamento correto
                },
                ReadOnly = true
            });

            // Adicionando coluna descricao (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "descProd",
                HeaderText = "Descrição",         // Nome exibido no cabeçalho
                Width = 300,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna codAuxiliar (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codMarca",
                HeaderText = "Cód. Marca",         // Nome exibido no cabeçalho
                Width = 130,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna Marca (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "marca",
                HeaderText = "Marca",         // Nome exibido no cabeçalho
                Width = 150,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna codPromo (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codPromo",
                HeaderText = "Cód. Promoção",         // Nome exibido no cabeçalho
                Width = 130,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna Promoção (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Promocao",
                HeaderText = "Promoção",         // Nome exibido no cabeçalho
                Width = 210,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna percMkp (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "permkp",
                HeaderText = "Perc. Markup",         // Nome exibido no cabeçalho
                Width = 130,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                },
                ReadOnly = false // Somente leitura
            });


        }

        private void CarregarDadosMetroGrid1_AbaPrincipal()
        {

            MkpPromocaoDAO dao = new MkpPromocaoDAO();

            metroGrid1.Rows.Clear();

            int? codProd = string.IsNullOrWhiteSpace(txbCodprod.Text) ? (int?)null : int.Parse(txbCodprod.Text);
            int? codMarca = string.IsNullOrWhiteSpace(txbMarca.Text) ? (int?)null : int.Parse(txbMarca.Text);
            int? codPromo = string.IsNullOrWhiteSpace(txbPromocao.Text) ? (int?)null : int.Parse(txbPromocao.Text);

            try
            {

                // Obtem os dados do banco
                List<MkpPromocao> dados = dao.getMkpPromocao(codProd, codPromo, codMarca);

                foreach (MkpPromocao item in dados)
                {
                    metroGrid1.Rows.Add(
                     item.codProd.ToString(),                               // Código Produto
                     item.descProd?.ToString() ?? string.Empty,            // Descricao Produto
                     item.codMarca.ToString() ?? string.Empty,            // Se atualiza automaticamente
                     item.marca?.ToString() ?? string.Empty,             // Tipo de atualização do preço
                     item.codPromocao.ToString(),                       // Tipo de atualização do preço
                     item.descPromocao?.ToString() ?? string.Empty,    // Descricao Promoção
                     item.permkp.ToString() ?? string.Empty           // Tipo de atualização do preço
                 );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btPesquisar_Click(object sender, EventArgs e)
        {
            CarregarDadosMetroGrid1_AbaPrincipal();
        }

        private void txbCodprod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (int.TryParse(txbCodprod.Text, out int codProd))
                {
                    var dao = new ProdutoDAO();
                    var produtos = dao.getProdutos(codProd, null);

                    if (produtos != null)
                    {
                        metroTextBox3.Text = produtos[1].descricao;
                    }
                    else
                    {
                        metroTextBox3.Text = "";
                        MetroFramework.MetroMessageBox.Show(this, "Produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbCodprod.Text = "";
                    }
                }
            }
        }

        public void txbCodprod_Leave(object sender, EventArgs e)
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
                }
            }
            else
            {
                metroTextBox3.Text = "";
            }
        }

        private void txbMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (int.TryParse(txbMarca.Text, out int codMarca))
                {
                    var dao = new MarcaDAO();
                    var marca = dao.obterMarcas(codMarca, null);

                    if (marca != null)
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
            }
        }

        public void txbMarca_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txbMarca.Text, out int codMarca))
            {
                var dao = new MarcaDAO();
                var marca = dao.obterMarcas(codMarca, null);

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
                metroTextBox4.Text = "";
            }
        }

        private void txbPromocao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (int.TryParse(txbPromocao.Text, out int codPromo))
                {
                    var dao = new CabPromocaoDAO();
                    var promo = dao.ObterCabecalhoPromocoes(codPromo, null);

                    if (promo != null)
                    {
                        metroTextBox5.Text = promo[0].descPromocao;
                    }
                    else
                    {
                        metroTextBox5.Text = "";
                        MetroFramework.MetroMessageBox.Show(this, "Promoção não encontrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbPromocao.Text = "";
                    }
                }
            }
        }

        public void txbPromocao_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txbPromocao.Text, out int codPromo))
            {
                var dao = new CabPromocaoDAO();
                var promo = dao.ObterCabecalhoPromocoes(codPromo, null);

                if (promo != null && promo.Count > 0)
                {
                    metroTextBox5.Text = promo[0].descPromocao;
                }
                else
                {
                    metroTextBox5.Text = "";
                    MetroFramework.MetroMessageBox.Show(this, "Promoção não encontrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbPromocao.Text = "";
                }
            }
            else
            {
                metroTextBox5.Text = "";
            }
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

        private void btFiltroMarca_Click(object sender, EventArgs e)
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

        private void btFiltroPromo_Click(object sender, EventArgs e)
        {
            var filtro = new FiltroPromoLog();
            filtro.OnMarcaSelecionada = (codPromo) =>
            {
                txbPromocao.Text = codPromo;
                txbPromocao.Focus();
                txbPromocao_Leave(null, EventArgs.Empty);
            };
            filtro.ShowDialog();
        }

        private void CarregarMetroGridPromocoes()
        {
            // Configurações globais do DataGridView
            metroGrid2.AutoGenerateColumns = false;
            metroGrid2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            metroGrid2.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            metroGrid2.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            metroGrid2.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            metroGrid2.MultiSelect = false;                                           // Uma linha selecionada por vez
            metroGrid2.RowHeadersVisible = false;                                    // Oculta os headers de linha
            metroGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;  // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            metroGrid2.Columns.Clear();

            // Adicionando coluna codProd (apenas leitura)
            metroGrid2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codPromo",
                HeaderText = "Cód. Promoção",     // Nome exibido no cabeçalho
                DataPropertyName = "CodPromocao", // Nome da propriedade do modelo de dados
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.NotSet
                },
                ReadOnly = true
            });

            // Adicionando coluna descricao (apenas leitura)
            metroGrid2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "descricao",
                HeaderText = "Descrição",         // Nome exibido no cabeçalho
                DataPropertyName = "Descricao", // Nome da propriedade do modelo de dados
                Width = 250,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });
        }

        private void CarregarMetroGridProds()
        {
            // Configurações globais do DataGridView
            metroGrid3.AutoGenerateColumns = false;
            metroGrid3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            metroGrid3.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            metroGrid3.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            metroGrid3.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            metroGrid3.MultiSelect = false;                                           // Uma linha selecionada por vez
            metroGrid3.RowHeadersVisible = false;                                    // Oculta os headers de linha
            metroGrid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;  // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            metroGrid3.Columns.Clear();

            // Adicionando coluna codProd (apenas leitura)
            metroGrid3.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "codProd",
                HeaderText = "Cód. Produto",     // Nome exibido no cabeçalho
                DataPropertyName = "CodProd",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Alinhamento correto
                },
                ReadOnly = true
            });

            // Adicionando coluna descricao (apenas leitura)
            metroGrid3.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "descricao",
                HeaderText = "Descrição",         // Nome exibido no cabeçalho
                DataPropertyName = "Descricao",
                Width = 340,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna Marca (apenas leitura)
            metroGrid3.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Marca",
                HeaderText = "Marca",         // Nome exibido no cabeçalho
                DataPropertyName = "Marca",
                Width = 150,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna percMkp (apenas leitura)
            metroGrid3.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "percMkp",
                HeaderText = "Perc. Markup",         // Nome exibido no cabeçalho
                DataPropertyName = "PercMkp",
                Width = 140,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                },
                ReadOnly = false // Somente leitura
            });
        }

        private void BtnExportarLayout_Click(object sender, EventArgs e)
        {
            // 1. Criar e configurar a janela de diálogo para salvar o arquivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivo Excel (*.xlsx)|*.xlsx", // Filtro para mostrar apenas arquivos .xlsx
                Title = "Salvar Layout da Planilha",
                FileName = "Layout_Importacao_Produtos.xlsx" // Nome padrão do arquivo
            };

            // 2. Mostrar a janela e verificar se o usuário clicou em "OK"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Criar um novo arquivo Excel em memória
                    using (var workbook = new XLWorkbook())
                    {
                        // 4. Adicionar uma nova planilha
                        var worksheet = workbook.Worksheets.Add("Layout");

                        // 5. Adicionar os cabeçalhos nas células da primeira linha
                        worksheet.Cell("A1").Value = "Cód. do Produto";
                        worksheet.Cell("B1").Value = "Cód. Promoção";
                        worksheet.Cell("C1").Value = "Perc. Markup";

                        // --- Bônus: Melhorando a aparência da planilha ---

                        // Coloca a primeira linha (cabeçalho) em negrito
                        worksheet.Row(1).Style.Font.Bold = true;

                        // Ajusta a largura das colunas ao conteúdo
                        worksheet.Columns().AdjustToContents();

                        // ------------------------------------------------

                        // 6. Salvar o arquivo no caminho que o usuário escolheu
                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    // 7. Informar o usuário que o arquivo foi salvo com sucesso
                    MessageBox.Show("O layout da planilha foi exportado com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Em caso de erro, informar o usuário
                    MessageBox.Show($"Ocorreu um erro ao exportar o layout: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivos Excel (*.xlsx)|*.xlsx",
                Title = "Selecione o arquivo de layout"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dadosImportados.Clear();
                using (var workbook = new XLWorkbook(openFileDialog.FileName))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        dadosImportados.Add(new MkpPromocao
                        {
                            codProd = row.Cell(1).GetValue<int>(),
                            codPromocao = row.Cell(2).GetValue<int>(),
                            permkp = row.Cell(3).GetValue<decimal>()
                        });
                    }
                }

                CabPromocaoDAO promocaoDAO = new CabPromocaoDAO();
                List<CabPromocao> promocao = promocaoDAO.ObterCabecalhoPromocoes(null, null);
                Dictionary<int?, CabPromocao> marcaLookup = promocao.ToDictionary(p => p.codPromocao);

                var promocoes = dadosImportados
                    .Select(p => p.codPromocao)
                    .Distinct()
                    .Select(p => {
                        CabPromocao cabpromocao;
                        marcaLookup.TryGetValue(Convert.ToInt32(p), out cabpromocao);

                        string descricao = cabpromocao != null ? cabpromocao.descPromocao : "Descrição não encontrada";

                        return new
                        {
                            CodPromocao = p,        // Do seu MkpPromocao
                            Descricao = descricao,  // Do CabPromocao
                        };
                    })
                    .ToList();

                metroGrid2.DataSource = promocoes;
            }
        }

        private void metroGrid2_SelectionChanged(object sender, EventArgs e)
        {
            this.metroGrid2.SelectionChanged -= metroGrid2_SelectionChanged;

            try
            {
                if (metroGrid2.SelectedRows.Count == 0)
                {
                    metroGrid3.DataSource = null;
                    return;
                }

                var selectedRow = metroGrid2.SelectedRows[0];

                if (selectedRow.Cells["codPromo"].Value == null)
                {
                    return;
                }

                int codPromocaoSelecionada = Convert.ToInt32(selectedRow.Cells["codPromo"].Value);


                ProdutoDAO produtoDao = new ProdutoDAO();
                MarcaDAO marcaDao = new MarcaDAO();

                List<Produto> todosProdutos = produtoDao.getProdutosMkp(null, null, null, null, null);
                Dictionary<int, Produto> produtosLookup = todosProdutos.ToDictionary(p => p.codProd);

                var produtosDaPromocao = dadosImportados
                    .Where(p => p.codPromocao == codPromocaoSelecionada)
                    .Select(p => {
                        Produto produtoDetalhes;
                        produtosLookup.TryGetValue(Convert.ToInt32(p.codProd), out produtoDetalhes);

                        string descricao = produtoDetalhes != null ? produtoDetalhes.descricao : "Descrição não encontrada";
                        string descricaoMarca = null;

                        if (produtoDetalhes != null)
                        {
                            List<Marca> marcasEncontradas = marcaDao.obterMarcas(produtoDetalhes.codMarca, null);
                            descricaoMarca = marcasEncontradas.Count > 0 ? marcasEncontradas[0].descMarca : "Marca não encontrada";
                        }

                        return new
                        {
                            CodProd = p.codProd,               // Do seu MkpPromocao
                            Descricao = descricao,            // Do ProdutoDAO
                            Marca = descricaoMarca,          // Do ProdutoDAO
                            PercMkp = p.permkp              // Do seu MkpPromocao
                        };
                    })
                    .ToList();

                metroGrid3.DataSource = produtosDaPromocao;
            }
            finally
            {
                this.metroGrid2.SelectionChanged += metroGrid2_SelectionChanged;
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            MkpPromocaoDAO mkpPromocaoDao = new MkpPromocaoDAO();

            // Prepara os lookups para otimização de performance
            ProdutoDAO produtoDao = new ProdutoDAO();
            List<Produto> todosProdutos = produtoDao.getProdutosMkp(null, null, null, null, null);
            Dictionary<int, Produto> produtosLookup = todosProdutos.ToDictionary(p => p.codProd);

            MarcaDAO marcaDao = new MarcaDAO();
            List<Marca> todasMarcas = marcaDao.obterMarcas(null, null);
            Dictionary<int, Marca> marcasLookup = todasMarcas.ToDictionary(m => m.CodMarca);

            CabPromocaoDAO cabPromocaoDao = new CabPromocaoDAO();
            List<CabPromocao> todasCabPromocoes = cabPromocaoDao.ObterCabecalhoPromocoes();
            Dictionary<int?, CabPromocao> cabPromocaoLookup = todasCabPromocoes.ToDictionary(cp => cp.codPromocao);


            if (CheckBtnExcluirTudo.Checked)
            {
                DialogResult result = MetroFramework.MetroMessageBox.Show(this,
                    "O checkbox 'Excluir todos' está marcado. Isso apagará todas as informações da tabela. Deseja continuar?",
                    "Confirmação de Exclusão Total",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    mkpPromocaoDao.DeletarMkpPromocao(null, null);

                    // Após a exclusão total, insere todos os itens de dadosImportados
                    foreach (var itemMkp in dadosImportados)
                    {
                        int? currentCodProd = itemMkp.codProd;
                        decimal currentPerMkp = itemMkp.permkp;
                        int? currentCodPromo = itemMkp.codPromocao;

                        if (!currentCodProd.HasValue || !currentCodPromo.HasValue)
                        {
                            continue;
                        }

                        // Busca detalhes para a inserção (produto, marca, promoção)
                        Produto produtoDetalhes;
                        produtosLookup.TryGetValue(currentCodProd.Value, out produtoDetalhes);
                        string descricaoProduto = produtoDetalhes != null ? produtoDetalhes.descricao : "Descrição não encontrada";
                        int codmarca = produtoDetalhes != null && produtoDetalhes.codMarca.HasValue ? Convert.ToInt32(produtoDetalhes.codMarca) : 0;

                        string descricaoMarca = "Marca não encontrada";
                        if (produtoDetalhes != null && produtoDetalhes.codMarca.HasValue)
                        {
                            Marca marcaEncontrada;
                            if (marcasLookup.TryGetValue(Convert.ToInt32(produtoDetalhes.codMarca), out marcaEncontrada))
                            {
                                descricaoMarca = marcaEncontrada.descMarca;
                            }
                        }

                        string promocaoText = "Promoção não encontrada";
                        CabPromocao cabPromocaoDetalhes;
                        if (cabPromocaoLookup.TryGetValue(currentCodPromo, out cabPromocaoDetalhes))
                        {
                            promocaoText = cabPromocaoDetalhes.descPromocao;
                        }

                        mkpPromocaoDao.InsertMkpPromocao(
                            currentCodProd.Value,
                            currentPerMkp,
                            descricaoProduto,
                            descricaoMarca,
                            currentCodPromo.Value,
                            promocaoText,
                            codmarca
                        );
                    }
                    MessageBox.Show("Todos os dados foram excluídos e os novos dados foram inseridos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                foreach (var itemMkp in dadosImportados)
                {
                    int? currentCodProd = itemMkp.codProd;
                    decimal currentPerMkp = itemMkp.permkp;
                    int? currentCodPromo = itemMkp.codPromocao;

                    // Verifica se o produto já existe para esta promoção
                    bool existe = mkpPromocaoDao.VerificarExisteProdutoEmPromocao(currentCodProd.Value, currentCodPromo.Value);

                    if (existe)
                    {
                        // Se existe, atualiza o registro
                        mkpPromocaoDao.AtualizarMkpPromocao(currentCodProd.Value, currentCodPromo.Value, currentPerMkp);
                    }
                    else
                    {
                        // Se não existe, insere um novo registro
                        Produto produtoDetalhes = null;
                        string descricaoProduto = "Descrição não encontrada";
                        produtosLookup.TryGetValue(currentCodProd.Value, out produtoDetalhes);
                        descricaoProduto = produtoDetalhes != null ? produtoDetalhes.descricao : "Descrição não encontrada";
                        int codmarca = produtoDetalhes != null && produtoDetalhes.codMarca.HasValue ? Convert.ToInt32(produtoDetalhes.codMarca) : 0;

                        string descricaoMarca = "Marca não encontrada";
                        if (produtoDetalhes != null && produtoDetalhes.codMarca.HasValue)
                        {
                            Marca marcaEncontrada;
                            if (marcasLookup.TryGetValue(Convert.ToInt32(produtoDetalhes.codMarca), out marcaEncontrada))
                            {
                                descricaoMarca = marcaEncontrada.descMarca;
                            }
                        }

                        string promocaoText = "Promoção não encontrada";
                        CabPromocao cabPromocaoDetalhes;
                        if (cabPromocaoLookup.TryGetValue(currentCodPromo, out cabPromocaoDetalhes))
                        {
                            promocaoText = cabPromocaoDetalhes.descPromocao;
                        }

                        mkpPromocaoDao.InsertMkpPromocao(
                            currentCodProd.Value,
                            currentPerMkp,
                            descricaoProduto,
                            descricaoMarca,
                            currentCodPromo.Value,
                            promocaoText,
                            codmarca
                        );
                    }
                }
                MessageBox.Show("Dados processados (atualizados/inseridos) com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            metroGrid2.DataSource = null;
            metroGrid3.DataSource = null;

            if (TabControle.TabPages.ContainsKey("Lista")) 
            {
                TabControle.SelectedTab = TabControle.TabPages["Lista"];
            }
        }
    }
}
