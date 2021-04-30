using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

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
                MessageBox.Show(Resources.preencherCamposObrigatorios_MessageBox, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DataTable infoUsuario = usuarioDb.LoginUsuario(txtLoginUsuario.Text, txtLoginSenha.Text);
            
            if (Verificadores.VerificarDataTable(infoUsuario))
            {
                infoUsuario = usuarioDb.LoginCodigo(txtLoginCodigo.Text, txtLoginSenha.Text);

                if(Verificadores.VerificarDataTable(infoUsuario))
                {
                    MessageBox.Show(Resources.InformacoesIncorretasLogin, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Configuracoes.config.AppSettings.Settings["usuarioLogado"].Value = infoUsuario.Rows[0][1].ToString();
            Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = infoUsuario.Rows[0][3].ToString();
            Configuracoes.config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            AppManager.ReiniciarPrograma();
        }
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