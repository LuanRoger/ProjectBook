using System;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Managers.Configuration;
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
                ListaPesquisa<ClienteModel> listaPesquisa = new(await ClienteDb.VerTodosClientes());
                listaPesquisa.Show();
            };
            btnPesquisarCliente.Click += delegate
            {
                PesquisarCliente pesquisarCliente = new();
                pesquisarCliente.Show();
            };
            Load += (_, _) => AppInsightMetrics.TrackForm("CadastrarCliente");
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            ClienteModel cliente;

            //Aplicar a formatação na instânciação do cliente
            if (AppConfigurationManager.configuration.formating.FormatClient)
            {
                cliente = new()
                {
                    nomeCompleto = txtNomeCliente.Text.ToUpper(),
                    endereco = txtEnderecoCliente.Text.ToUpper(),
                    cidade = txtCidadeCliente.Text.ToUpper(),
                    estado = cmbEstadoCliente.Text.ToUpper(),
                    cep = txtCepCliente.Text.ToUpper(),
                    telefone1 = txtTelefone1Cliente.Text.ToUpper(),
                    telefone2 = txtTelefone2Cliente.Text.ToUpper(),
                    email = txtEmailCliente.Text
                };
            }
            else
            {
                cliente = new()
                {
                    nomeCompleto = txtNomeCliente.Text,
                    endereco = txtEnderecoCliente.Text,
                    cidade = txtCidadeCliente.Text,
                    estado = cmbEstadoCliente.Text,
                    cep = txtCepCliente.Text,
                    telefone1 = txtTelefone1Cliente.Text,
                    telefone2 = txtTelefone2Cliente.Text,
                    email = txtEmailCliente.Text
                };
            }

            if (Verificadores.VerificarCamposCliente(cliente))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClienteDb.CadastrarCliente(cliente);
            
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
            txtTelefone1Cliente.Clear();
            txtTelefone2Cliente.Clear();
            txtEmailCliente.Clear();
        }
    }
}
