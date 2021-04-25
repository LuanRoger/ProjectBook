using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

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
<<<<<<< HEAD
                MessageBox.Show(Strings.PreecherCampoBusca, Strings.MessageBoxError,
=======
                MessageBox.Show(Resources.preencherCampoBusca_MessageBox, Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dataTable = new DataTable();

            if (rabPesquisarId.Checked) dataTable = clienteDb.BuscarClienteId(termoPesquisa);
            else if (rabPesquisarNome.Checked) dataTable = clienteDb.BuscarClienteNome(termoPesquisa);

            if (Verificadores.VerificarDataTable(dataTable))
            {
<<<<<<< HEAD
                MessageBox.Show(Strings.ClienteNExiste, Strings.MessageBoxError,
=======
                MessageBox.Show(Resources.clienteNaoExiste_MessageBox, Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
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
