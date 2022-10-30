using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class PesquisarLivro : Form
    {
        public PesquisarLivro()
        {
            InitializeComponent();
        }

        #region CheckedChanged
        private void rabPesquisarId_CheckedChanged(object sender, EventArgs e) => txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.None;

        private void rabPesquisarTitulo_CheckedChanged(object sender, EventArgs e) => txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabPesquisarAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtTermoPesquisa.Clear();
            txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection autores = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
                autores.Add(livro.autor);
            
            txtTermoPesquisa.AutoCompleteCustomSource = autores;
        }

        private async void rabPesquisarGenero_CheckedChanged(object sender, EventArgs e)
        {
            txtTermoPesquisa.AutoCompleteCustomSource.Clear();
            txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.Suggest;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            AutoCompleteStringCollection generos = new();
            foreach (string genero in await livrosContext.GetGenres()) 
                generos.Add(genero);
            
            txtTermoPesquisa.AutoCompleteCustomSource = generos;
        }
        #endregion

        private async void btnPesquisarSeletiva_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtTermoPesquisa.Text;
            
            List<LivroModel> resultadoPesquisa = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            if (rabPesquisarId.Checked) resultadoPesquisa.Add(livrosContext.ReadById(int.Parse(termoPesquisa)));
            else if (rabPesquisarTitulo.Checked) resultadoPesquisa = await livrosContext.SearchLivrosTitulo(termoPesquisa);
            else if (rabPesquisarAutor.Checked) resultadoPesquisa = await livrosContext.SearchLivrosAutor(termoPesquisa);
            else if (rabPesquisarGenero.Checked) resultadoPesquisa = await livrosContext.SearchLivrosGenero(termoPesquisa);
            else return;

            ListaPesquisa<LivroModel> listaPesquisa = new(resultadoPesquisa);
            listaPesquisa.Show();

            txtTermoPesquisa.Clear();
        }

        private void btnFecharPesquisaLivro_Click(object sender, EventArgs e) => Close();
    }
}
