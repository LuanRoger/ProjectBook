using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook.GUI
{
    public partial class Login : Form
    {
        private UsuarioDb usuarioDb = new UsuarioDb();
        public Login()
        {
            InitializeComponent();
        }

        private void btnFecharLogin_Click(object sender, EventArgs e) => Application.Exit();
        
        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtLoginUsuario.Text, txtLoginSenha.Text))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            usuarioDb.AbrirConexaoDb();
            DataTable infoUsuario = usuarioDb.LoginUsuario(txtLoginUsuario.Text, txtLoginSenha.Text);
            usuarioDb.FechaConecxaoDb();
            
            if (Verificadores.VerificarDataTable(infoUsuario))
            {
                MessageBox.Show(Properties.Resources.informacoesIncorretas, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Configuracoes.config.AppSettings.Settings["usuarioLogado"].Value = txtLoginUsuario.Text;
            Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = infoUsuario.Rows[0][3].ToString();
            Configuracoes.config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            
            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }
    }
}