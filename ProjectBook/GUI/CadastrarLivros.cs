using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.GUI
{
    public partial class CadastroLivro : Form
    {
        LivrosDb livrosDb = new();

        public CadastroLivro()
        {
            InitializeComponent();
            SugerirAutores();
            SugerirEditora();
            ColocarGeneros();

            btnVerLivros.Click += delegate
            {
                ListaPesquisa listaPesquisa = new(livrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            btnPesquisarLivros.Click += delegate
            {
                PesquisarLivro pesquisarLivro = new();
                pesquisarLivro.Show();
            };
            Load += (_, _) => AppInsightMetrics.TrackForm("CadastrarLivro");
        }

        private void btnSalvarLivro_Click(object sender, EventArgs e)
        {
            #region Tratar código
            string codigoTxt = txtCodigoLivro.Text;
            if (Verificadores.VerificarStrings(codigoTxt))
            {
                int codigo = new Random().Next(0, 999);

                while (Verificadores.VerificarIdLivro(codigo)) codigo = new Random().Next(0, 999);

                txtCodigoLivro.Text = codigo.ToString();
            }
            else
            {
                if(Verificadores.VerificarIdLivro(Convert.ToInt32(codigoTxt))) 
                {
                    MessageBox.Show("O código do livro digitado já existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            try { int.Parse(txtAno.Text); }
            catch { MessageBox.Show(string.Format(Resources.TypeError, "Ano"), Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(new Exception(string.Format(Resources.TypeError, "Ano"))); return;}

            LivroModel livro;
            //Aplicar a formatação na instânciação do livro
            if (AppConfigurationManager.configuration.FormatBook)
            {
                livro = new LivroModel(
                    txtCodigoLivro.Text,
                    txtTituloLivro.Text.ToUpper(),
                    txtAutorLivro.Text.ToUpper(),
                    txtEditoraLivro.Text.ToUpper(),
                    txtEdicaoLivro.Text.ToUpper(),
                    txtAno.Text.ToUpper(),
                    cmbGenero.Text.ToUpper(),
                    txtIsbn.Text.ToUpper(),
                    DateTime.Now,
                    txtObservacoesCadastro.Text.ToUpper());
            }
            else
            {
                livro = new LivroModel(
                    txtCodigoLivro.Text,
                    txtTituloLivro.Text,
                    txtAutorLivro.Text,
                    txtEditoraLivro.Text,
                    txtEdicaoLivro.Text,
                    txtAno.Text,
                    cmbGenero.Text,
                    txtIsbn.Text,
                    DateTime.Now,
                    txtObservacoesCadastro.Text);
            }
            
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            livrosDb.AdicionarLivro(livro);

            SugerirAutores();
            SugerirEditora();
            ColocarGeneros();
            LimparCamposCadastro();
        }

        private void btnFecharCadastro_Click(object sender, EventArgs e) => this.Close();
        private void btnLimparTxtLivros_Click(object sender, EventArgs e) => LimparCamposCadastro();

        private void SugerirAutores()
        {
            txtAutorLivro.AutoCompleteCustomSource.Clear();

            AutoCompleteStringCollection autorSugestoes = new();
            foreach (DataRow autor in livrosDb.VerTodosLivros().Rows) autorSugestoes.Add(autor[2].ToString());
            txtAutorLivro.AutoCompleteCustomSource = autorSugestoes;
        }
        private void SugerirEditora()
        {
            txtEditoraLivro.AutoCompleteCustomSource.Clear();

            AutoCompleteStringCollection editoraAutoCompleteString = new();
            foreach (DataRow editora in livrosDb.VerTodosLivros().Rows) editoraAutoCompleteString.Add(editora[3].ToString());
            txtEditoraLivro.AutoCompleteCustomSource = editoraAutoCompleteString;
        }
        private void ColocarGeneros()
        {
            cmbGenero.Items.Clear();

            //Colocar todos os generos no combobox
            foreach(DataRow itens in livrosDb.PegarGeneros().Rows) cmbGenero.Items.Add(itens["Genero"]);
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
