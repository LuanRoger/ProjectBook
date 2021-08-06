using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class PesquisarCliente : Form
    {
        private ClienteDb clienteDb = new();
        public PesquisarCliente()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("PesquisarCliente");
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisarCliente.Text;
            if (Verificadores.VerificarStrings(termoPesquisa))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dataTable = new();

            if (rabPesquisarId.Checked) dataTable = clienteDb.BuscarClienteId(termoPesquisa);
            else if (rabPesquisarNome.Checked) dataTable = clienteDb.BuscarClienteNome(termoPesquisa);

            if (Verificadores.VerificarDataTable(dataTable))
            {
                MessageBox.Show(Resources.ClienteNaoExiste, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            ListaPesquisa listaPesquisa = new(dataTable);
            listaPesquisa.Show();
            
            txtPesquisarCliente.Clear();
        }
        private void btnCancelarPesquisarCliente_Click(object sender, EventArgs e) => this.Close();
    }
}
