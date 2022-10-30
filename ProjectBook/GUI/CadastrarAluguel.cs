using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Model.Enums;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class CadastrarAluguel : Form
    {
        private LivroModel? livro { get; set; }
        private ClienteModel? cliente { get; set; }
        
        public CadastrarAluguel()
        {
            InitializeComponent();

            btnVerLivros.Click += async (_, _) =>
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                LivrosContext livroContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
                
                ListaPesquisa<LivroModel> listaPesquisa = new(await livroContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            btnVerClientes.Click += async (_, _) =>
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
                
                ListaPesquisa<ClienteModel> listaPesquisa = new(await clienteContext.ReadAllAsync());
                listaPesquisa.Show();
            };
        }

        #region CheckedChanged & Sugestões
        private void rabPesquisarLivroCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabPesquisarLivroTitulo_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarLivroAluguel.AutoCompleteCustomSource = new();
            
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livroContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livroInDb in await livroContext.ReadAllAsync()) 
                txtBuscarLivroAluguel.AutoCompleteCustomSource.Add(livroInDb.titulo);
        }
        private async void rabPesquisarLivroAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarLivroAluguel.AutoCompleteCustomSource = new();
            
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livroContext = (LivrosContext)transaction.StartTransaction<LivroModel>();

            foreach (LivroModel livroInDb in await livroContext.ReadAllAsync()) 
                txtBuscarLivroAluguel.AutoCompleteCustomSource.Add(livroInDb.autor);
        }

        private void rabPesquisarClienteCodigo_CheckedChanged(object sender, EventArgs e) => 
            txtBuscarClienteAluguel.AutoCompleteMode = AutoCompleteMode.None;
        private async void rabPesquisarClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarClienteAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarClienteAluguel.AutoCompleteCustomSource = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            foreach (ClienteModel clienteInDb in await clienteContext.ReadAllAsync()) 
                txtBuscarClienteAluguel.AutoCompleteCustomSource.Add(clienteInDb.nomeCompleto);
        }
        #endregion

        private void btnBuscarLivroAluguel_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarLivroAluguel.Text;
            if(Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox ,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencharCamposLivro(termoBusca);
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string clienteParaBuscar = txtBuscarClienteAluguel.Text;

            if(Verificadores.VerificarStrings(clienteParaBuscar))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCamposClientes(clienteParaBuscar);
        }

        private void btnSalvarAluguel_Click(object sender, EventArgs e)
        {
            AluguelModel aluguel = new()
            {
                titulo = txtTituloLivroAluguel.Text,
                autor = txtAutorLivroAluguel.Text,
                alugadoPor = txtNomeClienteAluguel.Text,
                dataEntrega = dtpDataEntrega.Value,
                dataDevolucao = dtpDataRecebimento.Value,
                status = (StatusAluguel)cmbStatusAluguel.SelectedItem
            };
            
            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            aluguelContext.Create(aluguel);
            
            transaction.EndTransaction();
            
            MessageBox.Show(Resources.AluguelRegistrado, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            LimparCampos();
        }
        
        private async void PreencharCamposLivro(string livroParaBusca)
        {
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livroContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            if (rabPesquisarLivroCodigo.Checked) livro = livroContext.ReadById(int.Parse(livroParaBusca));
            else if (rabPesquisarLivroTitulo.Checked) livro = (await livroContext.SearchLivrosTitulo(livroParaBusca)).FirstOrDefault();
            else livro = (await livroContext.SearchLivrosAutor(livroParaBusca)).FirstOrDefault();
            
            if(livro is null || Verificadores.VerificarCamposLivros(livro)) return;
            
            txtTituloLivroAluguel.Text = livro.titulo;
            txtAutorLivroAluguel.Text = livro.autor;
            txtEditoraLivro.Text = livro.editora; 
            txtEdicaoLivro.Text = livro.edicao;
            
            await transaction.EndTransactionAsync();
        }
        private async void PreencherCamposClientes(string termoBuscaCliente)
        {
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            cliente = rabPesquisarClienteCodigo.Checked ? 
                clienteContext.ReadById(int.Parse(termoBuscaCliente)) :
                (await clienteContext.SearchClienteNome(termoBuscaCliente)).FirstOrDefault();
            
            if(cliente is null) return;
            
            txtNomeClienteAluguel.Text = cliente.nomeCompleto;
            txtEnderecoClienteAluguel.Text = cliente.endereco;
            txtTelefoneClienteAluguel.Text = cliente.telefone1;
            txtEmailClienteAluguel.Text = cliente.email;
        }

        private void btnLimparCadastroAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarCadastroAluguel_Click(object sender, EventArgs e) => Close();

        private void LimparCampos()
        {
            livro = null;
            cliente = null;

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
