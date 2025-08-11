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
    public partial class FiltroProdLog : MetroFramework.Forms.MetroForm
    {
        public Action<string> OnMarcaSelecionada { get; set; }
        public FiltroProdLog()
        {
            InitializeComponent();
            configDataGridView();
        }

        private void FiltroProd_Load(object sender, EventArgs e)
        {

        }

        private void configDataGridView()
        {
            // Configurações globais do DataGridView
            FiltroProdGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            FiltroProdGrid.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            FiltroProdGrid.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            FiltroProdGrid.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            FiltroProdGrid.ReadOnly = true;                                               // Apenas leitura (se aplicável)
            FiltroProdGrid.MultiSelect = false;                                          // Uma linha selecionada por vez
            FiltroProdGrid.RowHeadersVisible = false;                                   // Oculta os headers de linha
            FiltroProdGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            FiltroProdGrid.Columns.Clear();

            // Adicionando coluna CodigoProduto
            FiltroProdGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProduto",
                HeaderText = "Código Produto",     // Nome exibido no cabeçalho
                Width = 135,                      // Largura da coluna em pixels
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            FiltroProdGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Descricao",
                HeaderText = "Descrição",     // Nome exibido no cabeçalho
                Width = 280,                      // Largura da coluna em pixels
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft, // Alinhamento
                }
            });
        }

        private void carregarDadosGrid()
        {
            ProdutoDAO dao = new ProdutoDAO();

            FiltroProdGrid.Rows.Clear();

            int? CodProd = string.IsNullOrWhiteSpace(txbFiltroCodProd.Text) ? (int?)null : int.Parse(txbFiltroCodProd.Text);
            string descricao = string.IsNullOrWhiteSpace(txbDescricao.Text) ? null : txbDescricao.Text;

            try
            {

                // Obtem os dados do banco
                List<Produto> dados = dao.getProdutos(CodProd, descricao);

                foreach (Produto item in dados)
                {
                    FiltroProdGrid.Rows.Add(
                        item.codProd.ToString(),                         // Código Produto
                        item.descricao?.ToString() ?? string.Empty      // Descrição
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPesquisarLog_Click(object sender, EventArgs e)
        {
            carregarDadosGrid();
        }

        private void FiltroProdGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codProd = FiltroProdGrid.Rows[e.RowIndex].Cells[0].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(codProd))
                {
                    OnMarcaSelecionada?.Invoke(codProd);
                    this.Close();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (FiltroProdGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = FiltroProdGrid.SelectedRows[0];
                string codProd = row.Cells[0].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(codProd))
                {
                    OnMarcaSelecionada?.Invoke(codProd);
                    this.Close();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Selecione uma Produto para confirmar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
