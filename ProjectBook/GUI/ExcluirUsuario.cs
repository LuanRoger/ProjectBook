using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Properties;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class ExcluirUsuario : Form
    {
        public ExcluirUsuario()
        {
            InitializeComponent();
        }

        private void btnPesquisarExcluirUsuario_Click(object sender, EventArgs e)
        {
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<UsuarioModel> usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
            
            UsuarioModel infoUsuario = usuariosContext.ReadById(int.Parse(txtCodigoDeletarUsuario.Text));

            if (Verificadores.VerificarCamposUsuario(infoUsuario))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(string.Format(Resources.ConfirmarExclusao1, infoUsuario.usuario),
                Resources.Error_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (dialogResult != DialogResult.Yes) return;
            
            if(Verificadores.VerificarAdmin(infoUsuario))
            {
                dialogResult = MessageBox.Show(Resources.AvisoDeletarAdmin, Resources.Aviso_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(dialogResult != DialogResult.Yes) return;
            }

            usuariosContext.DeleteById(int.Parse(txtCodigoDeletarUsuario.Text));
            
            transaction.EndTransaction();
            
            LimparCampos();
        }

        private void LimparCampos() =>
            txtCodigoDeletarUsuario.Clear();

        private void btnCancelar_Click(object sender, EventArgs e) => Close();
    }
}
