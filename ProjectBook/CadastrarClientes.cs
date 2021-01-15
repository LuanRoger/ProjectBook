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
    public partial class CadastrarClientes : Form
    {
        public CadastrarClientes()
        {
            InitializeComponent();
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.ClienteFactory(txtNomeCliente.Text, txtEnderecoCliente.Text, txtCidadeCliente.Text,
                txtEnderecoCliente.Text, txtCepCliente.Text, txtTelefone1Cliente.Text,
                txtTelefone2Cliente.Text, txtEmailCliente.Text);
            if(Verificadores.VerificarCamposCliente(cliente))
            {
                MessageBox.Show(Properties.Resources.PreencherCamposObrigatorios_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClienteDb clienteDb = new ClienteDb();
            clienteDb.AbrirConexaoDb();
            clienteDb.CadastrarCliente(cliente);
            clienteDb.FechaConecxaoDb();

            LimparCampos();
        }

        private void btnLimparCliente_Click(object sender, EventArgs e) => LimparCampos();
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
