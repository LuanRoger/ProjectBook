using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirLivro : Form
    {
        public ExcluirLivro()
        {
            InitializeComponent();
        }

        #region CheckChange
        private void rabIdExcluirLivro_CheckedChanged(object sender, EventArgs e) => txtExcluirLivro.AutoCompleteMode = AutoCompleteMode.None;
        private async void rabExcluirTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sugestaoLivro = new();
            txtExcluirLivro.AutoCompleteMode = AutoCompleteMode.Suggest;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> clienteContext = (LivrosContext)transaction.StartTransaction<LivroModel>();

            foreach(LivroModel livro in await clienteContext.ReadAllAsync())
                sugestaoLivro.Add(livro.titulo);

            txtExcluirLivro.AutoCompleteCustomSource = sugestaoLivro;
        }
        #endregion

        private async void btnBuscarExcluirLivro_Click(object sender, EventArgs e)
        {
            string termoBusca = txtExcluirLivro.Text;
            LivroModel infoLivro = new();
            
            if (Verificadores.VerificarStrings(termoBusca) || 
                !rabIdExcluirLivro.Checked && !rabExcluirTitulo.Checked)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            if (rabIdExcluirLivro.Checked) 
                infoLivro = livrosContext.ReadById(int.Parse(termoBusca));
            else if (rabExcluirTitulo.Checked) 
                infoLivro = (await livrosContext.SearchLivrosTitulo(termoBusca)).First();

            if (Verificadores.VerificarCamposLivros(infoLivro))
            {
                MessageBox.Show(Resources.LivroNaoExiste, Resources.Excluir_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                string.Format(Resources.ConfirmarExclusao1, infoLivro.titulo),
                Resources.Excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (resultadoExcluir != DialogResult.Yes) return;
            
            if (rabIdExcluirLivro.Checked) livrosContext.DeleteById(int.Parse(termoBusca));
            else if (rabExcluirTitulo.Checked) livrosContext.DeleteLivroTitulo( termoBusca);
            
            MessageBox.Show(Resources.LivroExcluido, Resources.Informacao_MessageBox, MessageBoxButtons.OK);
            
            await transaction.EndTransactionAsync();
            
            txtExcluirLivro.Clear();
        }
        private void btnCancelarExcluirLivro_Click(object sender, EventArgs e) => Close();
    }
}
