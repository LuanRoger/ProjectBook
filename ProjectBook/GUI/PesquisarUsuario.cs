using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Properties;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class PesquisarUsuario : Form
    {
        public PesquisarUsuario()
        {
            InitializeComponent();

            Load += (_, _) =>
            {
                #region MenuClick
                mnuVerAdm.Click += async (_, _) =>
                {
                    IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                    UsuariosContext usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
                    
                    ListaPesquisa<UsuarioModel> listaPesquisa = new(await usuariosContext.GetAllAdms());
                    listaPesquisa.Show();
                };
                mnuVerUsuarios.Click += async (_, _) =>
                {
                    IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                    UsuariosContext usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
                    
                    ListaPesquisa<UsuarioModel> listaPesquisa = new(await usuariosContext.GetAllUsu());
                    listaPesquisa.Show();
                };
                #endregion
            };
        }

        private void btnCancelarBuscaUsuario_Click(object sender, EventArgs e) => Close();
        private async void bntBuscarUsuario_Click(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtNomeUsuarioBusca.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<UsuarioModel> infoUsuario = new();
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            UsuariosContext usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();

            if (rabCodigoUsuario.Checked) infoUsuario.Add(usuariosContext.ReadById(int.Parse(txtNomeUsuarioBusca.Text)));
            else if (rabUsuarioNome.Checked) infoUsuario = await usuariosContext.SearchUsuarioNome(txtNomeUsuarioBusca.Text);

            ListaPesquisa<UsuarioModel> lista = new(infoUsuario);
            lista.Show();
        }
    }
}
