using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Properties;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class EditarCliente : Form
    {
        private ClienteModel? infoCliente;

        public EditarCliente()
        {
            InitializeComponent();

            btnVerClientes.Click += async delegate
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
                
                ListaPesquisa<ClienteModel> listaPesquisa = new(await clienteContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            btnPesquisarCliente.Click += delegate
            {
                PesquisarCliente pesquisarCliente = new();
                pesquisarCliente.Show();
            };
        }

        #region CheckedChanged
        private void rabBuscarClienteId_CheckedChanged(object sender, EventArgs e) => txtBuscarClienteEditar
            .AutoCompleteMode = AutoCompleteMode.None;

        private async void rabBuscarClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarClienteEditar.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection autoCompleteStringCollection = new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            foreach (ClienteModel cliente in await clienteContext.ReadAllAsync()) 
                autoCompleteStringCollection.Add(cliente.nomeCompleto);
            
            txtBuscarClienteEditar.AutoCompleteCustomSource = autoCompleteStringCollection;
        }
        #endregion

        private async void btnBucarCliente_Click(object sender, EventArgs e)
        {
            string termoBuscaCliente = txtBuscarClienteEditar.Text;

            if (Verificadores.VerificarStrings(termoBuscaCliente))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(!rabBuscarClienteId.Checked && !rabBuscarClienteNome.Checked)
            {
                MessageBox.Show(Resources.MarcarOpcaoBusca, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            if (rabBuscarClienteId.Checked) infoCliente = 
                clienteContext.ReadById(int.Parse(termoBuscaCliente));
            else if (rabBuscarClienteNome.Checked) infoCliente = 
                (await clienteContext.SearchClienteNome(termoBuscaCliente)).First();

            if (infoCliente is null || Verificadores.VerificarCamposCliente(infoCliente))
            {
                MessageBox.Show(Resources.ClienteNaoExiste, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCampos(infoCliente);
        }
        private void btnSalvarEditarCliente_Click(object sender, EventArgs e)
        {
            ClienteModel cliente = Globals.configurationController.configuration.formating.FormatClient ? 
                new()
            {
                nomeCompleto = txtNovoNome.Text.ToUpper(),
                endereco = txtNovoEndereco.Text.ToUpper(),
                cidade = txtNovoCidade.Text.ToUpper(),
                estado = cmbNovoUf.Text.ToUpper(),
                cep = txtNovoCep.Text.ToUpper(),
                dataNascimento = dtpNovaDataNascimento.Value.Date,
                profissao = txtNovoProfissao.Text.ToUpper(),
                empresa = txtNovoEmpressa.Text.ToUpper(),
                telefone1 = txtNovoTelefone1.Text.ToUpper(),
                telefone2 = txtNovoTelefone2.Text.ToUpper(),
                email = txtNovoEmail.Text,
                observacoes = txtNovoObservacoes.Text.ToUpper()
            } : new()
            {
                nomeCompleto = txtNovoNome.Text,
                endereco = txtNovoEndereco.Text,
                cidade = txtNovoCidade.Text,
                estado = cmbNovoUf.Text,
                cep = txtNovoCep.Text,
                dataNascimento = dtpNovaDataNascimento.Value.Date,
                profissao = txtNovoProfissao.Text,
                empresa = txtNovoEmpressa.Text,
                telefone1 = txtNovoTelefone1.Text,
                telefone2 = txtNovoTelefone2.Text,
                email = txtNovoEmail.Text,
                observacoes = txtNovoObservacoes.Text
            };

            if (infoCliente is null || Verificadores.VerificarCamposCliente(cliente) || Verificadores.VerificarCamposCliente(infoCliente))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            clienteContext.UpdateById(infoCliente.id, cliente);
            
            transaction.EndTransaction();
            
            MessageBox.Show(Resources.InformacoesAtualizadas_MessageBox, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
        }

        private void btnLimparEditarCliente_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarCliente_Click(object sender, EventArgs e) => Close();
        private void PreencherCampos(ClienteModel info)
        {
            txtNovoNome.Text = info.nomeCompleto;
            txtNovoEndereco.Text = info.endereco;
            txtNovoCidade.Text = info.cidade;
            cmbNovoUf.Text = info.estado;
            txtNovoCep.Text = info.cep;
            dtpNovaDataNascimento.Value = info.dataNascimento;
            txtNovoProfissao.Text = info.profissao;
            txtNovoEmpressa.Text = info.empresa;
            txtNovoTelefone1.Text = info.telefone1;
            txtNovoTelefone2.Text = info.telefone2;
            txtNovoEmail.Text = info.email;
            txtNovoObservacoes.Text = info.observacoes;
        }
        private void LimparCampos()
        {
            infoCliente = null;
            txtBuscarClienteEditar.Clear();
            txtNovoNome.Clear();
            txtNovoEndereco.Clear();
            txtNovoCidade.Clear();
            cmbNovoUf.Text = "";
            txtNovoCep.Clear();
            txtNovoProfissao.Clear();
            txtNovoEmpressa.Clear();
            txtNovoTelefone1.Clear();
            txtNovoTelefone2.Clear();
            txtNovoEmail.Clear();
            txtNovoObservacoes.Clear();
        }
    }
}
