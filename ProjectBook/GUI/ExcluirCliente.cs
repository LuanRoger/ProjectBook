using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirCliente : Form
    {
        public ExcluirCliente()
        {
            InitializeComponent();
        }

        #region CheckChange
        private void rabBsucarIdCliente_CheckedChanged(object sender, EventArgs e) => 
            txtBuscarExcluirCliente.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabBuscarNome_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sugestaoCliente = new();
            txtBuscarExcluirCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();

            foreach(ClienteModel cliente in await clienteContext.ReadAllAsync()) 
                sugestaoCliente.Add(cliente.nomeCompleto);

            txtBuscarExcluirCliente.AutoCompleteCustomSource = sugestaoCliente;
        }
        #endregion

        private async void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarExcluirCliente.Text;
            ClienteModel clienteInfo = new();
            
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
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();

            if (rabBsucarIdCliente.Checked) 
                clienteInfo = clienteContext.ReadById(int.Parse(termoBusca));
            else if (rabBuscarNome.Checked) 
                clienteInfo = (await clienteContext.SearchClienteNome(termoBusca)).First();
            
            if (Verificadores.VerificarCamposCliente(clienteInfo))
            {
                MessageBox.Show(Resources.ClienteNaoExiste, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                string.Format(Resources.ConfirmarExclusao1, clienteInfo.nomeCompleto),
                Resources.Excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultadoExcluir != DialogResult.Yes) return;

            if (rabBuscarNome.Checked) clienteContext.DeleteByClienteNome(clienteInfo.nomeCompleto);
            else if (rabBsucarIdCliente.Checked) clienteContext.DeleteById(clienteInfo.id);
            
            await transaction.EndTransactionAsync();
            
            MessageBox.Show(Resources.ClienteExcluido, Resources.Informacao_MessageBox, MessageBoxButtons.OK);
            
            LimparCamposExcluirCliente();
        }
        private void btnCancelarExcluirCliente_Click(object sender, EventArgs e) => Close();
        
        private void LimparCamposExcluirCliente()
        {
            txtBuscarExcluirCliente.Clear();
        }
    }
}
