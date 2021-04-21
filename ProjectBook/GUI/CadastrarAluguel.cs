using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties.Languages;

namespace ProjectBook.GUI
{
    public partial class CadastrarAluguel : Form
    {
        private AluguelDb aluguelDb = new AluguelDb();
        private LivrosDb livrosDb = new LivrosDb();
        private ClienteDb clienteDb = new ClienteDb();

        private DataTable livro;
        private DataTable cliente;
        public CadastrarAluguel()
        {
            InitializeComponent();
            PrepararSugestoesAluguel();
        }

        private void PrepararSugestoesAluguel()
        {
            AutoCompleteStringCollection aluguelSugestao;

            //Livro
            aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) aluguelSugestao.Add(livro[1].ToString());
            txtBuscarLivroAluguel.AutoCompleteCustomSource = aluguelSugestao;

            //Cliente
            aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow cliente in clienteDb.VerTodosClientes().Rows) aluguelSugestao.Add(cliente[1].ToString());
            txtBuscarClienteAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }

        private void btnBuscarLivroAluguel_Click(object sender, EventArgs e)
        {
            string tituloParaBusca = txtBuscarLivroAluguel.Text;

            if(Verificadores.VerificarStrings(tituloParaBusca))
            {
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox ,
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
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCamposClientes(clienteParaBuscar);
        }

        private void btnSalvarAluguel_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = new Aluguel(
                txtTituloLivroAluguel.Text,
                txtAutorLivroAluguel.Text,
                txtNomeClienteAluguel.Text,
                dtpDataEntrega.Value,
                dtpDataRecebimento.Value,
                Tipos.StatusAluguel.Alugado.ToString());
            
            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aluguelDb.CadastrarAluguel(aluguel);
            
            LimparCampos();
        }
        
        private void PreencharCamposLivro(string tituloParaBusca)
        {
            livro = livrosDb.BuscarLivrosTitulo(tituloParaBusca);

            try
            {
                txtTituloLivroAluguel.Text = livro.Rows[0][1].ToString(); // Titulo do livro
                txtAutorLivroAluguel.Text = livro.Rows[0][2].ToString(); // Autor
            }
            catch
            {
                MessageBox.Show(Strings.livroNaoExiste_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherCamposClientes(string clienteParaBuscar)
        {
            cliente = clienteDb.BuscarClienteNome(clienteParaBuscar);

            try
            {
                txtNomeClienteAluguel.Text = cliente.Rows[0][1].ToString(); // Nome completo
                txtEnderecoClienteAluguel.Text = cliente.Rows[0][2].ToString(); // Endereço
                txtTelefoneClienteAluguel.Text = cliente.Rows[0][6].ToString(); // Telefone 1
                txtEmailClienteAluguel.Text = cliente.Rows[0][8].ToString(); // Telefone 2
            }
            catch
            {
                MessageBox.Show(Strings.clienteNaoExiste_MessageBox, Strings.error_MessageBox,
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
            txtBuscarClienteAluguel.Clear();
            txtNomeClienteAluguel.Clear();
            txtEnderecoClienteAluguel.Clear();
            txtTelefoneClienteAluguel.Clear();
            txtEmailClienteAluguel.Clear();
        }
    }
}
