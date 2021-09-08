using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;
using ProjectBook.Managers.Configuration;
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

        private async void btnSalvarLivro_Click(object sender, EventArgs e)
        {
            #region Tratar código
            string codigoTxt = txtCodigoLivro.Text;
            if (Verificadores.VerificarStrings(codigoTxt))
            {
                txtCodigoLivro.Text = (await IdGenerator.GenerateIdLivro()).ToString();
            }
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

            LivroModel livro;
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
            List<string> listGenero = new();

            foreach(string genero in await LivrosDb.PegarGeneros()) listGenero.Add(genero);
            
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
