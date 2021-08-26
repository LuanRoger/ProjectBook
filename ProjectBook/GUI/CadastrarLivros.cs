using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.GUI
{
    public partial class CadastroLivro : Form
    {
        public CadastroLivro()
        {
            InitializeComponent();
        }
        
        private async void CadastroLivro_Load(object sender, EventArgs e)
        {
            #region MenuClick
            btnVerLivros.Click += async delegate
            {
                ListaPesquisa<LivroModel> listaPesquisa = new(await LivrosDb.VerTodosLivros());
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
            
            AppInsightMetrics.TrackForm("CadastrarLivro");
        }

        private void btnSalvarLivro_Click(object sender, EventArgs e)
        {
            if(!Verificadores.VerificarAnoLivro(txtAno.Text))
            {
                MessageBox.Show(string.Format(Resources.TypeError, "Ano"), Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LivroModel livro;
            //Aplicar a formatação na instânciação do livro
            if (AppConfigurationManager.configuration.formating.FormatBook)
            {
                livro = new()
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
                };
            }
            else
            {
                livro = new()
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
            }
            
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LivrosDb.AdicionarLivro(livro);

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
            
            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                autorSugestoes.Add(livro.autor);
            
            txtAutorLivro.AutoCompleteCustomSource = autorSugestoes;
        }
        private async void SugerirEditora()
        {
            txtEditoraLivro.AutoCompleteCustomSource.Clear();
            AutoCompleteStringCollection editora = new();
            
            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                editora.Add(livro.editora);
            
            txtEditoraLivro.AutoCompleteCustomSource = editora;
        }
        private async void ColocarGeneros()
        {
            cmbGenero.Items.Clear();
            
            foreach(string itens in await LivrosDb.PegarGeneros()) cmbGenero.Items.Add(itens);
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
