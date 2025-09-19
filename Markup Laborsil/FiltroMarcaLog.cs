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
    public partial class FiltroMarcaLog : MetroFramework.Forms.MetroForm
    {
        public Action<string> OnMarcaSelecionada { get; set; }
        public FiltroMarcaLog()
        {
            InitializeComponent();
            configDataGridView();
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

            // Adicionando coluna CodigoMarca
            FiltroMarcaGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoMarca",
                HeaderText = "Código Marca",     // Nome exibido no cabeçalho
                Width = 135,                      // Largura da coluna em pixels
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight, // Alinhamento
                }
            });

            // Adicionando coluna Descricao
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
            MarcaDAO dao = new MarcaDAO();

            FiltroMarcaGrid.Rows.Clear();

            int? CodMarca = string.IsNullOrWhiteSpace(txbFiltroCodMarca.Text) ? (int?)null : int.Parse(txbFiltroCodMarca.Text);
            string descricao = string.IsNullOrWhiteSpace(txbDescricao.Text) ? null : txbDescricao.Text;

            try
            {

                // Obtem os dados do banco
                List<Marca> dados = dao.obterMarcas(CodMarca, descricao, null, null);

                foreach (Marca item in dados)
                {
                    FiltroMarcaGrid.Rows.Add(
                        item.CodMarca.ToString(),                         // Código Produto
                        item.descMarca?.ToString() ?? string.Empty      // Descrição
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro capturado: {ex.Message}");
                MetroFramework.MetroMessageBox.Show(this, "Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltroMarcaLog_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPesquisarLog_Click(object sender, EventArgs e)
        {
            carregarDadosGrid();
        }

        private void FiltroMarcaGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codMarca = FiltroMarcaGrid.Rows[e.RowIndex].Cells[0].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(codMarca))
                {
                    OnMarcaSelecionada?.Invoke(codMarca);
                    this.Close();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (FiltroMarcaGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = FiltroMarcaGrid.SelectedRows[0];
                string codMarca = row.Cells[0].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(codMarca))
                {
                    OnMarcaSelecionada?.Invoke(codMarca);
                    this.Close();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Selecione uma Marca para confirmar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
