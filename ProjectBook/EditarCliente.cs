using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectBook
{
    public partial class EditarCliente : Form
    {
        private ClienteDb clienteDb = new ClienteDb();
        private DataTable infoCliente;
        public EditarCliente()
        {
            InitializeComponent();
        }

        private void btnSalvarEditarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.ClienteFactory(txtNovoNome.Text, txtNovoEndereco.Text, txtNovoCidade.Text, cmbNovoUf.Text,
                txtNovoCep.Text, txtNovoTelefone1.Text, txtNovoTelefone2.Text, txtNovoEmail.Text);

            if (Verificadores.VerificarCamposCliente(cliente))
            {
                MessageBox.Show(Properties.Resources.preencherCampos_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clienteDb.AbrirConexaoDb();
            clienteDb.AtualizarClienteId(infoCliente.Rows[0][0].ToString(), cliente);
            clienteDb.FechaConecxaoDb();

            LimparCampos();
        }
        private void btnCancelarEditarCliente_Click(object sender, EventArgs e) => this.Close();
        private void btnBucarCliente_Click(object sender, EventArgs e)
        {
            clienteDb.AbrirConexaoDb();
            if (rabBuscarClienteId.Checked) infoCliente = clienteDb.BuscarClienteId(txtBuscarClienteEditar.Text);
            else if (rabBsucarClienteNome.Checked) infoCliente = clienteDb.BuscarClienteNome(txtBuscarClienteEditar.Text);
            clienteDb.FechaConecxaoDb();

            PreencherCampos(infoCliente);
        }
        private void btnLimparEditarCliente_Click(object sender, EventArgs e) => LimparCampos();

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
