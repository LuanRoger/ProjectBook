using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class PesquisarCliente : Form
    {
        public PesquisarCliente()
        {
            InitializeComponent();
        }

        private async void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisarCliente.Text;
            if (Verificadores.VerificarStrings(termoPesquisa))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            List<ClienteModel> cliente = new();
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            if (rabPesquisarId.Checked) cliente.Add(clienteContext.ReadById(int.Parse(termoPesquisa)));
            else if (rabPesquisarNome.Checked) cliente = await clienteContext.SearchClienteNome(termoPesquisa);

            ListaPesquisa<ClienteModel> listaPesquisa = new(cliente);
            listaPesquisa.Show();
            
            txtPesquisarCliente.Clear();
        }
        private void btnCancelarPesquisarCliente_Click(object sender, EventArgs e) => Close();
    }
}
