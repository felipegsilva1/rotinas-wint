using Markup_Laborsil.DAO;
using Markup_Laborsil.Model;
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
    public partial class FormLog : MetroFramework.Forms.MetroForm
    {
        public FormLog()
        {
            InitializeComponent();
            ConfigurarMetroListView();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            
            // Informando para o Metro que Fundo é customizado
            metroPanel1.UseCustomBackColor = true;
            metroLabel1.UseCustomBackColor = true;
            metroLabel2.UseCustomBackColor = true;
            metroTextBox3.UseCustomBackColor = true;
            metroTextBox4.UseCustomBackColor = true;
            metroTextBox5.UseCustomBackColor = true;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formPrincipal = new Form1();
            formPrincipal.FormClosed += (s, args) => this.Close();
            formPrincipal.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CarregarDadosNoMetroListView();
        }
        private void CarregarDadosNoMetroListView()
        {

            LogAtuMkpDAO dao = new LogAtuMkpDAO();

            metroGrid1.Rows.Clear();

            int? CodPromocaoMed = string.IsNullOrWhiteSpace(txbPromocao.Text) ? (int?)null : int.Parse(txbPromocao.Text);
            int? CodProd = string.IsNullOrWhiteSpace(txbCodprod.Text) ? (int?)null : int.Parse(txbCodprod.Text);
            DateTime? DataInic = dtInic.Checked ? dtInic.Value : (DateTime?)null;
            DateTime? DataFim = dtFim.Checked ? dtFim.Value : (DateTime?)null;
            string Marca = string.IsNullOrWhiteSpace(metroTextBox4.Text) ? null : metroTextBox4.Text;

            try
            {

                // Obtem os dados do banco
                List<LogAtuMkp> dados = dao.ObterLogMkp(CodPromocaoMed, CodProd, DataInic, DataFim, Marca);

                foreach (LogAtuMkp item in dados)
                {
                    metroGrid1.Rows.Add(
                        item.CodProd.ToString(),                         // Código Produto
                        item.Descricao?.ToString() ?? string.Empty,      // Descrição
                        item.CodAuxiliar?.ToString() ?? string.Empty,    // Código Auxiliar
                        item.Marca?.ToString() ?? string.Empty,          // Marca
                        item.ValorUltEnt.ToString(),                     // Valor Últ. Entrada
                        item.PrecoFabrica.ToString(),                    // Preço de Fábrica
                        item.PercMarkup.ToString(),                      // Markup
                        item.Desconto.ToString(),                        // Desconto
                        item.Data?.ToString("dd/MM/yyyy HH:mm:ss"),      // Data
                        item.Maquina?.ToString() ?? string.Empty,        // Máquina
                        item.Usuario?.ToString() ?? string.Empty,        // Usuário
                        item.Programa?.ToString() ?? string.Empty,       // Programa
                        item.CodPromocaoMed?.ToString() ?? string.Empty  // Promocao Med
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarMetroListView()
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

            // Adicionando coluna CodigoAuxiliar
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoAuxiliar",
                HeaderText = "Código Auxiliar",
                Width = 135,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Marca
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Marca",
                HeaderText = "Marca",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna VlrUltEnt
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "VlrUltEnt",
                HeaderText = "Valor Últ. Entrada",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna PrecoFab
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PrecoFab",
                HeaderText = "Preço Fábrica",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Markup
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Markup",
                HeaderText = "Markup",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Desconto
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Desconto",
                HeaderText = "Desconto",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Data
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Data",
                HeaderText = "Data",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Máquina
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Maquina",
                HeaderText = "Máquina",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Usuário
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Usuario",
                HeaderText = "Usuário",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Programa
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Programa",
                HeaderText = "Programa",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna PromocaoMed
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PromocaoMed",
                HeaderText = "Promoção",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });


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

        private void txbtxbPromocao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (int.TryParse(txbPromocao.Text, out int codPromocao))
                {
                    var dao = new CabPromocaoDAO();
                    var promocao = dao.ObterCabecalhoPromocoes(codPromocao, null);

                    if (promocao != null && promocao.Count > 0)
                    {
                        metroTextBox5.Text = promocao[0].descPromocao;
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
            if (int.TryParse(txbPromocao.Text, out int codPromocao))
            {
                var dao = new CabPromocaoDAO();
                var promocao = dao.ObterCabecalhoPromocoes(codPromocao, null);

                if (promocao != null && promocao.Count > 0)
                {
                    metroTextBox5.Text = promocao[0].descPromocao;
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

        private void exportExcel_Click(object sender, EventArgs e)
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

        private void metroButton1_Click_1(object sender, EventArgs e)
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

        private void metroButton2_Click(object sender, EventArgs e)
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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var filtro = new FiltroPromoLog();
            filtro.OnMarcaSelecionada = (codPromocao) =>
            {
                txbPromocao.Text = codPromocao;
                txbPromocao.Focus();
                txbPromocao_Leave(null, EventArgs.Empty);
            };
            filtro.ShowDialog();
        }
    }
}
