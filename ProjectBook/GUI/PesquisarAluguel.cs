using System;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Tipos;
using ProjectBook.Properties;
using ProjectBook.AppInsight;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class PesquisarAluguel : Form
    {
        public PesquisarAluguel()
        {
            InitializeComponent();

            Load += (_, _) =>
            {
                #region MenuClick
                mnuVerLivroAlugado.Click += async (_, _) =>
                {
                    ListaPesquisa<AluguelModel> lista = new(await AluguelDb.PegarLivrosAlugados());
                    lista.Show();
                };
                mnuVerLivrosAtasados.Click += async (_, _) =>
                {
                    ListaPesquisa<AluguelModel> lista = new(await AluguelDb.PegarLivroAtrassado());
                    lista.Show();
                };
                mnuVerLivrosDevolvidos.Click += async (_, _) =>
                {
                    ListaPesquisa<AluguelModel> lista = new(await AluguelDb.PegarLivroDevolvido());
                    lista.Show();
                };
                #endregion
                
                AppInsightMetrics.TrackForm("PesquisarAluguel");
            };
        }

        #region CheckChange
        private async void rabTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            foreach (AluguelModel aluguel in await AluguelDb.VerTodosAluguel()) 
                aluguelSugestao.Add($"{aluguel.titulo} - {aluguel.alugadoPor}");
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private async void rabNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            foreach (AluguelModel aluguel in await AluguelDb.VerTodosAluguel()) 
                aluguelSugestao.Add($"{aluguel.alugadoPor} - {aluguel.titulo}");
            
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        #endregion

        private async void btnBuscarClientePesquisaAluguel_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscarAluguel.Text.Split("-", 2, StringSplitOptions.TrimEntries);
            AluguelModel aluguel = new();
            
            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(termoBusca.Length == 1)
            {
                if (rabNomeCliente.Checked) aluguel = (await AluguelDb.BuscarAluguelCliente(termoBusca[0].Trim())).First();
                else if (rabTituloLivro.Checked) aluguel = (await AluguelDb.BuscarAluguelLivro(termoBusca[0].Trim())).First();
            }
            else
            {
                string titulo = rabTituloLivro.Checked ? termoBusca[0] : termoBusca[1];
                string nomeCliente = rabNomeCliente.Checked ? termoBusca[0] : termoBusca[1];

                aluguel = (await AluguelDb.BuscarAluguelLivroCliente(titulo, nomeCliente)).First();
            }

            if(Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Resources.LivroNaoAluguado, Resources.Error_MessageBox,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCampos(aluguel);
        }
        private async void btnVerEmRelatorio_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscarAluguel.Text.Split("-");

            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListaPesquisa<AluguelModel> lista;

            if (rabNomeCliente.Checked)
            {
                lista = new(await AluguelDb.BuscarAluguelCliente(termoBusca[0].Trim()));
                lista.Show();
            }
            else if (rabTituloLivro.Checked)
            {
                lista = new(await AluguelDb.BuscarAluguelLivro(termoBusca[0].Trim()));
                lista.Show();
            }

            LimparCampos();
        }

        private void PreencherCampos(AluguelModel aluguel)
        {
            txtResultadoCliete.Text = aluguel.alugadoPor;
            txtResultadoLivro.Text = aluguel.titulo;
            txtResultadoStatus.Text = aluguel.status.ToString();

            if (txtResultadoStatus.Text == StatusAluguel.Devolvido.ToString()) return;
            DateTime hoje = DateTime.Now.Date;
            DateTime devolucao = aluguel.dataDevolucao;
            txtAVencer.Text = Convert.ToInt32((devolucao.Date - hoje).Days) <= 0
                ? "-" : (devolucao.Date - hoje).Days.ToString();
            txtAtraso.Text = Convert.ToInt32((hoje - devolucao.Date).Days) <= 0
                ? "-" : (hoje - devolucao.Date).Days.ToString();
        }

        private void btnFecharPesquisaAluguel_Click(object sender, EventArgs e) => Close();
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
