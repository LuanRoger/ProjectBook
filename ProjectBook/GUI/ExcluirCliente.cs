using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirCliente : Form
    {
        public ExcluirCliente()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirCliente");
        }

        #region CheckChange
        private void rabBsucarIdCliente_CheckedChanged(object sender, EventArgs e) => 
            txtBuscarExcluirCliente.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabBuscarNome_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sugestaoCliente = new();
            txtBuscarExcluirCliente.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach(ClienteModel cliente in await ClienteDb.VerTodosClientes()) 
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

            if (rabBsucarIdCliente.Checked) 
                clienteInfo = await ClienteDb.BuscarClienteId(int.Parse(termoBusca));
            else if (rabBuscarNome.Checked) 
                clienteInfo = (await ClienteDb.BuscarClienteNome(termoBusca)).First();
            
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
            
            if (rabBuscarNome.Checked) ClienteDb.DeletarClienteNome(clienteInfo.nomeCompleto);
            else if (rabBsucarIdCliente.Checked) ClienteDb.DeletarClienteId(clienteInfo.id);
            
            LimparCamposExcluirCliente();
        }
        private void btnCancelarExcluirCliente_Click(object sender, EventArgs e) => Close();
        
        private void LimparCamposExcluirCliente()
        {
            txtBuscarExcluirCliente.Clear();
        }
    }
}
