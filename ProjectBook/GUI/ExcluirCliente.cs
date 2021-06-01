using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirCliente : Form
    {
        ClienteDb clienteDb = new();
        public ExcluirCliente()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirCliente");
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarExcluirCliente.Text;
            DataTable data = new();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabBsucarIdCliente.Checked && !rabBuscarNome.Checked)
            {
                MessageBox.Show(Resources.MarcarOpcao, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBsucarIdCliente.Checked) data = clienteDb.BuscarClienteId(termoBusca);
            else if (rabBuscarNome.Checked) data = clienteDb.BuscarClienteNome(termoBusca);
            
            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Resources.ClienteNExiste, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                string.Format(Resources.ConfirmarExclusao1, data.Rows[0][1]),
                Resources.MessageBoxExcluir, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
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
