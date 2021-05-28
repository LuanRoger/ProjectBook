using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class EditarLivro : Form
    {
        private LivrosDb livrosDb = new();
        private DataTable infoLivro;

        public EditarLivro()
        {
            InitializeComponent();
            SugerirAutores();
            ColocarGeneros();

            btnVerLivros.Click += (_, _) =>
            {
                ListaPesquisa listaPesquisa = new ListaPesquisa(livrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            btnPesquisarLivros.Click += (_, _) =>
            {
                PesquisarLivro pesquisarLivro = new PesquisarLivro();
                pesquisarLivro.Show();
            };
        }

        #region CheckedChanged
        private void rabEditarId_CheckedChanged(object sender, EventArgs e) =>
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.None;
        private void rabEditarTitulo_CheckedChanged(object sender, EventArgs e)
        {
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection tituloSugestao = new();

            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) tituloSugestao.Add($"{livro[1]} - {livro[2]}"); // Titulo - Autor
            txtEditarBuscar.AutoCompleteCustomSource = tituloSugestao;
        }
        private void rabEditarAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtEditarBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection autorSugestao = new();

            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) autorSugestao.Add($"{livro[2]} - {livro[1]}"); //Autor - Titulo
            txtEditarBuscar.AutoCompleteCustomSource = autorSugestao;
        }
        #endregion

        private void btnFecharEdicao_Click(object sender, EventArgs e) => this.Close();

        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            string[] paraBuscar = txtEditarBuscar.Text.Trim().Split("-");

            if(Verificadores.VerificarStrings(txtEditarBuscar.Text))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabEditarId.Checked && !rabEditarTitulo.Checked && !rabEditarAutor.Checked)
            {
                MessageBox.Show(Resources.MarcarOpcao, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabEditarId.Checked) infoLivro = livrosDb.BuscarLivrosId(txtEditarBuscar.Text); 
            else if (rabEditarTitulo.Checked) infoLivro = livrosDb.BuscarLivrosTitulo(paraBuscar[0].Trim()); 
            else if (rabEditarAutor.Checked) infoLivro = livrosDb.BuscarLivrosAutor(paraBuscar[0].Trim()); 
            else return; 

            PreencherCampos(infoLivro);
        }

        private void btnSalvarEditar_Click(object sender, EventArgs e)
        {
            #region Tratar código
            string codigoTxt = txtEditarCodigo.Text;
            if (Verificadores.VerificarStrings(codigoTxt))
            {
                int codigo = new Random().Next(0, 999);

                while (Verificadores.VerificarIdLivro(codigo))
                {
                    codigo = new Random().Next(0, 999);
                }

                txtEditarCodigo.Text = codigo.ToString();
            }
            #endregion

            Livro livro;
            //Aplicar a formatação na instânciação do livro
            if (ConfigurationManager.AppSettings["formatarLivro"] == "1")
            {
                livro = new Livro(
                    txtEditarCodigo.Text,
                    txtEditarTitulo.Text.ToUpper(),
                    txtEditarAutor.Text.ToUpper(),
                    txtEditarEditora.Text.ToUpper(),
                    txtEditarEdicao.Text.ToUpper(),
                    txtEditarAno.Text.ToUpper(),
                    cmbEditarGenero.Text.ToUpper(),
                    txtEditarIsbn.Text.ToUpper(),
                    DateTime.Now,
                    txtEditarObservacoes.Text.ToUpper());
            }
            else
            {
                livro = new Livro(
                    txtEditarCodigo.Text,
                    txtEditarTitulo.Text,
                    txtEditarAutor.Text,
                    txtEditarEditora.Text,
                    txtEditarEdicao.Text,
                    txtEditarAno.Text,
                    cmbEditarGenero.Text,
                    txtEditarIsbn.Text,
                    DateTime.Now,
                    txtEditarObservacoes.Text);
            }
            
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            livrosDb.AtualizarViaId(infoLivro.Rows[0][0].ToString(), livro);

            SugerirAutores();
            ColocarGeneros();
            LimparCamposEditar();
        }
        private void PreencherCampos(DataTable info)
        {
            try
            {
                txtEditarCodigo.Text = info.Rows[0][0].ToString();
                txtEditarTitulo.Text = info.Rows[0][1].ToString();
                txtEditarAutor.Text = info.Rows[0][2].ToString();
                txtEditarEditora.Text = info.Rows[0][3].ToString();
                txtEditarEdicao.Text = info.Rows[0][4].ToString();
                txtEditarAno.Text = info.Rows[0][5].ToString();
                cmbEditarGenero.Text = info.Rows[0][6].ToString();
                txtEditarIsbn.Text = info.Rows[0][7].ToString();
                txtEditarObservacoes.Text = info.Rows[0][9].ToString();
            } 
            catch
            {
                MessageBox.Show(Resources.LivroNExiste, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpbBuscar.Enabled = true;
            }
        }

        private void SugerirAutores()
        {
            AutoCompleteStringCollection autorSugestoes = new();
            foreach (DataRow autor in livrosDb.VerTodosLivros().Rows) autorSugestoes.Add(autor[2].ToString());

            txtEditarAutor.AutoCompleteCustomSource = autorSugestoes;
        }
        private void ColocarGeneros()
        {
            cmbEditarGenero.Items.Clear();

            foreach(DataRow itens in livrosDb.PegarGeneros().Rows) cmbEditarGenero.Items.Add(itens["Genero"]);
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
