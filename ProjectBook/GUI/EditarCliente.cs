using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.GUI
{
    public partial class EditarCliente : Form
    {
        private ClienteDb clienteDb = new();
        private DataTable infoCliente;

        public EditarCliente()
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
            Load += (_, _) => AppInsightMetrics.TrackForm("EditarCliente");
        }

        #region CheckedChanged
        private void rabBuscarClienteId_CheckedChanged(object sender, EventArgs e) => txtBuscarClienteEditar
            .AutoCompleteMode = AutoCompleteMode.None;

        private void rabBuscarClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarClienteEditar.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection autoCompleteStringCollection = new();
            foreach (DataRow cliente in clienteDb.VerTodosClientes().Rows) autoCompleteStringCollection.Add(cliente[1].ToString());
            txtBuscarClienteEditar.AutoCompleteCustomSource = autoCompleteStringCollection;
        }
        #endregion

        private void btnBucarCliente_Click(object sender, EventArgs e)
        {
            string termoBuscaCliente = txtBuscarClienteEditar.Text;

            if (Verificadores.VerificarStrings(termoBuscaCliente))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabBuscarClienteId.Checked && !rabBuscarClienteNome.Checked)
            {
                MessageBox.Show(Resources.MarcarOpcao, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBuscarClienteId.Checked) infoCliente = clienteDb.BuscarClienteId(termoBuscaCliente);
            else if (rabBuscarClienteNome.Checked) infoCliente = clienteDb.BuscarClienteNome(termoBuscaCliente);

            if (Verificadores.VerificarDataTable(infoCliente))
            {
                MessageBox.Show(Resources.ClienteNExiste, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCampos(infoCliente);
        }
        private void btnSalvarEditarCliente_Click(object sender, EventArgs e)
        {
            ClienteModel cliente;
            //Aplicar a formatação na instânciação do cliente
            if (AppConfigurationManager.formattingConfiguration.FormatClient)
            {
                cliente = new ClienteModel(
                    txtNovoNome.Text.ToUpper(),
                    txtNovoEndereco.Text.ToUpper(),
                    txtNovoCidade.Text.ToUpper(),
                    cmbNovoUf.Text.ToUpper(),
                    txtNovoCep.Text.ToUpper(),
                    txtNovoTelefone1.Text.ToUpper(),
                    txtNovoTelefone2.Text.ToUpper(),
                    txtNovoEmail.Text);
                
            }
            else
            {
                cliente = new ClienteModel(
                    txtNovoNome.Text,
                    txtNovoEndereco.Text,
                    txtNovoCidade.Text,
                    cmbNovoUf.Text,
                    txtNovoCep.Text,
                    txtNovoTelefone1.Text,
                    txtNovoTelefone2.Text,
                    txtNovoEmail.Text);
            }

            if (Verificadores.VerificarCamposCliente(cliente) || Verificadores.VerificarDataTable(infoCliente))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clienteDb.AtualizarClienteId(infoCliente.Rows[0][0].ToString(), cliente);

            LimparCampos();
        }

        private void btnLimparEditarCliente_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarCliente_Click(object sender, EventArgs e) => this.Close();
        private void PreencherCampos(DataTable info)
        {
            txtNovoNome.Text = info.Rows[0][1].ToString();
            txtNovoEndereco.Text = info.Rows[0][2].ToString();
            txtNovoCidade.Text = info.Rows[0][3].ToString();
            cmbNovoUf.Text = info.Rows[0][4].ToString();
            txtNovoCep.Text = info.Rows[0][5].ToString();
            txtNovoTelefone1.Text = info.Rows[0][6].ToString();
            txtNovoTelefone2.Text = info.Rows[0][7].ToString();
            txtNovoEmail.Text = info.Rows[0][8].ToString();
        }
        private void LimparCampos()
        {
            infoCliente.Clear();
            txtBuscarClienteEditar.Clear();
            txtNovoNome.Clear();
            txtNovoEndereco.Clear();
            txtNovoCidade.Clear();
            cmbNovoUf.Text = "";
            txtNovoCep.Clear();
            txtNovoTelefone1.Clear();
            txtNovoTelefone2.Clear();
            txtNovoEmail.Clear();
        }
    }
}
