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

        #region CheckChange
        private void rabBsucarIdCliente_CheckedChanged(object sender, EventArgs e) => 
            txtBuscarExcluirCliente.AutoCompleteMode = AutoCompleteMode.None;

        private void rabBuscarNome_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sugestaoCliente = new();
            txtBuscarExcluirCliente.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach(DataRow cliente in clienteDb.VerTodosClientes().Rows) sugestaoCliente.Add(cliente[1].ToString());

            txtBuscarExcluirCliente.AutoCompleteCustomSource = sugestaoCliente;
        }
        #endregion

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarExcluirCliente.Text;
            DataTable data = new();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabBsucarIdCliente.Checked && !rabBuscarNome.Checked)
            {
                MessageBox.Show(Resources.MarcarOpcaoBusca, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBsucarIdCliente.Checked) data = clienteDb.BuscarClienteId(termoBusca);
            else if (rabBuscarNome.Checked) data = clienteDb.BuscarClienteNome(termoBusca);
            
            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Resources.ClienteNaoExiste, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                string.Format(Resources.ConfirmarExclusao1, data.Rows[0][1]),
                Resources.Excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabBuscarNome.Checked) clienteDb.DeletarClienteNome(data.Rows[0][1].ToString());
                else if (rabBsucarIdCliente.Checked) clienteDb.DeletarClienteId(data.Rows[0][0].ToString());
                txtBuscarExcluirCliente.Clear();
            }
        }
        private void btnCancelarExcluirCliente_Click(object sender, EventArgs e) => Close();
    }
}
