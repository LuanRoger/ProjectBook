using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Tipos;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.GUI
{
    public partial class PesquisarAluguel : Form
    {
        private AluguelDb aluguelDb = new();

        public PesquisarAluguel()
        {
            InitializeComponent();

            #region MenuClick
            mnuVerLivroAlugado.Click += (_, _) =>
            {
                ListaPesquisa lista = new(aluguelDb.PegarLivrosAlugados());
                lista.Show();
            };
            mnuVerLivrosAtasados.Click += (_, _) =>
            {
                ListaPesquisa lista = new(aluguelDb.PegarLivroAtrassado());
                lista.Show();
            };
            mnuVerLivrosDevolvidos.Click += (_, _) =>
            {
                ListaPesquisa lista = new(aluguelDb.PegarLivroDevolvido());
                lista.Show();
            };
            #endregion

            Load += (_, _) => AppInsightMetrics.TrackForm("PesquisarAluguel");
        }

        #region CheckChange
        private void rabTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{livro[0]} - {livro[2]}");
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            foreach (DataRow cliente in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{cliente[2]} - {cliente[0]}");
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        #endregion

        private void btnBuscarClientePesquisaAluguel_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscarAluguel.Text.Split("-", 2, StringSplitOptions.TrimEntries);
            DataTable data = new();
            
            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(termoBusca.Length == 1)
            {
                if (rabNomeCliente.Checked) data = aluguelDb.BuscarAluguelCliente(termoBusca[0].Trim());
                else if (rabTituloLivro.Checked) data = aluguelDb.BuscarAluguelLivro(termoBusca[0].Trim());
            }
            else
            {
                string titulo = rabTituloLivro.Checked ? termoBusca[0] : termoBusca[1];
                string nomeCliente = rabNomeCliente.Checked ? termoBusca[0] : termoBusca[1];

                data = aluguelDb.BuscarAluguelLivroCliente(titulo, nomeCliente);
            }

            if(Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Resources.LivroNAluguado, Resources.MessageBoxError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCampos(data);
        }
        private void btnVerEmRelatorio_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscarAluguel.Text.Split("-");

            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListaPesquisa lista;

            if (rabNomeCliente.Checked)
            {
                lista = new ListaPesquisa(aluguelDb.BuscarAluguelCliente(termoBusca[0].Trim()));
                lista.Show();
            }
            else if (rabTituloLivro.Checked)
            {
                lista = new ListaPesquisa(aluguelDb.BuscarAluguelLivro(termoBusca[0].Trim()));
                lista.Show();
            }

            LimparCampos();
        }

        private void PreencherCampos(DataTable data)
        {
            txtResultadoCliete.Text = data.Rows[0][2].ToString();
            txtResultadoLivro.Text = data.Rows[0][0].ToString();
            txtResultadoStatus.Text = data.Rows[0][5].ToString();

            if (txtResultadoStatus.Text == StatusAluguel.Devolvido.ToString()) return;
            DateTime hoje = DateTime.Now.Date;
            DateTime devolucao = (DateTime)data.Rows[0][4];
            txtAVencer.Text = Convert.ToInt32((devolucao.Date - hoje).Days) <= 0
                ? "-" : (devolucao.Date - hoje).Days.ToString();
            txtAtraso.Text = Convert.ToInt32((hoje - devolucao.Date).Days) <= 0
                ? "-" : (hoje - devolucao.Date).Days.ToString();
        }

        private void btnFecharPesquisaAluguel_Click(object sender, EventArgs e) => this.Close();
        private void btnLimparPequisaAluguel_Click(object sender, EventArgs e) => LimparCampos();
        
        private void LimparCampos()
        {
            txtBuscarAluguel.Clear();
            txtAtraso.Clear();
            txtAVencer.Clear();
            txtResultadoCliete.Clear();
            txtResultadoLivro.Clear();
            txtResultadoStatus.Clear();
        }
    }
}
