using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook
{
    public partial class CadastrarAluguel : Form
    {
        private LivrosDb livrosDb = new LivrosDb();
        private ClienteDb clienteDb = new ClienteDb();
        private AluguelDb aluguelDb = new AluguelDb();
        public CadastrarAluguel()
        {
            InitializeComponent();
            
            //Preparar sugestões
            //Livro
            AutoCompleteStringCollection livrosSugestoes = new AutoCompleteStringCollection();
            livrosDb.AbrirConexaoDb();
            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) livrosSugestoes.Add(livro[1].ToString());
            livrosDb.FechaConecxaoDb();
            txtBuscarLivroAluguel.AutoCompleteCustomSource = livrosSugestoes;
            
            //Cliente
            AutoCompleteStringCollection clienteSugestoes = new AutoCompleteStringCollection();
            clienteDb.AbrirConexaoDb();
            foreach (DataRow cliente in clienteDb.VerTodosClientes().Rows) clienteSugestoes.Add(cliente[1].ToString());
            clienteDb.FechaConecxaoDb();
            txtBuscarClienteAluguel.AutoCompleteCustomSource = clienteSugestoes;
        }

        private void btnBuscarLivroAluguel_Click(object sender, EventArgs e)
        {
            string tituloParaBusca = txtBuscarLivroAluguel.Text;

            if(Verificadores.VerificarStrings(tituloParaBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox ,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            livrosDb.AbrirConexaoDb();
            DataTable table = livrosDb.BuscarLivrosTitulo(tituloParaBusca);
            livrosDb.FechaConecxaoDb();

            //Preencher campos de livros
            try
            {
                txtTituloLivroAluguel.Text = table.Rows[0][1].ToString();
                txtAutorLivroAluguel.Text = table.Rows[0][2].ToString();
            }catch
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string clienteParaBuscar = txtBuscarClienteAluguel.Text;

            if(Verificadores.VerificarStrings(clienteParaBuscar))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            livrosDb.AbrirConexaoDb();
            DataTable table = clienteDb.BuscarClienteNome(clienteParaBuscar);
            livrosDb.FechaConecxaoDb();

            //Preencher campos de clientes
            try
            {
                txtNomeClienteAluguel.Text = table.Rows[0][1].ToString();
                txtEnderecoClienteAluguel.Text = table.Rows[0][2].ToString();
                txtTelefoneClienteAluguel.Text = table.Rows[0][6].ToString();
                txtEmailClienteAluguel.Text = table.Rows[0][8].ToString();
            }
            catch
            {
                MessageBox.Show(Properties.Resources.clienteNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarAluguel_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = new Aluguel(txtTituloLivroAluguel.Text, txtAutorLivroAluguel.Text, txtNomeClienteAluguel.Text,
                dtpDataEntrega.Value, dtpDataRecebimento.Value, Tipos.StatusAluguel.Alugado.ToString());
            
            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aluguelDb.AbrirConexaoDb();
            aluguelDb.CadastrarAluguel(aluguel);
            aluguelDb.FechaConecxaoDb();
            
            LimparCampos();
        }
        
        private void btnLimparCadastroAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarCadastroAluguel_Click(object sender, EventArgs e) => this.Close();

        private void LimparCampos()
        {
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
