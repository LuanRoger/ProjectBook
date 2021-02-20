using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook.GUI
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
            DataTable data = new DataTable();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBsucarIdCliente.Checked)
            {
                clienteDb.AbrirConexaoDb();
                data = clienteDb.BuscarClienteId(termoBusca);
                clienteDb.FechaConecxaoDb();
            }
            else if (rabBuscarNome.Checked)
            {
                clienteDb.AbrirConexaoDb();
                data = clienteDb.BuscarClienteNome(termoBusca);
                clienteDb.FechaConecxaoDb();
            }
            
            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.clienteNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                $@"{Properties.Resources.confirmarExclusao} {data.Rows[0][1]}",
                Properties.Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabBuscarNome.Checked)
                {
                    clienteDb.AbrirConexaoDb();
                    clienteDb.DeletarClienteNome(data.Rows[0][1].ToString());
                    clienteDb.FechaConecxaoDb();
                }
                else if (rabBsucarIdCliente.Checked)
                {
                    clienteDb.AbrirConexaoDb();
                    clienteDb.DeletarClienteId(data.Rows[0][0].ToString());
                    clienteDb.FechaConecxaoDb();
                }
                txtBuscarExcluirCliente.Clear();
            }
        }
        private void btnCancelarExcluirCliente_Click(object sender, EventArgs e) => this.Close();
    }
}
