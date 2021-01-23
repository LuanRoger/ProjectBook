using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            Cliente cliente;
            //Aplicar a formatação na instânciação do cliente
            if (ConfigurationManager.AppSettings["formatarCliente"] == "1")
            {
                cliente = new Cliente(txtNomeCliente.Text.ToUpper(), txtEnderecoCliente.Text.ToUpper(), txtCidadeCliente.Text.ToUpper(), cmbEstadoCliente.Text.ToUpper(),
                    txtCepCliente.Text.ToUpper(), txtTelefone1Cliente.Text.ToUpper(), txtTelefone2Cliente.Text.ToUpper(), txtEmailCliente.Text);
            }
            else
            {
                cliente = new Cliente(txtNomeCliente.Text, txtEnderecoCliente.Text, txtCidadeCliente.Text, cmbEstadoCliente.Text,
                    txtCepCliente.Text, txtTelefone1Cliente.Text, txtTelefone2Cliente.Text, txtEmailCliente.Text);
            }
            
            if(Verificadores.VerificarCamposCliente(cliente))
            {
                MessageBox.Show(Properties.Resources.preencherCamposObrigatorios_MessageBox, Properties.Resources.error_MessageBox,
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
