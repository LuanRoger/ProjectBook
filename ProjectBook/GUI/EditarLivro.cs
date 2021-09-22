using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.Managers.Configuration;
using ProjectBook.Model;
using ProjectBook.Util;

namespace ProjectBook.GUI
{
    public partial class EditarLivro : Form
    {
        private LivroModel infoLivro;

        public EditarLivro()
        {
            InitializeComponent();
            SugerirAutores();
            ColocarGeneros();

            btnVerLivros.Click += async (_, _) =>
            {
                ListaPesquisa<LivroModel> listaPesquisa = new(await LivrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            btnPesquisarLivros.Click += (_, _) =>
            {
                PesquisarLivro pesquisarLivro = new();
                pesquisarLivro.Show();
            };
            Load += (_, _) => AppInsightMetrics.TrackForm("EditarLivro");
        }

        #region Events
        private void rabEditarId_CheckedChanged(object sender, EventArgs e) =>
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.None;
        private async void rabEditarTitulo_CheckedChanged(object sender, EventArgs e)
        {
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection tituloSugestao = new();

            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                tituloSugestao.Add($"{livro.titulo} - {livro.autor}");
            
            txtEditarBuscar.AutoCompleteCustomSource = tituloSugestao;
        }
        private async void rabEditarAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection autorSugestao = new();

            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                autorSugestao.Add($"{livro.autor} - {livro.titulo}"); //Autor - Titulo
            txtEditarBuscar.AutoCompleteCustomSource = autorSugestao;
        }
        
        private void txtEditarCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Verificadores.VerificarKeyIsInt(e)) return;
            
            e.Handled = true;
        }
        private void txtEditarAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Verificadores.VerificarKeyIsInt(e)) return;
            
            e.Handled = true;
        }
        #endregion

        private void btnFecharEdicao_Click(object sender, EventArgs e) => Close();

        private async void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            string[] paraBuscar = txtEditarBuscar.Text.Trim().Split("-");

            if(Verificadores.VerificarStrings(txtEditarBuscar.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabEditarId.Checked && !rabEditarTitulo.Checked && !rabEditarAutor.Checked)
            {
                MessageBox.Show(Resources.MarcarOpcaoBusca, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabEditarId.Checked)
                infoLivro = await LivrosDb.BuscarLivrosId(int.Parse(txtEditarBuscar.Text)); 
            else if (rabEditarTitulo.Checked) 
                infoLivro = (await LivrosDb.BuscarLivrosTitulo(paraBuscar[0].Trim())).First(); 
            else if (rabEditarAutor.Checked)
                infoLivro = (await LivrosDb.BuscarLivrosAutor(paraBuscar[0].Trim())).First(); 
            else return; 

            PreencherCampos(infoLivro);
        }

        private async void btnSalvarEditar_Click(object sender, EventArgs e)
        {
            #region Tratar código
            string codigoTxt = txtEditarCodigo.Text;
            
            if (Verificadores.VerificarStrings(codigoTxt))
                txtEditarCodigo.Text = (await IdGenerator.GenerateIdLivro()).ToString();
            else
            {
                if(await Verificadores.VerificarIdLivro(Convert.ToInt32(codigoTxt)) && Convert.ToInt32(codigoTxt) != infoLivro.id) 
                {
                    MessageBox.Show(Resources.IdExistente, Resources.Error_MessageBox,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion
            
            if(!Verificadores.VerificarAnoLivro(txtEditarAno.Text))
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
                    id = int.Parse(txtEditarCodigo.Text),
                    titulo = txtEditarTitulo.Text.ToUpper(),
                    autor = txtEditarAutor.Text.ToUpper(),
                    editora = txtEditarEditora.Text.ToUpper(),
                    edicao = txtEditarEdicao.Text.ToUpper(),
                    ano = int.Parse(txtEditarAno.Text),
                    genero = cmbEditarGenero.Text.ToUpper(),
                    isbn = txtEditarIsbn.Text.ToUpper(),
                    dataCadastro = DateTime.Now,
                    observacoes = txtEditarObservacoes.Text.ToUpper()
                };
            }
            else
            {
                livro = new()
                {
                    id = int.Parse(txtEditarCodigo.Text),
                    titulo = txtEditarTitulo.Text,
                    autor = txtEditarAutor.Text,
                    editora = txtEditarEditora.Text,
                    edicao = txtEditarEdicao.Text,
                    ano = int.Parse(txtEditarAno.Text),
                    genero = cmbEditarGenero.Text,
                    isbn = txtEditarIsbn.Text,
                    dataCadastro = DateTime.Now,
                    observacoes = txtEditarObservacoes.Text
                };
            }
            
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LivrosDb.AtualizarViaId(infoLivro.id, livro);
            
            MessageBox.Show(Resources.InformaçõesAtualizadas_MessageBox, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            SugerirAutores();
            ColocarGeneros();
            LimparCamposEditar();
        }
        private void PreencherCampos(LivroModel infoLivro)
        {
            try
            {
                txtEditarCodigo.Text = infoLivro.id.ToString();
                txtEditarTitulo.Text = infoLivro.titulo;
                txtEditarAutor.Text = infoLivro.autor;
                txtEditarEditora.Text = infoLivro.editora;
                txtEditarEdicao.Text = infoLivro.edicao;
                txtEditarAno.Text = infoLivro.ano.ToString();
                cmbEditarGenero.Text = infoLivro.genero;
                txtEditarIsbn.Text = infoLivro.isbn;
                txtEditarObservacoes.Text = infoLivro.observacoes;
            } 
            catch
            {
                MessageBox.Show(Resources.LivroNaoExiste, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpbBuscar.Enabled = true;
            }
        }

        private async void SugerirAutores()
        {
            AutoCompleteStringCollection autorSugestoes = new();
            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                autorSugestoes.Add(livro.autor);

            txtEditarAutor.AutoCompleteCustomSource = autorSugestoes;
        }
        private async void ColocarGeneros()
        {
            cmbEditarGenero.Items.Clear();
            List<string> listGenero = new();

            foreach(string genero in await LivrosDb.PegarGeneros()) listGenero.Add(genero);
            
            cmbEditarGenero.Items.AddRange(listGenero.Distinct().ToArray());
        }

        private void btnLimparTxtEditar_Click(object sender, EventArgs e) => LimparCamposEditar();
        private void LimparCamposEditar()
        {
            txtEditarCodigo.Clear();
            txtEditarBuscar.Clear();
            txtEditarTitulo.Clear();
            txtEditarAutor.Clear();
            txtEditarEditora.Clear();
            txtEditarEdicao.Clear();
            txtEditarAno.Clear();
            cmbEditarGenero.Text = "";
            txtEditarIsbn.Clear();
            txtEditarObservacoes.Clear();
        }
    }
}
