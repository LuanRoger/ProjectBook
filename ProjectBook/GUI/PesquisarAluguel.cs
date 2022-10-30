using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Properties;
using ProjectBook.Model;
using ProjectBook.Model.Enums;

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
                    IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                    AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
                    ListaPesquisa<AluguelModel> lista = new(await aluguelContext.ReadLivrosAlugados());
                    lista.Show();
                };
                mnuVerLivrosAtasados.Click += async (_, _) =>
                {
                    IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                    AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
                    ListaPesquisa<AluguelModel> lista = new(await aluguelContext.ReadLivroAtrassado());
                    lista.Show();
                };
                mnuVerLivrosDevolvidos.Click += async (_, _) =>
                {
                    IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                    AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
                    ListaPesquisa<AluguelModel> lista = new(await aluguelContext.ReadLivroDevolvido());
                    lista.Show();
                };
                #endregion
            };
        }

        #region CheckChange
        private async void rabTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            foreach (AluguelModel aluguel in await aluguelContext.ReadAllAsync()) 
                aluguelSugestao.Add($"{aluguel.titulo} - {aluguel.alugadoPor}");
            
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private async void rabNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            foreach (AluguelModel aluguel in await aluguelContext.ReadAllAsync()) 
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
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            if(termoBusca.Length == 1)
            {
                if (rabNomeCliente.Checked) aluguel = (await aluguelContext.SearchAluguelCliente(termoBusca[0].Trim())).First();
                else if (rabTituloLivro.Checked) aluguel = (await aluguelContext.SearchAluguelLivro(termoBusca[0].Trim())).First();
            }
            else
            {
                string titulo = rabTituloLivro.Checked ? termoBusca[0] : termoBusca[1];
                string nomeCliente = rabNomeCliente.Checked ? termoBusca[0] : termoBusca[1];

                aluguel = (await aluguelContext.SearchAluguelLivroCliente(titulo, nomeCliente)).First();
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

            ListaPesquisa<AluguelModel>? lista = null;
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            if (rabNomeCliente.Checked)
                lista = new(await aluguelContext.SearchAluguelCliente(termoBusca[0].Trim()));

            else if (rabTituloLivro.Checked)
                lista = new(await aluguelContext.SearchAluguelCliente(termoBusca[0].Trim()));

            lista?.Show();

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
