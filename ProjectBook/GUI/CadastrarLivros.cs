using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Properties;
using ProjectBook.Model;
using ProjectBook.Util;

namespace ProjectBook.GUI
{
    public partial class CadastroLivro : Form
    {
        public CadastroLivro()
        {
            InitializeComponent();
        }
        
        private void CadastroLivro_Load(object sender, EventArgs e)
        {
            #region MenuClick
            btnVerLivros.Click += async delegate
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
                
                ListaPesquisa<LivroModel> listaPesquisa = new(await livrosContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            btnPesquisarLivros.Click += delegate
            {
                PesquisarLivro pesquisarLivro = new();
                pesquisarLivro.Show();
            };
            #endregion
            
            SugerirAutores();
            SugerirEditora();
            ColocarGeneros();
        }

        #region Events
        private void txtCodigoLivro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Verificadores.VerificarKeyIsInt(e)) return;
            
            e.Handled = true;
        }
        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Verificadores.VerificarKeyIsInt(e)) return;
            
            e.Handled = true;
        }
        #endregion

        private void btnSalvarLivro_Click(object sender, EventArgs e)
        {
            #region Generate ID
            string codigoTxt = txtCodigoLivro.Text;
            if (Verificadores.VerificarStrings(codigoTxt))
                txtCodigoLivro.Text = IdGenerator.GenerateIdLivro().ToString();
            else
            {
                if(await Verificadores.VerificarIdLivro(Convert.ToInt32(codigoTxt))) 
                {
                    MessageBox.Show(Resources.IdExistente, Resources.Error_MessageBox,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion
            
            if(!Verificadores.VerificarAnoLivro(txtAno.Text))
            {
                MessageBox.Show(string.Format(Resources.TypeError, "Ano"), Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            LivroModel livro = Globals.configurationController.configuration.formating.FormatBook ? 
                new()
            {
                id = int.Parse(txtCodigoLivro.Text),
                titulo = txtTituloLivro.Text.ToUpper(),
                autor = txtAutorLivro.Text.ToUpper(),
                editora = txtEditoraLivro.Text.ToUpper(),
                edicao = txtEdicaoLivro.Text.ToUpper(),
                ano = int.Parse(txtAno.Text.ToUpper()),
                genero = cmbGenero.Text.ToUpper(),
                isbn = txtIsbn.Text.ToUpper(),
                dataCadastro = DateTime.Now,
                observacoes = txtObservacoesCadastro.Text.ToUpper()
            } : new()
            {
                id = int.Parse(txtCodigoLivro.Text),
                titulo = txtTituloLivro.Text,
                autor = txtAutorLivro.Text,
                editora = txtEditoraLivro.Text,
                edicao = txtEdicaoLivro.Text,
                ano = int.Parse(txtAno.Text),
                genero = cmbGenero.Text,
                isbn = txtIsbn.Text,
                dataCadastro = DateTime.Now,
                observacoes = txtObservacoesCadastro.Text
            };

            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            livrosContext.Create(livro);
            
            await transaction.EndTransactionAsync();
            
            MessageBox.Show(Resources.LivroRegistrado, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            SugerirAutores();
            SugerirEditora();
            ColocarGeneros();
            LimparCamposCadastro();
        }

        private void btnFecharCadastro_Click(object sender, EventArgs e) => Close();
        private void btnLimparTxtLivros_Click(object sender, EventArgs e) => LimparCamposCadastro();

        private async void SugerirAutores()
        {
            txtAutorLivro.AutoCompleteCustomSource.Clear();
            AutoCompleteStringCollection autorSugestoes = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
                autorSugestoes.Add(livro.autor);
            
            txtAutorLivro.AutoCompleteCustomSource = autorSugestoes;
        }
        private async void SugerirEditora()
        {
            txtEditoraLivro.AutoCompleteCustomSource.Clear();
            AutoCompleteStringCollection editora = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
                editora.Add(livro.editora);
            
            txtEditoraLivro.AutoCompleteCustomSource = editora;
        }
        private async void ColocarGeneros()
        {
            cmbGenero.Items.Clear();
            List<string> listGenero = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach(string genero in await livrosContext.GetGenres()) listGenero.Add(genero);
            
            cmbGenero.Items.AddRange(listGenero.Distinct().ToArray());
        }
        private void LimparCamposCadastro()
        {
            txtCodigoLivro.Clear();
            txtTituloLivro.Clear();
            txtAutorLivro.Clear();
            txtEditoraLivro.Clear();
            txtEdicaoLivro.Clear();
            txtAno.Clear();
            cmbGenero.Text = "";
            txtIsbn.Clear();
            txtObservacoesCadastro.Clear();
        }
    }
}
