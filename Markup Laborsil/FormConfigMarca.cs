using Markup_Laborsil.DAO;
using Markup_Laborsil.Model;
using MetroFramework;
using MetroFramework.Controls;
using Oracle.ManagedDataAccess.Client;
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
    public partial class FormConfigMarca : MetroFramework.Forms.MetroForm
    {
        public FormConfigMarca()
        {
            InitializeComponent();
            ConfigurarMetroListView();
        }

        private void FormConfigMarca_Load(object sender, EventArgs e)
        {
            metroTextBox4.UseCustomBackColor = true;
        }

        private void txbMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (int.TryParse(txbMarca.Text, out int codMarca))
                {
                    var dao = new MarcaDAO();
                    var produtos = dao.obterMarcas(codMarca, null);

                    if (produtos != null)
                    {
                        metroTextBox4.Text = produtos[0].descMarca;
                    }
                    else
                    {
                        metroTextBox4.Text = "";
                        MetroFramework.MetroMessageBox.Show(this, "Produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var produtos = dao.obterMarcas(codMarca, null);

                if (produtos != null)
                {
                    metroTextBox4.Text = produtos[0].descMarca;
                }
                else
                {
                    metroTextBox4.Text = "";
                    MetroFramework.MetroMessageBox.Show(this, "Produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMarca.Text = "";
                }
            }
            else
            {
                metroTextBox4.Text = "";
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConfig formConfiguracao = new FormConfig();
            formConfiguracao.FormClosed += (s, args) => this.Close();
            formConfiguracao.Show();
        }

        private void CarregarDadosNoMetroListView()
        {

            MarcaDAO dao = new MarcaDAO();

            metroGrid1.Rows.Clear();

            int? codMarca = string.IsNullOrWhiteSpace(txbMarca.Text) ? (int?)null : int.Parse(txbMarca.Text);

            try
            {

                // Obtem os dados do banco
                List<Marca> dados = dao.obterMarcas(codMarca, null);

                foreach (Marca item in dados)
                {
                    metroGrid1.Rows.Add(
                        item.CodMarca.ToString(),                           // Código Marca
                        item.descMarca?.ToString() ?? string.Empty,        // Descricao Marca
                        item.AtualizaAuto?.ToString() ?? string.Empty,    // Se atualiza automaticamente
                        item.TipoAtuPreco?.ToString() ?? string.Empty    // Tipo de atualização do preço
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
            metroGrid1.MultiSelect = false;                                          // Uma linha selecionada por vez
            metroGrid1.RowHeadersVisible = false;                                   // Oculta os headers de linha
            metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Controle manual do tamanho das colunas

            // Limpando as colunas existentes (caso necessário)
            metroGrid1.Columns.Clear();

            // Adicionando coluna CodigoMarca (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoMarca",
                HeaderText = "Código Marca",     // Nome exibido no cabeçalho
                Width = 135,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight // Alinhamento
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna Descricao (apenas leitura)
            metroGrid1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Descricao",
                HeaderText = "Descrição",         // Nome exibido no cabeçalho
                Width = 340,                      // Largura da coluna
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true // Somente leitura
            });

            // Adicionando coluna AtualizaAuto (editável, com lista SIM/NAO)
            var comboCol = new DataGridViewComboBoxColumn();
            comboCol.Name = "AtualizaAuto";
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
            comboColTipoAtu.Name = "TipoAtuPreco";
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


        }

        private void BtnPesquisarLog_Click(object sender, EventArgs e)
        {
            CarregarDadosNoMetroListView();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var atualizaAuto = row.Cells["AtualizaAuto"].Value?.ToString();
                var tipoAtuPreco = row.Cells["TipoAtuPreco"].Value?.ToString();

                if (atualizaAuto == "Sim")
                {
                    if (string.IsNullOrEmpty(tipoAtuPreco))
                    {
                        MetroMessageBox.Show(this,
                            "Se 'Atualiza Automaticamente' estiver marcado como 'Sim', o campo 'Tipo Atualização de Preço' deve ser preenchido.",
                            "Validação de Dados",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        metroGrid1.CurrentCell = row.Cells["TipoAtuPreco"];
                        metroGrid1.BeginEdit(true);
                        return;
                    }
                }
            }

            // Perguntar se deseja continuar
            var result = MetroMessageBox.Show(this,
                "Tem certeza que deseja prosseguir com a alteração?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            // Executar o UPDATE para cada linha
            using (OracleConnection connection = Conexao.GetConnection())
            {
                connection.Open();

                foreach (DataGridViewRow row in metroGrid1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int codMarca;
                    if (!int.TryParse(row.Cells["CodigoMarca"].Value?.ToString(), out codMarca))
                        continue; // ignora se valor inválido

                    string atualizaAuto = row.Cells["AtualizaAuto"].Value?.ToString();
                    string tipoAtuPreco = row.Cells["TipoAtuPreco"].Value?.ToString();

                    // Converter "Sim"/"Não" para "S"/"N"
                    string valorAtualiza = atualizaAuto == "Sim" ? "S" : "N";

                    // tipoAtuPreco já vem como "P", "T" ou null

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @" UPDATE PCMARCA SET AD_ATUAUTOMATICO = :atu, AD_TIPOATUPRECO = :tipo WHERE CODMARCA = :cod";

                        cmd.Parameters.Add(new OracleParameter("atu", valorAtualiza));
                        if (string.IsNullOrEmpty(tipoAtuPreco))
                            cmd.Parameters.Add(new OracleParameter("tipo", DBNull.Value));
                        else
                            cmd.Parameters.Add(new OracleParameter("tipo", tipoAtuPreco));
                            cmd.Parameters.Add(new OracleParameter("cod", codMarca));
                            cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }

            MetroMessageBox.Show(this, "Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            FormConfig formConfiguracao = new FormConfig();
            formConfiguracao.FormClosed += (s, args) => this.Close();
            formConfiguracao.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
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
    }
}
