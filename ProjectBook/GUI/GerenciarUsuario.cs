using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;
using ProjectBook.Tipos;

namespace ProjectBook.GUI
{
    public partial class GerenciarUsuario : Form
    {
        private UsuarioDb usuarioDb = new();
        public GerenciarUsuario()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("GerenciarUsuario");
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioModel usuario = 
                new(txtUsuarioCadastrar.Text,
                txtSenhaCadastrar.Text,
                TipoUsuario.USU.ToString());

            if (Verificadores.VerificarCamposUsuario(usuario))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            usuarioDb.CadastrarUsuario(usuario);
            
            LimparCampos();
        }

        private void btnSalvarEditarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioModel usuario = new(txtNovoUsuario.Text, txtNovoSenhaUsuario.Text, cmbNovoStatus.Text);
            if (Verificadores.VerificarCamposUsuario(usuario))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            usuarioDb.AtualizarUsuarioId(txtIdBuscarUsuario.Text, usuario);

            LimparCampos();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            txtIdBuscarUsuario.Enabled = false;

            DataTable infoUsuario = usuarioDb.BuscarUsuarioId(txtIdBuscarUsuario.Text);

            if (Verificadores.VerificarDataTable(infoUsuario))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNovoUsuario.Text = infoUsuario.Rows[0][1].ToString();
            txtNovoSenhaUsuario.Text = infoUsuario.Rows[0][2].ToString();
            cmbNovoStatus.Text = infoUsuario.Rows[0][3].ToString();
        }

        private void btnLimparEditarUsuario_Click(object sender, EventArgs e) => LimparCampos();
        private void btnLimparCadastrarUsuario_Click(object sender, EventArgs e) => LimparCampos();

        private void LimparCampos()
        {
            txtUsuarioCadastrar.Clear();
            txtSenhaCadastrar.Clear();
            txtNovoUsuario.Clear();
            txtNovoSenhaUsuario.Clear();
            cmbNovoStatus.Text = "";
            txtIdBuscarUsuario.Enabled = true;
            txtIdBuscarUsuario.Clear();
        }
    }
}