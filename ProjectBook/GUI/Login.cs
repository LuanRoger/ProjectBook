using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.Tipos;
using ProjectBook.Managers;

namespace ProjectBook.GUI
{
    public partial class Login : Form
    {
        private UsuarioDb usuarioDb = new();
        public Login()
        {
            InitializeComponent();
        }

        private void btnFecharLogin_Click(object sender, EventArgs e) => Application.Exit();
        private void Login_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtLoginUsuario.Text, txtLoginSenha.Text) || 
                Verificadores.VerificarStrings(txtLoginCodigo.Text, txtLoginSenha.Text))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DataTable infoUsuario = usuarioDb.LoginUsuario(txtLoginUsuario.Text, txtLoginSenha.Text);
            
            if (Verificadores.VerificarDataTable(infoUsuario))
            {
                infoUsuario = usuarioDb.LoginCodigo(txtLoginCodigo.Text, txtLoginSenha.Text);

                if(Verificadores.VerificarDataTable(infoUsuario))
                {
                    MessageBox.Show(Resources.InformacoesIncorretasLogin, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            UserInfo.UserNowInstance = new UserInfo
            {
                idUsuario = int.Parse(infoUsuario.Rows[0][0].ToString()), 
                userName = infoUsuario.Rows[0][1].ToString(), 
                tipoUsuario = infoUsuario.Rows[0][3].ToString() == "ADM" ? TipoUsuario.ADM : TipoUsuario.USU
            };

            AppManager.ReiniciarPrograma();
        }

        #region txtLeave
        private void txtLoginCodigo_Leave(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtLoginCodigo.Text)) return;

            DataTable codigoUsuario = usuarioDb.BuscarUsuarioId(txtLoginCodigo.Text);

            if (Verificadores.VerificarDataTable(codigoUsuario)) return;

            txtLoginUsuario.Text = codigoUsuario.Rows[0][1].ToString();
        }
        private void txtLoginUsuario_Leave(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtLoginUsuario.Text)) return;

            DataTable nomeUsuario = usuarioDb.BuscarUsuarioNome(txtLoginUsuario.Text);

            if (Verificadores.VerificarDataTable(nomeUsuario)) return;

            txtLoginCodigo.Text = nomeUsuario.Rows[0][0].ToString();
        }
        #endregion

        private void txtLoginSenha_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    btnEntrarLogin.PerformClick();
                    break;
            }
        }
    }
}