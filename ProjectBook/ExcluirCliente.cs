using ProjectBook.DB.SqlServerExpress;
using System;
using System.Data;
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
            string termoBusca = txtBuscarExcluirCliente.Text;
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clienteDb.AbrirConexaoDb();
            DataTable data = clienteDb.BuscarClienteId(termoBusca);
            clienteDb.FechaConecxaoDb();
            
            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                $"{Properties.Resources.confirmarExclusao} {data.Rows[0][1]}",
                Properties.Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            clienteDb.AbrirConexaoDb();
            if (resultadoExcluir == DialogResult.Yes) clienteDb.DeletarClienteId(data.Rows[0][0].ToString());
            clienteDb.FechaConecxaoDb();
        }
    }
}
