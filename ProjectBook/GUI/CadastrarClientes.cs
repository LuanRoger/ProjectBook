using System;
using System.Configuration;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class CadastrarClientes : Form
    {
        public CadastrarClientes()
        {
            InitializeComponent();
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente;

            //Aplicar a formatação na instânciação do cliente
            if (ConfigurationManager.AppSettings["formatarCliente"] == "1")
            {
                cliente = new Cliente(
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
                cliente = new Cliente(
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
<<<<<<< HEAD
                MessageBox.Show(Strings.PreecherCampoBusca, Strings.MessageBoxError,
=======
                MessageBox.Show(Properties.Resources.preencherCamposObrigatorios_MessageBox, Properties.Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClienteDb clienteDb = new ClienteDb();
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
