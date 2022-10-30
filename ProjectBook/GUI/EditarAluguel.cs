using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Model.Enums;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class EditarAluguel : Form
    {
        private AluguelModel? infoAluguelAntigo;
        private LivroModel? infoLivro;
        private ClienteModel? infoCliente;

        public EditarAluguel()
        {
            InitializeComponent();

            btnVerTodosAlugueis.Click += async delegate
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
                
                ListaPesquisa<AluguelModel> listaPesquisa = new(await aluguelContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            btnVerTodosLivros.Click += async delegate
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
                
                ListaPesquisa<LivroModel> listaPesquisa = new(await livrosContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            btnVerTodosClientes.Click += async delegate
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
                
                ListaPesquisa<ClienteModel> listaPesquisa = new(await clienteContext.ReadAllAsync());
                listaPesquisa.Show();
            };
        }

        #region CheckedChanged & Sugestões
        private async void rabBuscarNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            foreach (AluguelModel aluguel in await aluguelContext.ReadAllAsync()) 
                aluguelSugestao.Add($"{aluguel.alugadoPor} - {aluguel.titulo}");
            
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private async void rabBuscarTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            foreach (AluguelModel aluguel in await aluguelContext.ReadAllAsync()) 
                aluguelSugestao.Add($"{aluguel.titulo} - {aluguel.alugadoPor}");
            
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }

        private void rabBuscarNovoLivroCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabBuscarNovoLivroTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestao = new();
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();

            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
                livrosSugestao.Add(livro.titulo);
            
            txtMudarLivroAluguel.AutoCompleteCustomSource = livrosSugestao;
        }
        private async void rabBuscarNovoLivroAutor_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestao = new();
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();

            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
                livrosSugestao.Add(livro.autor);
            
            txtMudarLivroAluguel.AutoCompleteCustomSource = livrosSugestao;
        }

        private void rabBuscarNovoClienteCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtMudarClienteAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabBuscarNovoClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection clienteSugestao = new();
            txtMudarClienteAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();

            foreach (ClienteModel cliente in await clienteContext.ReadAllAsync()) 
                clienteSugestao.Add(cliente.nomeCompleto);
            
            txtMudarClienteAluguel.AutoCompleteCustomSource = clienteSugestao;
        }
        #endregion

        private async void btnBuscarEditarAluguel_Click(object sender, EventArgs e)
        {
            string[] buscarEditarAluguel = txtBuscarAluguel.Text.Split('-', 2, StringSplitOptions.TrimEntries);
            AluguelModel infoAluguel = new();

            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();

            if (buscarEditarAluguel.Length == 1)
            {
                if (rabBuscarNomeCliente.Checked)
                    infoAluguel = (await aluguelContext.SearchAluguelCliente(buscarEditarAluguel[0])).First();
                else if (rabBuscarTituloLivro.Checked)
                    infoAluguel = (await aluguelContext.SearchAluguelLivro(buscarEditarAluguel[0])).First();
                
                infoLivro = (await livrosContext.SearchLivrosTitulo(infoAluguel.titulo)).First();
                infoCliente = (await clienteContext.SearchClienteNome(infoAluguel.alugadoPor)).First();
            }
            else
            {
                string titulo = rabBuscarTituloLivro.Checked ? buscarEditarAluguel[0] : buscarEditarAluguel[1];
                string nomeCliente = rabBuscarNomeCliente.Checked ? buscarEditarAluguel[0] : buscarEditarAluguel[2];

                infoAluguel = (await aluguelContext.SearchAluguelLivroCliente(titulo, nomeCliente)).First();
                infoLivro = (await livrosContext.SearchLivrosTitulo(titulo)).First();
                infoCliente = (await clienteContext.SearchClienteNome(nomeCliente)).First();
            }

            if(Verificadores.VerificarCamposAluguel(infoAluguel))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            infoAluguelAntigo = infoAluguel;
            PreencherCamposAluguel(infoAluguel);
            PreencharCamposLivro(infoLivro);
            PreencherCamposCliente(infoCliente);
        }

        private async void btnBuscarNovoLivro_Click(object sender, EventArgs e)
        {
            string buscarLivro = txtMudarLivroAluguel.Text;

            if (infoAluguelAntigo == null || Verificadores.VerificarStrings(buscarLivro))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();

            if (rabBuscarNovoLivroCodigo.Checked) 
                infoLivro = livrosContext.ReadById(int.Parse(buscarLivro));
            else if (rabBuscarNovoLivroTitulo.Checked) 
                infoLivro = (await livrosContext.SearchLivrosTitulo(buscarLivro)).First();
            else infoLivro = (await livrosContext.SearchLivrosAutor(buscarLivro)).First();

            if(Verificadores.VerificarCamposLivros(infoLivro))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencharCamposLivro(infoLivro);
        }
        private async void btnBuscarNovoCliente_Click(object sender, EventArgs e)
        {
            string buscarCliete = txtMudarClienteAluguel.Text;

            if (Verificadores.VerificarStrings(buscarCliete) || infoAluguelAntigo == null)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            infoCliente = rabBuscarNovoClienteCodigo.Checked ?
                clienteContext.ReadById(int.Parse(buscarCliete)) : 
                (await clienteContext.SearchClienteNome(buscarCliete)).First();

            if(Verificadores.VerificarCamposCliente(infoCliente))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCamposCliente(infoCliente);
        }

        private void btnSalvarEditarAluguel_Click(object sender, EventArgs e)
        {
            AluguelModel aluguel = new()
            {
                titulo = txtNovoTituloLivroAluguel.Text,
                autor = txtNovoAutorAluguel.Text,
                alugadoPor = txtNovoClienteAluguel.Text,
                dataEntrega = dtpEditarDataEntrega.Value,
                dataDevolucao = dtpEditarDataRecebimento.Value,
                status = (StatusAluguel)cmbNovoStatus.SelectedIndex
            };

            if (Verificadores.VerificarCamposAluguel(aluguel) || infoAluguelAntigo == null)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            aluguelContext.UpdateByNomeCliente(aluguel, infoAluguelAntigo.titulo,
                    infoAluguelAntigo.alugadoPor);
            
            transaction.EndTransaction();
            
            MessageBox.Show(Resources.InformacoesAtualizadas_MessageBox, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
        }

        private void PreencherCamposAluguel(AluguelModel infoAluguel)
        {
            txtTituloLivroAluguel.Text = infoAluguel.titulo;
            txtAlugadoPorAluguel.Text = infoAluguel.alugadoPor;
            dtpEditarDataEntrega.Value = infoAluguel.dataEntrega;
            dtpEditarDataRecebimento.Value = infoAluguel.dataDevolucao;
            cmbNovoStatus.Text = infoAluguel.status.ToString();
        }
        private void PreencharCamposLivro(LivroModel infoLivro)
        {
            txtNovoTituloLivroAluguel.Text = infoLivro.titulo;
            txtNovoAutorAluguel.Text = infoLivro.autor;
            txtNovoEditoraLivro.Text = infoLivro.editora;
            txtNovoEdicaoLivro.Text = infoLivro.edicao;
        }
        private void PreencherCamposCliente(ClienteModel infoCliente)
        {
            txtNovoClienteAluguel.Text = infoCliente.nomeCompleto;
            txtNovoEnderecoAluguel.Text = infoCliente.endereco;
            txtNovoTelefoneAluguel.Text = infoCliente.telefone1;
            txtNovoEmailAluguel.Text = infoCliente.email;
        }

        private void btnLimparTxtAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarAluguel_Click(object sender, EventArgs e) => Close();
        private void LimparCampos()
        {
            infoAluguelAntigo = null;

            txtTituloLivroAluguel.Clear();
            txtAlugadoPorAluguel.Clear();
            txtBuscarAluguel.Clear();
            txtMudarLivroAluguel.Clear();
            txtNovoTituloLivroAluguel.Clear();
            txtNovoAutorAluguel.Clear();
            txtNovoEditoraLivro.Clear();
            txtNovoEdicaoLivro.Clear();
            txtMudarClienteAluguel.Clear();
            txtNovoClienteAluguel.Clear();
            txtNovoEnderecoAluguel.Clear();
            txtNovoTelefoneAluguel.Clear();
            txtNovoEmailAluguel.Clear();
            cmbNovoStatus.Text = string.Empty;
        }
    }
}
