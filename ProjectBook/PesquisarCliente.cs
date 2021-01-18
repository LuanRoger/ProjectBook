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
        ClienteDb clienteDb = new ClienteDb();
        public PesquisarCliente()
        {
            InitializeComponent();
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisarCliente.Text;
            DataTable dataTable;

            clienteDb.AbrirConexaoDb();
            if (rabPesquisarId.Checked) dataTable = clienteDb.BuscarClienteId(termoPesquisa);
            else if (rabPesquisarNome.Checked) dataTable = clienteDb.BuscarClienteNome(termoPesquisa);
            else return;
            clienteDb.FechaConecxaoDb();

            ListaLivros listaLivros = new ListaLivros(dataTable);
            listaLivros.Show();
        }
    }
}
