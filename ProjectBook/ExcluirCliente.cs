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
    public partial class ExcluirCliente : Form
    {
        ClienteDb clienteDb = new ClienteDb();
        public ExcluirCliente()
        {
            InitializeComponent();
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            DataTable data = clienteDb.BuscarClienteId(txtBuscarExcluirCliente.Text);

            if (Verificadores.VerificarDataTable(data) == true)
            {
                MessageBox.Show("Este livro não existe", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show($"Deseja realmente excluir {data.Rows[0][0]} alugado por {data.Rows[0][2]}?",
            "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            clienteDb.AbrirConexaoDb();
            if (resultadoExcluir == DialogResult.Yes) clienteDb.DeletarClienteId(data.Rows[0][0].ToString());
            clienteDb.FechaConecxaoDb();
        }
    }
}
