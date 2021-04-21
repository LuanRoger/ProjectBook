using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties.Languages;

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
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabBsucarIdCliente.Checked && !rabBuscarNome.Checked)
            {
                MessageBox.Show(Strings.marcar_opcao_busca, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBsucarIdCliente.Checked) data = clienteDb.BuscarClienteId(termoBusca);
            else if (rabBuscarNome.Checked) data = clienteDb.BuscarClienteNome(termoBusca);
            
            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Strings.clienteNaoExiste_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                $@"{Strings.confirmarExclusao} {data.Rows[0][1]}",
                Strings.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabBuscarNome.Checked) clienteDb.DeletarClienteNome(data.Rows[0][1].ToString());
                else if (rabBsucarIdCliente.Checked) clienteDb.DeletarClienteId(data.Rows[0][0].ToString());
                txtBuscarExcluirCliente.Clear();
            }
        }
        private void btnCancelarExcluirCliente_Click(object sender, EventArgs e) => this.Close();
    }
}
