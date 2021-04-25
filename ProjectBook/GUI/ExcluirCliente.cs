using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

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
<<<<<<< HEAD
                MessageBox.Show(Strings.PreecherCampoBusca, Strings.MessageBoxError,
=======
                MessageBox.Show(Resources.preencherCampoBusca_MessageBox, Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabBsucarIdCliente.Checked && !rabBuscarNome.Checked)
            {
<<<<<<< HEAD
                MessageBox.Show(Strings.MarcarOpcao, Strings.MessageBoxError,
=======
                MessageBox.Show(Resources.marcar_opcao_busca, Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBsucarIdCliente.Checked) data = clienteDb.BuscarClienteId(termoBusca);
            else if (rabBuscarNome.Checked) data = clienteDb.BuscarClienteNome(termoBusca);
            
            if (Verificadores.VerificarDataTable(data))
            {
<<<<<<< HEAD
                MessageBox.Show(Strings.ClienteNExiste, Strings.MessageBoxError,
=======
                MessageBox.Show(Resources.clienteNaoExiste_MessageBox, Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
<<<<<<< HEAD
                string.Format(Strings.ConfirmarExcluisao1, data.Rows[0][1]),
                Strings.MessageBoxExcluir, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
=======
                $@"{Resources.confirmarExclusao} {data.Rows[0][1]}",
                Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
            
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
