using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirAluguel : Form
    {
        public ExcluirAluguel()
        {
            InitializeComponent();
        }

        #region CheckedChanged
        private async void rabExcluirAluguelTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            foreach (AluguelModel aluguel in await aluguelContext.ReadAllAsync()) 
                livrosSugestoes.Add($"{aluguel.titulo} - {aluguel.autor}");
            
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }

        private async void rabExcluirAluguelCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            foreach (AluguelModel aluguel in await aluguelContext.ReadAllAsync()) 
                livrosSugestoes.Add($"{aluguel.autor} - {aluguel.titulo}");
            
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }
        #endregion

        private async void btnBuscarExcluirAluguel_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscaAluguel.Text.Split('-', 2, StringSplitOptions.TrimEntries);
            AluguelModel infoAluguel = new();

            if (Verificadores.VerificarStrings(txtBuscaAluguel.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            if(termoBusca.Length == 1)
            {
                if (rabExcluirAluguelCliente.Checked) 
                    infoAluguel = (await aluguelContext.SearchAluguelCliente(termoBusca[0])).First();
                else if (rabExcluirAluguelTitulo.Checked) 
                    infoAluguel = (await aluguelContext.SearchAluguelLivro(termoBusca[0])).First();
            }
            else 
            {
                string titulo = rabExcluirAluguelTitulo.Checked ? termoBusca[0] : termoBusca[1];
                string nomeCliente = rabExcluirAluguelCliente.Checked ? termoBusca[0] : termoBusca[2];

                infoAluguel = (await aluguelContext.SearchAluguelLivroCliente(titulo, nomeCliente)).First();
            }

            if(Verificadores.VerificarCamposAluguel(infoAluguel))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
           string.Format(Resources.ConfirmarExclusao2, infoAluguel.titulo, infoAluguel.alugadoPor),
                Resources.Excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultadoExcluir != DialogResult.Yes) return;

            if(termoBusca.Length == 1)
            {
                if (rabExcluirAluguelCliente.Checked) aluguelContext.DeleteAluguelCliente(infoAluguel.alugadoPor);
                else if (rabExcluirAluguelTitulo.Checked) aluguelContext.DeleteAluguelTitulo(infoAluguel.titulo);
            }
            else aluguelContext.DeleteAluguelTituloClient(infoAluguel.titulo, infoAluguel.alugadoPor);
            
            await transaction.EndTransactionAsync();
            
            MessageBox.Show(Resources.AluguelExcluido, Resources.Concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            txtBuscaAluguel.Clear();
        }

        private void btnCancelarExcluirAluguel_Click(object sender, EventArgs e) => Close();
    }
}
