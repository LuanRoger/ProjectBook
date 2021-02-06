using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook
{
    public partial class EditarLivro : Form
    {
        private LivrosDb livrosDb = new LivrosDb();
        private DataTable resultadoBusca;

        public EditarLivro()
        {
            InitializeComponent();
            
            ColocarGeneros();
        }

        #region Configurar sugestões
        private void rabEditarTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection tituloSugestao = new AutoCompleteStringCollection();
            livrosDb.AbrirConexaoDb();
            foreach (DataRow titulo in livrosDb.VerTodosLivros().Rows) tituloSugestao.Add(titulo[1].ToString());
            livrosDb.FechaConecxaoDb();
            txtEditarBuscar.AutoCompleteCustomSource = tituloSugestao;
        }

        private void rabEditarAutor_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection autorSugestao = new AutoCompleteStringCollection();
            livrosDb.AbrirConexaoDb();
            foreach (DataRow titulo in livrosDb.VerTodosLivros().Rows) autorSugestao.Add(titulo[2].ToString());
            livrosDb.FechaConecxaoDb();
            txtEditarBuscar.AutoCompleteCustomSource = autorSugestao;
        }

        private void rabEditarId_CheckedChanged(object sender, EventArgs e) =>
            txtEditarBuscar.AutoCompleteCustomSource = null;

        private void btnFecharEdicao_Click(object sender, EventArgs e) => this.Close();
        #endregion

        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            string paraBuscar = txtEditarBuscar.Text;

            if(Verificadores.VerificarStrings(paraBuscar))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabEditarId.Checked) resultadoBusca = livrosDb.BuscarLivrosId(paraBuscar); 
            else if (rabEditarTitulo.Checked) resultadoBusca = livrosDb.BuscarLivrosTitulo(paraBuscar); 
            else if (rabEditarAutor.Checked) resultadoBusca = livrosDb.BuscarLivrosAutor(paraBuscar); 
            else return; 

            gpbBuscar.Enabled = false;

            PreencherCampos(resultadoBusca);
        }

        private void btnLimparTxtEditar_Click(object sender, EventArgs e) { gpbBuscar.Enabled = true; LimparCamposEditar(); }

        private void btnSalvarEditar_Click(object sender, EventArgs e)
        {
            Livro livro;

            if (Verificadores.VerificarStrings(txtEditarCodigo.Text))
            {
                int codigo = new Random().Next(0, 999);

                while (Verificadores.VerificarIdLivro(codigo))
                {
                    codigo = new Random().Next(0, 999);
                }

                txtEditarCodigo.Text = codigo.ToString();
            }

            //Aplicar a formatação na instânciação do cliente
            if (ConfigurationManager.AppSettings["formatarLivro"] == "1")
            {
                livro = new Livro(txtEditarCodigo.Text, txtEditarTitulo.Text.ToUpper(), txtEditarAutor.Text.ToUpper(),
                    txtEditarEditora.Text.ToUpper(), txtEditarEdicao.Text.ToUpper(), txtEditarAno.Text.ToUpper(),
                    cmbEditarGenero.Text.ToUpper(), txtEditarIsbn.Text.ToUpper());
            }
            else
            {
                livro = new Livro(txtEditarCodigo.Text, txtEditarTitulo.Text, txtEditarAutor.Text,
                    txtEditarEditora.Text, txtEditarEdicao.Text, txtEditarAno.Text,
                    cmbEditarGenero.Text, txtEditarIsbn.Text);
            }
            
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Properties.Resources.preencherCampos, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            livrosDb.AbrirConexaoDb();
            livrosDb.AtualizarViaId(resultadoBusca.Rows[0][0].ToString(), livro);
            livrosDb.FechaConecxaoDb();

            LimparCamposEditar();
            ColocarGeneros();
            gpbBuscar.Enabled = true;
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
            } 
            catch
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpbBuscar.Enabled = true;
            }
        }
        
        private void ColocarGeneros()
        {
            //Colocar todos os generos no combobox
            foreach(DataRow itens in livrosDb.PegarGeneros().Rows) cmbEditarGenero.Items.Add(itens["Genero"]);
        }
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
        }
    }
}
