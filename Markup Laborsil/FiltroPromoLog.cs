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
    public partial class FiltroPromoLog : MetroFramework.Forms.MetroForm
    {
        public Action<string> OnMarcaSelecionada { get; set; }
        public FiltroPromoLog()
        {
            InitializeComponent();
            configDataGridView();
        }

        private void FiltroPromoLog_Load(object sender, EventArgs e)
        {

        }

        private void configDataGridView()
        {
            // Configurações globais do DataGridView
            FiltroMarcaGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           // Seleção por linha
            FiltroMarcaGrid.AllowUserToAddRows = false;                                       // Impede adicionar novas linhas manualmente
            FiltroMarcaGrid.AllowUserToResizeColumns = true;                                 // Permite redimensionar colunas
            FiltroMarcaGrid.AllowUserToResizeRows = false;                                  // Não permite redimensionamento de linhas
            FiltroMarcaGrid.ReadOnly = true;                                               // Apenas leitura (se aplicável)
            FiltroMarcaGrid.MultiSelect = false;                                          // Uma linha selecionada por vez
            FiltroMarcaGrid.RowHeadersVisible = false;                                   // Oculta os headers de linha
            FiltroMarcaGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            FiltroMarcaGrid.Columns.Clear();

            // Adicionando coluna CodigoProduto
            FiltroMarcaGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoPromo",
                HeaderText = "Código Promoção",     // Nome exibido no cabeçalho
                Width = 150,                      // Largura da coluna em pixels
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            FiltroMarcaGrid.Columns.Add(new DataGridViewTextBoxColumn()
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
            CabPromocaoDAO dao = new CabPromocaoDAO();

            FiltroMarcaGrid.Rows.Clear();

            int? codPromocao = string.IsNullOrWhiteSpace(txbFiltroCodProd.Text) ? (int?)null : int.Parse(txbFiltroCodProd.Text);
            string descPromocao = string.IsNullOrWhiteSpace(txbDescricao.Text) ? null : txbDescricao.Text;

            try
            {

                // Obtem os dados do banco
                List<CabPromocao> dados = dao.ObterCabecalhoPromocoes(codPromocao, descPromocao);

                foreach (CabPromocao item in dados)
                {
                    FiltroMarcaGrid.Rows.Add(
                        item.codPromocao.ToString(),                         // Código Produto
                        item.descPromocao?.ToString() ?? string.Empty      // Descrição
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPesquisarLog_Click(object sender, EventArgs e)
        {
            carregarDadosGrid();
        }

        private void FiltroMarcaGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codPromocao = FiltroMarcaGrid.Rows[e.RowIndex].Cells[0].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(codPromocao))
                {
                    OnMarcaSelecionada?.Invoke(codPromocao);
                    this.Close();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (FiltroMarcaGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = FiltroMarcaGrid.SelectedRows[0];
                string codPromocao = row.Cells[0].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(codPromocao))
                {
                    OnMarcaSelecionada?.Invoke(codPromocao);
                    this.Close();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Selecione uma Promoção para confirmar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
