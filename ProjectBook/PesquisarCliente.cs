using ProjectBook.DB.SqlServerExpress;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectBook
{
    public partial class PesquisarCliente : Form
    {
        private ClienteDb clienteDb = new ClienteDb();
        public PesquisarCliente()
        {
            InitializeComponent();
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisarCliente.Text;
            if (Verificadores.VerificarStrings(termoPesquisa))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dataTable = new DataTable();

            clienteDb.AbrirConexaoDb();
            if (rabPesquisarId.Checked) dataTable = clienteDb.BuscarClienteId(termoPesquisa);
            else if (rabPesquisarNome.Checked) dataTable = clienteDb.BuscarClienteNome(termoPesquisa);
            clienteDb.FechaConecxaoDb();

            if (Verificadores.VerificarDataTable(dataTable))
            {
                MessageBox.Show(Properties.Resources.clienteNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            ListaPesquisa listaPesquisa = new ListaPesquisa(dataTable);
            listaPesquisa.Show();
            
            txtPesquisarCliente.Clear();
        }
        private void btnCancelarPesquisarCliente_Click(object sender, EventArgs e) => this.Close();
    }
}
