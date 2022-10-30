using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class CadastrarClientes : Form
    {
        public CadastrarClientes()
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

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            //Aplicar a formatação na instânciação do cliente
            ClienteModel cliente = Globals.configurationController.configuration.formating.FormatClient ? 
                new()
            {
                nomeCompleto = txtNomeCliente.Text.ToUpper(),
                endereco = txtEnderecoCliente.Text.ToUpper(),
                cidade = txtCidadeCliente.Text.ToUpper(),
                estado = cmbEstadoCliente.Text.ToUpper(),
                cep = txtCepCliente.Text.ToUpper(),
                dataNascimento = dtpDataNascimento.Value.Date,
                profissao = txtProfissao.Text.ToUpper(),
                empresa = txtEmpressa.Text.ToUpper(),
                telefone1 = txtTelefone1Cliente.Text.ToUpper(),
                telefone2 = txtTelefone2Cliente.Text.ToUpper(),
                email = txtEmailCliente.Text.ToUpper(),
                observacoes = txtObservacoes.Text.ToUpper()
            } : new()
            {
                nomeCompleto = txtNomeCliente.Text,
                endereco = txtEnderecoCliente.Text,
                cidade = txtCidadeCliente.Text,
                estado = cmbEstadoCliente.Text,
                cep = txtCepCliente.Text,
                dataNascimento = dtpDataNascimento.Value.Date,
                profissao = txtProfissao.Text,
                empresa = txtEmpressa.Text,
                telefone1 = txtTelefone1Cliente.Text,
                telefone2 = txtTelefone2Cliente.Text,
                email = txtEmailCliente.Text,
                observacoes = txtObservacoes.Text
            };
            
            if (Verificadores.VerificarCamposCliente(cliente))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            clienteContext.Create(cliente);
            
            transaction.EndTransaction();
            
            MessageBox.Show(Resources.ClienteRegistrado, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
        }

        private void btnLimparCliente_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarCadastrarClientes_Click(object sender, EventArgs e) => Close();
        private void LimparCampos()
        {
            txtNomeCliente.Clear();
            txtEnderecoCliente.Clear();
            txtCidadeCliente.Clear();
            cmbEstadoCliente.Text = "";
            txtCepCliente.Clear();
            txtProfissao.Clear();
            txtEmpressa.Clear();
            txtTelefone1Cliente.Clear();
            txtTelefone2Cliente.Clear();
            txtEmailCliente.Clear();
            txtObservacoes.Clear();
        }
    }
}
