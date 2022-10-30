using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Properties;
using ProjectBook.Model;
using ProjectBook.Util;

namespace ProjectBook.GUI
{
    public partial class EditarLivro : Form
    {
        private LivroModel? infoLivro;

        public EditarLivro()
        {
            InitializeComponent();
            SugerirAutores();
            ColocarGeneros();

            btnVerLivros.Click += async (_, _) =>
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
                
                ListaPesquisa<LivroModel> listaPesquisa = new(await livrosContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            btnPesquisarLivros.Click += (_, _) =>
            {
                PesquisarLivro pesquisarLivro = new();
                pesquisarLivro.Show();
            };
        }

        #region CheckedChanged
        private void rabEditarId_CheckedChanged(object sender, EventArgs e) =>
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.None;
        
        //TODO: Made those tow events redirect to one
        private async void rabEditarTitulo_CheckedChanged(object sender, EventArgs e)
        {
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection tituloSugestao = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livro in await livrosContext.ReadAllAsync())
                tituloSugestao.Add($"{livro.titulo} - {livro.autor}");
            
            txtEditarBuscar.AutoCompleteCustomSource = tituloSugestao;
        }
        private async void rabEditarAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection autorSugestao = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
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
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            if (rabEditarId.Checked)
                infoLivro = livrosContext.ReadById(int.Parse(txtEditarBuscar.Text)); 
            else if (rabEditarTitulo.Checked) 
                infoLivro = (await livrosContext.SearchLivrosTitulo(paraBuscar[0].Trim())).First(); 
            else if (rabEditarAutor.Checked)
                infoLivro = (await livrosContext.SearchLivrosAutor(paraBuscar[0].Trim())).First(); 
            else return; 

            PreencherCampos(infoLivro);
        }

        private void btnSalvarEditar_Click(object sender, EventArgs e)
        {
            #region Generate ID
            string codigoTxt = txtEditarCodigo.Text;
            
            if (Verificadores.VerificarStrings(codigoTxt))
                txtEditarCodigo.Text = IdGenerator.GenerateIdLivro().ToString();
            else
            {
                if(infoLivro is null || await Verificadores.VerificarIdLivro(Convert.ToInt32(codigoTxt)) && 
                   Convert.ToInt32(codigoTxt) != infoLivro.id) 
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

            LivroModel livro = Globals.configurationController.configuration.formating.FormatBook ? new()
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
            } : new()
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
            
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            livrosContext.UpdateById(infoLivro!.id, livro);
            
            transaction.EndTransaction();
            
            MessageBox.Show(Resources.InformacoesAtualizadas_MessageBox, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
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
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
                autorSugestoes.Add(livro.autor);

            txtEditarAutor.AutoCompleteCustomSource = autorSugestoes;
        }
        private async void ColocarGeneros()
        {
            cmbEditarGenero.Items.Clear();
            List<string> listGenero = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();

            foreach(string genero in await livrosContext.GetGenres()) listGenero.Add(genero);
            
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
