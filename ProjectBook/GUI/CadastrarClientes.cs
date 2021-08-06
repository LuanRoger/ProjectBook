using System;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.GUI
{
    public partial class CadastrarClientes : Form
    {
        ClienteDb clienteDb = new();

        public CadastrarClientes()
        {
            InitializeComponent();

            btnVerClientes.Click += delegate
            {
                ListaPesquisa listaPesquisa = new(clienteDb.VerTodosClientes());
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
            if (AppConfigurationManager.configuration.FormatClient)
            {
                cliente = new ClienteModel(
                    txtNomeCliente.Text.ToUpper(),
                    txtEnderecoCliente.Text.ToUpper(),
                    txtCidadeCliente.Text.ToUpper(),
                    cmbEstadoCliente.Text.ToUpper(),
                    txtCepCliente.Text.ToUpper(),
                    txtTelefone1Cliente.Text.ToUpper(),
                    txtTelefone2Cliente.Text.ToUpper(),
                    txtEmailCliente.Text);
            }
            else
            {
                cliente = new ClienteModel(
                    txtNomeCliente.Text,
                    txtEnderecoCliente.Text,
                    txtCidadeCliente.Text,
                    cmbEstadoCliente.Text,
                    txtCepCliente.Text,
                    txtTelefone1Cliente.Text,
                    txtTelefone2Cliente.Text,
                    txtEmailCliente.Text);
            }

            if (Verificadores.VerificarCamposCliente(cliente))
            {
                MessageBox.Show(Properties.Resources.PreencherCamposObrigatorios, Properties.Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clienteDb.CadastrarCliente(cliente);

            LimparCampos();
        }

        private void btnLimparCliente_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarCadastrarClientes_Click(object sender, EventArgs e) => this.Close();
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
