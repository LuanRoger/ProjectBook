﻿using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using System;
using System.Configuration;
using System.Data;
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
            Cliente cliente;
            //Aplicar a formatação na instânciação do cliente
            if (ConfigurationManager.AppSettings["formatarCliente"] == "1")
            {
                cliente = new Cliente(txtNovoNome.Text.ToUpper(), txtNovoEndereco.Text.ToUpper(), txtNovoCidade.Text.ToUpper(), cmbNovoUf.Text.ToUpper(),
                txtNovoCep.Text.ToUpper(), txtNovoTelefone1.Text.ToUpper(), txtNovoTelefone2.Text.ToUpper(), txtNovoEmail.Text);
                
            }
            else
            {
                cliente = new Cliente(txtNovoNome.Text, txtNovoEndereco.Text, txtNovoCidade.Text, cmbNovoUf.Text,
                    txtNovoCep.Text, txtNovoTelefone1.Text, txtNovoTelefone2.Text, txtNovoEmail.Text);
            }

            if (Verificadores.VerificarCamposCliente(cliente))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
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
            string termoBuscaCliente = txtBuscarClienteEditar.Text;
            if (Verificadores.VerificarStrings(termoBuscaCliente))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            clienteDb.AbrirConexaoDb();
            if (rabBuscarClienteId.Checked) infoCliente = clienteDb.BuscarClienteId(termoBuscaCliente);
            else if (rabBsucarClienteNome.Checked) infoCliente = clienteDb.BuscarClienteNome(termoBuscaCliente);
            clienteDb.FechaConecxaoDb();

            //Caso retorne uma coluna vazia
            try
            {
                PreencherCampos(infoCliente);
            }
            catch
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
