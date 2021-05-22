using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class CadastrarAluguel : Form
    {
        private AluguelDb aluguelDb = new();
        private LivrosDb livrosDb = new();
        private ClienteDb clienteDb = new();

        private DataTable livro = new();
        private DataTable cliente = new();
        public CadastrarAluguel()
        {
            InitializeComponent();

            btnVerLivros.Click += (_, _) =>
            {
                ListaPesquisa listaPesquisa = new(livrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            btnVerClientes.Click += (_, _) =>
            {
                ListaPesquisa listaPesquisa = new(clienteDb.VerTodosClientes());
                listaPesquisa.Show();
            };
        }

        #region CheckedChanged & Sugestões
        private void rabPesquisarLivroCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private void rabPesquisarLivroTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            foreach (DataRow livroResult in livrosDb.VerTodosLivros().Rows) 
                aluguelSugestao.Add(livroResult[1].ToString());
            txtBuscarLivroAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabPesquisarLivroAutor_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            foreach (DataRow livroResult in livrosDb.VerTodosLivros().Rows) 
                aluguelSugestao.Add(livroResult[2].ToString());
            txtBuscarLivroAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }

        private void rabPesquisarClienteCodigo_CheckedChanged(object sender, EventArgs e) => 
            txtBuscarClienteAluguel.AutoCompleteMode = AutoCompleteMode.None;
        private void rabPesquisarClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            txtBuscarClienteAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            foreach (DataRow clienteResult in clienteDb.VerTodosClientes().Rows) 
                aluguelSugestao.Add(clienteResult[1].ToString());
            txtBuscarClienteAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        #endregion

        private void btnBuscarLivroAluguel_Click(object sender, EventArgs e)
        {
            string tituloParaBusca = txtBuscarLivroAluguel.Text;

            if(Verificadores.VerificarStrings(tituloParaBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.MessageBoxError ,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencharCamposLivro(tituloParaBusca);
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string clienteParaBuscar = txtBuscarClienteAluguel.Text;

            if(Verificadores.VerificarStrings(clienteParaBuscar))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCamposClientes(clienteParaBuscar);
        }

        private void btnSalvarAluguel_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = new(
                txtTituloLivroAluguel.Text,
                txtAutorLivroAluguel.Text,
                txtNomeClienteAluguel.Text,
                dtpDataEntrega.Value,
                dtpDataRecebimento.Value,
                cmbStatusAluguel.SelectedItem.ToString());
            
            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aluguelDb.CadastrarAluguel(aluguel);
            
            LimparCampos();
        }
        
        private void PreencharCamposLivro(string livroParaBusca)
        {
            if (rabPesquisarLivroCodigo.Checked) livro = livrosDb.BuscarLivrosId(livroParaBusca);
            else if (rabPesquisarLivroTitulo.Checked) livro = livrosDb.BuscarLivrosTitulo(livroParaBusca);
            else livro = livrosDb.BuscarLivrosAutor(livroParaBusca);

                try
            {
                txtTituloLivroAluguel.Text = livro.Rows[0][1].ToString(); // Titulo do livro
                txtAutorLivroAluguel.Text = livro.Rows[0][2].ToString(); // Autor
                txtEditoraLivro.Text = livro.Rows[0][3].ToString(); // Editora
                txtEdicaoLivro.Text = livro.Rows[0][4].ToString(); // Edição
            }
            catch
            {
                MessageBox.Show(Properties.Resources.LivroNExiste, Properties.Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherCamposClientes(string clienteParaBuscar)
        {
            cliente = rabPesquisarClienteCodigo.Checked ? 
                clienteDb.BuscarClienteId(clienteParaBuscar) :
                clienteDb.BuscarClienteNome(clienteParaBuscar);

            try
            {
                txtNomeClienteAluguel.Text = cliente.Rows[0][1].ToString(); // Nome completo
                txtEnderecoClienteAluguel.Text = cliente.Rows[0][2].ToString(); // Endereço
                txtTelefoneClienteAluguel.Text = cliente.Rows[0][6].ToString(); // Telefone 1
                txtEmailClienteAluguel.Text = cliente.Rows[0][8].ToString(); // Email
            }
            catch
            {
                MessageBox.Show(Properties.Resources.clienteNaoExiste_MessageBox, Properties.Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparCadastroAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarCadastroAluguel_Click(object sender, EventArgs e) => this.Close();

        private void LimparCampos()
        {
            livro.Clear();
            cliente.Clear();

            txtBuscarLivroAluguel.Clear();
            txtTituloLivroAluguel.Clear();
            txtAutorLivroAluguel.Clear();
            txtEditoraLivro.Clear();
            txtEdicaoLivro.Clear();
            txtBuscarClienteAluguel.Clear();
            txtNomeClienteAluguel.Clear();
            txtEnderecoClienteAluguel.Clear();
            txtTelefoneClienteAluguel.Clear();
            txtEmailClienteAluguel.Clear();
        }

    }
}
