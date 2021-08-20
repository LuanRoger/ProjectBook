using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Tipos;

namespace ProjectBook.GUI
{
    public partial class CadastrarAluguel : Form
    {
        private LivroModel livro {get; set;}
        private ClienteModel cliente {get; set;}
        
        public CadastrarAluguel()
        {
            InitializeComponent();

            btnVerLivros.Click += async (_, _) =>
            {
                ListaPesquisa<LivroModel> listaPesquisa = new(await LivrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            btnVerClientes.Click += async (_, _) =>
            {
                ListaPesquisa<ClienteModel> listaPesquisa = new(await ClienteDb.VerTodosClientes());
                listaPesquisa.Show();
            };
            Load += (_, _) => AppInsightMetrics.TrackForm("CadastrarAluguel");
        }

        #region CheckedChanged & Sugestões
        private void rabPesquisarLivroCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabPesquisarLivroTitulo_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarLivroAluguel.AutoCompleteCustomSource = new();
            
            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                txtBuscarLivroAluguel.AutoCompleteCustomSource.Add(livro.titulo);
        }
        private async void rabPesquisarLivroAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarLivroAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarLivroAluguel.AutoCompleteCustomSource = new();

            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                txtBuscarLivroAluguel.AutoCompleteCustomSource.Add(livro.autor);
        }

        private void rabPesquisarClienteCodigo_CheckedChanged(object sender, EventArgs e) => 
            txtBuscarClienteAluguel.AutoCompleteMode = AutoCompleteMode.None;
        private async void rabPesquisarClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarClienteAluguel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarClienteAluguel.AutoCompleteCustomSource = new();
            
            foreach (ClienteModel cliente in await ClienteDb.VerTodosClientes()) 
                txtBuscarClienteAluguel.AutoCompleteCustomSource.Add(cliente.nomeCompleto);
        }
        #endregion

        private void btnBuscarLivroAluguel_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarLivroAluguel.Text;
            if(Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Properties.Resources.PesquiseParaContinuar, Properties.Resources.Error_MessageBox ,
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
                MessageBox.Show(Properties.Resources.PesquiseParaContinuar, Properties.Resources.Error_MessageBox,
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
                MessageBox.Show(Properties.Resources.PesquiseParaContinuar, Properties.Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AluguelDb.CadastrarAluguel(aluguel);
            
            LimparCampos();
        }
        
        private async void PreencharCamposLivro(string livroParaBusca)
        {
            if (rabPesquisarLivroCodigo.Checked) livro = await LivrosDb.BuscarLivrosId(int.Parse(livroParaBusca));
            else if (rabPesquisarLivroTitulo.Checked) livro = (await LivrosDb.BuscarLivrosTitulo(livroParaBusca)).FirstOrDefault();
            else livro = (await LivrosDb.BuscarLivrosAutor(livroParaBusca)).FirstOrDefault();
            
            if(Verificadores.VerificarCamposLivros(livro)) return;
            
            txtTituloLivroAluguel.Text = livro.titulo;
            txtAutorLivroAluguel.Text = livro.autor;
            txtEditoraLivro.Text = livro.editora; 
            txtEdicaoLivro.Text = livro.edicao;
        }
        private async void PreencherCamposClientes(string termoBuscaCliente)
        {
            cliente = rabPesquisarClienteCodigo.Checked ? 
                await ClienteDb.BuscarClienteId(int.Parse(termoBuscaCliente)) :
                (await ClienteDb.BuscarClienteNome(termoBuscaCliente)).FirstOrDefault();
            
            txtNomeClienteAluguel.Text = cliente.nomeCompleto;
            txtEnderecoClienteAluguel.Text = cliente.endereco;
            txtTelefoneClienteAluguel.Text = cliente.telefone1;
            txtEmailClienteAluguel.Text = cliente.email;
        }

        private void btnLimparCadastroAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarCadastroAluguel_Click(object sender, EventArgs e) => this.Close();

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
