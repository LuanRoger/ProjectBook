using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using ProjectBook.Controllers;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Properties;
using ProjectBook.Managers;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            chbKeepConnected.Checked = Globals.configurationController.configuration.login.keepConnected;
        }

        private void btnFecharLogin_Click(object sender, EventArgs e) => Application.Exit();
        private void Login_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {
            if(Verificadores.VerificarStrings(txtLoginUsuario.Text, txtLoginSenha.Text) || 
                Verificadores.VerificarStrings(txtLoginCodigo.Text, txtLoginSenha.Text))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            UsuariosContext usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
            
            UsuarioModel infoUsuario = usuariosContext.LoginUserName(txtLoginUsuario.Text, txtLoginSenha.Text);
            
            if(Verificadores.VerificarCamposUsuario(infoUsuario))
            {
                infoUsuario = usuariosContext.LoginId(int.Parse(txtLoginCodigo.Text), txtLoginSenha.Text);

                if(Verificadores.VerificarCamposUsuario(infoUsuario))
                {
                    MessageBox.Show(Resources.InformacoesIncorretasLogin, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Globals.userSessionController.userCurrentSession = new()
            {
                id = infoUsuario.id,
                usuario = infoUsuario.usuario, 
                tipo = infoUsuario.tipo
            };
            Globals.configurationController.configuration.login = new()
            {
                keepConnected = chbKeepConnected.Checked
            };
            Globals.configurationController.SaveConfig();

            AppController.RestartApplication();
        }

        #region txtLeave
        private void txtLoginCodigo_Leave(object sender, EventArgs e)
        {
            if(Verificadores.VerificarStrings(txtLoginCodigo.Text)) return;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            UsuariosContext usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();

            UsuarioModel codigoUsuario = usuariosContext.ReadById(int.Parse(txtLoginCodigo.Text));

            if(Verificadores.VerificarCamposUsuario(codigoUsuario)) return;

            txtLoginUsuario.Text = codigoUsuario.usuario;
        }
        private async void txtLoginUsuario_Leave(object sender, EventArgs e)
        {
            if(Verificadores.VerificarStrings(txtLoginUsuario.Text)) return;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            UsuariosContext usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
            UsuarioModel? nomeUsuario = (await usuariosContext.SearchUsuarioNome(txtLoginUsuario.Text)).FirstOrDefault();

            if(nomeUsuario is null || Verificadores.VerificarCamposUsuario(nomeUsuario)) return;

            txtLoginCodigo.Text = nomeUsuario.id.ToString();
        }
        #endregion

        private void txtLoginSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) btnEntrarLogin.PerformClick();
        }
    }
}