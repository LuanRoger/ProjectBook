using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties.Languages;

namespace ProjectBook.GUI
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
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dataTable = new DataTable();

            if (rabPesquisarId.Checked) dataTable = clienteDb.BuscarClienteId(termoPesquisa);
            else if (rabPesquisarNome.Checked) dataTable = clienteDb.BuscarClienteNome(termoPesquisa);

            if (Verificadores.VerificarDataTable(dataTable))
            {
                MessageBox.Show(Strings.clienteNaoExiste_MessageBox, Strings.error_MessageBox,
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
